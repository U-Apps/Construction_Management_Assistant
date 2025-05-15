namespace ConstructionManagementAssistant.Core.Enums;


public enum ProjectStatus
{
    [Display(Name = "قيد التنفيذ")]
    Active,

    [Display(Name = "معلق")]
    Pending,

    [Display(Name = "مكتمل")]
    Completed,


    [Display(Name = "ملغي")]
    Cancelled
}