using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPPERF.Models
{
    [Table("users")]
    public class RuzUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string crypted_password { get; set; }
        public string salt { get; set; }
        public string time_zone { get; set; }
        public string state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}