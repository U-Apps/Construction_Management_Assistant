namespace ConstructionManagementAssistant.Core.Enums;


public enum ProjectStatus
{

    [Display(Name = "لم يبدأ")]
    NotStarted,


    [Display(Name = "قيد التنفيذ")]
    InProgress,

    [Display(Name = "معلق")]
    OnHold,

    [Display(Name = "مكتمل")]
    Completed,


    [Display(Name = "ملغي")]
    Cancelled
}