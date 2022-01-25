using RESTAPIUdemyCourse.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIUdemyCourse.Model
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}
