using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.DataAccess.Entities
{
    [Table("userData")]
    public class UserDataEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public int Code { get; set; }

        [Column("value")]
        public string? Value { get; set; }
    }
}
