using System.Spatial;

namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class Coordinates : Entity
    {
        public Geography Latitude { get; set; }
        public Geography Longtitude { get; set; }
        public int RecordId { get; set; }
    }
}
