
namespace ConstructionManagementAssistant.Core.Entites
{
    public class Expenses : IEntity
    {
        public int Id { get; set; }
        public int TaskReportId { get; set; }
        public decimal Cost { get; set; }
        public TaskReport TaskReport { get; set; }

        public ExpensesType ExpensesType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
