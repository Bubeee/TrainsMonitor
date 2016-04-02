namespace TrainsMonitor.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public ushort ComputedCrc { get; set; }
        public int NewEntityId { get; set; }
    }
}