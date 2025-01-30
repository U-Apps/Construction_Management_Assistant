namespace ConstructionManagementAssistant_EF.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void AddEnumCheckConstraint<TEnum>(this EntityTypeBuilder builder, string tableName, string columnName) where TEnum : Enum
        {
            var enumValues = string.Join(", ", Enum.GetValues(typeof(TEnum)).Cast<int>());
            builder.ToTable(tableName, t =>
            {
                t.HasCheckConstraint($"CK_{tableName}_{columnName}", $"[{columnName}] IN ({enumValues})");
            });
        }
    }
}
