using System;

namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class SystemData : Entity
    {
        public int PackageNumber { get; set; }
        public int SystemSerialNumber { get; set; }

        // byte[15]
        public string ProviderName { get; set; }
        public bool IsSystemWorking { get; set; }
        public DateTime MeasurementDateTime { get; set; }
        public float VoltageAkb { get; set; }
    }
}
