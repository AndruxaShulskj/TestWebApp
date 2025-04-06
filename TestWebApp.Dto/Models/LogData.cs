
namespace TestWebApp.Dto.Models
{
    public class LogDto
    {
        public DateTime Date { get; set; }

        public long Duration { get; set; }

        public string? Request { get; set; }

        public string? Response { get; set; }

        public int Code { get; set; }
    }
}
