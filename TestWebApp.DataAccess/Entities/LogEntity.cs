using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.DataAccess.Entities
{
    [Table("logEntity")]
    public class LogEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("duration")]
        public long Duration { get; set; }

        [Column("request")]
        public string? Request { get; set; }

        [Column("response")]
        public string? Response { get; set; }

        [Column("code")]
        public int Code { get; set; }
    }
}
