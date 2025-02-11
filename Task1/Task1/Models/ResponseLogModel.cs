using Task1.Abstractions;

namespace Task1.Models
{
    public class ResponseLogModel: Model
    {
        public DateTime RequestDate { get; set; }
        public long Duration { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public int ResponseCode { get; set; }
    }
}
