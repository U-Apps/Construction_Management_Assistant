namespace ConstructionManagementAssistant.Core.Enums;


public enum ProjectStatus
{

    [Display(Name = "لم يبدأ")]  // todo : delete
    NotStarted,


    [Display(Name = "قيد التنفيذ")]
    Active,

    [Display(Name = "معلق")]
    Pending,

    [Display(Name = "مكتمل")]
    Completed,


    [Display(Name = "ملغي")]
    Cancelled
}