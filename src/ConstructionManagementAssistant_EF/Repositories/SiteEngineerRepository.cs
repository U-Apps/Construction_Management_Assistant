using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Extentions;
using ConstructionManagementAssistant.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace ConstructionManagementAssistant.EF.Repositories;

public class SiteEngineerRepository : ISiteEngineerRepository
{

    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _context;
    private readonly ILogger<SiteEngineerRepository> _logger;

    public SiteEngineerRepository(
        AppDbContext context,
        UserManager<AppUser> userManager,
        ILogger<SiteEngineerRepository> logger)
    {
        _userManager = userManager;
        _context = context;
        _logger = logger;
    }

    public async Task<BaseResponse<UserDto?>> GetSiteEngineerById(int id)
    {
        _logger.LogInformation("Fetching site engineer with ID: {Id}", id);

        try
        {
            var appUser = await _context.Users.FindAsync(id);
            if (appUser == null)
            {
                _logger.LogWarning("Site engineer with ID: {Id} not found", id);
                return new BaseResponse<UserDto?>
                {
                    Success = false,
                    Message = "المهندس غير موجود",
                    Data = null
                };
            }

            _logger.LogInformation("Site engineer with ID: {Id} fetched successfully", id);
            return new BaseResponse<UserDto?>
            {
                Success = true,
                Message = "تم جلب المهندس بنجاح",
                Data = appUser.ToUserDto()
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching site engineer with ID: {Id}", id);
            return new BaseResponse<UserDto?>
            {
                Success = false,
                Message = "حدث خطأ أثناء جلب المهندس",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public async Task<BaseResponse<PagedResult<UserDto>>> GetAllSiteEngineers(
        string userId,
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
    {
        _logger.LogInformation("Fetching all site engineers for belongToUserId: {UserId}, page: {PageNumber}, size: {PageSize}, search: {SearchTerm}", userId, pageNumber, pageSize, searchTerm);

        try
        {
            var query = _context.Users
                .Where(x => x.BelongToUserId == int.Parse(userId));

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(u =>
                    u.Name.Contains(searchTerm) ||
                    u.Email.Contains(searchTerm) ||
                    u.PhoneNumber.Contains(searchTerm));
            }

            var totalItems = await query.CountAsync();
            var items = await query
                .OrderBy(x => x.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => u.ToUserDto())
                .ToListAsync();

            var pagedResult = new PagedResult<UserDto>
            {
                Items = items,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
            };

            _logger.LogInformation("Fetched {Count} site engineers for belongToUserId: {UserId}", items.Count, userId);

            return new BaseResponse<PagedResult<UserDto>>
            {
                Success = true,
                Message = "تم جلب المهندسين بنجاح",
                Data = pagedResult
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching site engineers for belongToUserId: {UserId}", userId);
            return new BaseResponse<PagedResult<UserDto>>
            {
                Success = false,
                Message = "حدث خطأ أثناء جلب المهندسين",
                Errors = new List<string> { ex.Message }
            };
        }
    }


    public async Task<List<UserNameDto>> GetSiteEngineersNames(string userId)
    {
        _logger.LogInformation("Fetching site engineer names for belongToUserId: {UserId}", userId);

        try
        {
            int belongToUserId = int.Parse(userId);

            var names = await _context.Users
                .Where(u => u.BelongToUserId == belongToUserId)
                .OrderBy(u => u.Name)
                .Select(u => new UserNameDto
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();

            _logger.LogInformation("Fetched {Count} site engineer names for belongToUserId: {UserId}", names.Count, userId);

            return names;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching site engineer names for belongToUserId: {UserId}", userId);
            return new List<UserNameDto>();
        }
    }


    public async Task<BaseResponse<string>> AddSiteEngineerAsync(string userId, RegisterDto registerDto)
    {
        _logger.LogInformation("Registration attempt for email: {Email}", registerDto.Email);

        var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            _logger.LogWarning("Registration failed: email already exists: {Email}", registerDto.Email);
            return new BaseResponse<string>
            {
                Message = "Registration failed, email already exists",
                Success = false,
            };
        }

        var user = new AppUser
        {
            Name = registerDto.Name,
            PhoneNumber = registerDto.PhoneNumber,
            UserName = registerDto.Email.Split('@')[0],
            Email = registerDto.Email,
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            BelongToUserId = int.Parse(userId),
            RefreshTokens = new List<RefreshToken>()
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            var errorMessages = result.Errors.Select(x => x.Description).ToList();
            _logger.LogWarning("Registration failed for email: {Email}. Errors: {Errors}", registerDto.Email, string.Join(", ", errorMessages));
            return new BaseResponse<string>
            {
                Errors = errorMessages,
                Message = "Invalid registration",
                Success = false,
            };
        }

        var roleResult = await _userManager.AddToRoleAsync(user, SystemRole.SiteEngineer.ToString());
        if (!roleResult.Succeeded)
        {
            await _userManager.DeleteAsync(user);
            _logger.LogWarning("Role assignment failed for user: {Email}. Errors: {Errors}", registerDto.Email, string.Join(", ", roleResult.Errors.Select(x => x.Description)));
            return new BaseResponse<string>
            {
                Errors = roleResult.Errors.Select(x => x.Description).ToList(),
                Message = "Could not assign role to this user",
                Success = false,
            };
        }



        _logger.LogInformation("Registration successful for email: {Email}", registerDto.Email);

        return new BaseResponse<string> { Success = true, Message = "Site Engineer added Succfully" };


        //_logger.LogInformation("Adding a new site engineer: {UserName}", newUser.Name);

        //try
        //{
        //    var siteEngineer = new AppUser
        //    {
        //        Name = newUser.Name,
        //        PhoneNumber = newUser.PhoneNumber,
        //        Email = newUser.Email,
        //        UserName = newUser.Email.Split('@')[0],

        //        NormalizedEmail = newUser.Email.ToUpper(),
        //        NormalizedUserName = newUser.Email.Split('@')[0].ToUpper(),
        //        EmailConfirmed = true,
        //        BelongToUserId = int.Parse(userId)
        //    };


        //    await _context.Users.AddAsync(siteEngineer);
        //    await _context.SaveChangesAsync();

        //    // Add role with id 2 to the user
        //    var userRole = new IdentityUserRole<int>
        //    {
        //        UserId = siteEngineer.Id,
        //        RoleId = (int)SystemRole.SiteEngineer
        //    };
        //    await _context.Set<IdentityUserRole<int>>().AddAsync(userRole);
        //    await _context.SaveChangesAsync();

        //    _logger.LogInformation("Site engineer added successfully: {UserName}", newUser.Name);
        //    return new BaseResponse<string>
        //    {
        //        Success = true,
        //        Message = "تم إضافة المهندس بنجاح"
        //    };
        //}
        //catch (Exception ex)
        //{
        //    _logger.LogError(ex, "Error occurred while adding a site engineer: {UserName}", newUser.Name);
        //    return new BaseResponse<string>
        //    {
        //        Success = false,
        //        Message = "حدث خطأ أثناء إضافة المهندس",
        //        Errors = new List<string> { ex.Message }
        //    };
        //}
    }

    public async Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id)
    {
        _logger.LogInformation("Deleting site engineer with ID: {Id}", id);

        try
        {
            var appUser = await _context.Users.FindAsync(id);

            if (appUser == null)
            {
                _logger.LogWarning("Site engineer with ID: {Id} not found for delete", id);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المهندس غير موجود"
                };
            }

            // Remove related AppRoles (IdentityUserRole<int>)
            var userRoles = _context.Set<IdentityUserRole<int>>().Where(ur => ur.UserId == id);
            _context.Set<IdentityUserRole<int>>().RemoveRange(userRoles);

            _context.Users.Remove(appUser);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Site engineer with ID: {Id} deleted successfully", id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف المهندس بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting site engineer with ID: {Id}", id);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "حدث خطأ أثناء حذف المهندس",
                Errors = new List<string> { ex.Message }
            };
        }
    }
}
