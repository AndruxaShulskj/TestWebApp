using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TestWebApp.Common
{
    public class DataFilter
    {
        public string? PropertyName { get; set; }

        public DataFilterType DataFilterType { get; set; }

        public string Test { get; set; }
    }
}
