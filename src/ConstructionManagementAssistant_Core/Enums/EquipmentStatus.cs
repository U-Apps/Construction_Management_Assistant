namespace ConstructionManagementAssistant.Core.Enums
{
    public enum EquipmentStatus
    {
        [Display(Name = "متاح")]
        Available,
        [Display(Name = "قيد الاستخدام")]
        InUse,
        [Display(Name = "تحت الصيانة")]
        UnderMaintenance,
        [Display(Name = "خارج الخدمة")]
        OutOfService
    }
}
