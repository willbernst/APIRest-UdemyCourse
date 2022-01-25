using RESTAPIUdemyCourse.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIUdemyCourse.Model
{
    [Table("Company")]
    public class Company : BaseEntity
    {
        [Column("stock_name")]
        public string StockName { get; set; }
        [Column("stock_sector")]
        public string StockSector { get; set; }
        [Column("ein")]
        public string Ein { get; set; }
        [Column("address")]
        public string Address { get; set; }
    }
}
