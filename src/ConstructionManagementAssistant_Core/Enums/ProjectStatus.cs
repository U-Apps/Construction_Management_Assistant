namespace ConstructionManagementAssistant.Core.Enums;

/// <summary>
/// حالة المشروع
/// </summary>
public enum ProjectStatus
{
    /// <summary>
    /// لم يبدأ
    /// </summary>
    [Display(Name = "لم يبدأ")]
    NotStarted,

    /// <summary>
    /// قيد التنفيذ
    /// </summary>
    [Display(Name = "قيد التنفيذ")]
    InProgress,

    /// <summary>
    /// معلق
    /// </summary>
    [Display(Name = "معلق")]
    OnHold,

    /// <summary>
    /// مكتمل
    /// </summary>
    [Display(Name = "مكتمل")]
    Completed,

    /// <summary>
    /// ملغي
    /// </summary>
    [Display(Name = "ملغي")]
    Cancelled
}