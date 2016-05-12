namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class Coordinates : Entity
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}