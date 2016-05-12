namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class Flags : Entity
    {
        // 2-byte
        public int Heater1Flags { get; set; }
        public int Heater2Flags { get; set; }
        public int AirHeaterFlags { get; set; }

        public byte SystemFlags { get; set; }
    }
}