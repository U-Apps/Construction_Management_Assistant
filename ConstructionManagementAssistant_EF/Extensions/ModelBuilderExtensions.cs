namespace ConstructionManagementAssistant_EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddEnumCheckConstraint<TEnum>(this EntityTypeBuilder builder, string tableName, string columnName) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<int>().ToArray();
            if (enumValues.Length > 0)
            {
                Array.Sort(enumValues);
                bool isSequential = true;
                for (int i = 1; i < enumValues.Length; i++)
                {
                    if (enumValues[i] != enumValues[i - 1] + 1)
                    {
                        isSequential = false;
                        break;
                    }
                }

                if (isSequential)
                {
                    int minValue = enumValues.First();
                    int maxValue = enumValues.Last();
                    builder.ToTable(tableName, t =>
                    {
                        t.HasCheckConstraint($"CK_{tableName}_{columnName}", $"[{columnName}] BETWEEN {minValue} AND {maxValue}");
                    });
                }
            }
        }
    }
}
