var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersServices();
builder.Services.AddOpenApiServices();
builder.Services.AddSwaggerServices();
builder.Services.AddEF(builder.Configuration);
builder.Services.AddSupabase();
builder.Host.UseSerilogLoggging();

var Jwt = builder.Configuration.GetSection("JWT").Get<JWT>();
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

var key = Encoding.ASCII.GetBytes(Jwt!.Key);

QuestPDF.Settings.License = LicenseType.Community; // or LicenseType.Commercial if applicable



builder.Services.Configure<OpenAIOptions>(
    builder.Configuration.GetSection("OpenAI"));



builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 4;
})
     .AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = Jwt.Issuer,
        ValidAudience = Jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key)),
        ClockSkew = TimeSpan.Zero,
    };
});




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseOpenApi();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerTool();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RedirectToSwaggerMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();

app.MapControllers();

//Apply EF Core migrations at startup
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    db.Database.Migrate();
//}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var schemaQuery = @"
        SELECT t.name AS TableName, c.name AS ColumnName
        FROM sys.tables t
        JOIN sys.columns c ON t.object_id = c.object_id
        where t.name in ('Clients','Projects','Stages','Tasks','Equipments')
        ORDER BY t.name, c.column_id";

    // Use raw SQL to get schema rows
    var schemaRows = db.Database.SqlQueryRaw<SchemaRow>(schemaQuery).ToList();

    // Serialize to JSON and store globally
    ReportsController.dbSchema = JsonSerializer.Serialize(schemaRows);
}

app.Run();