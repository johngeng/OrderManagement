
namespace Order.Management.Order.Interface
{
    public interface IOrderReportService
    {
        Order Order { get; set; }
        int DisplayOrder { get; }
        int TableWidth { get; set; }

        void GenerateReport();
    }
}
