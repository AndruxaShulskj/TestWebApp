
namespace TestWebApp.Business.Models
{
    public class LogData
    {
        public DateTime Date { get; set; }

        public long Duration { get; set; }

        public string? Request { get; set; }

        public string? Response { get; set; }

        public int Code { get; set; }
    }
}
