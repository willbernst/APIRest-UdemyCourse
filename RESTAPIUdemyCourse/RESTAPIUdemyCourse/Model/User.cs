using RESTAPIUdemyCourse.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIUdemyCourse.Model
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        [Column("refresh_token_expire_time")]
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}
