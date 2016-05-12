using System;

namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class TrainDataEntity : Entity
    {
        public int PackageNumber { get; set; }
        public int SystemSerialNumber { get; set; }

        // byte[15]
        public string ProviderName { get; set; }
        public bool IsSystemWorking { get; set; }
        public DateTime MeasurementDateTime { get; set; }

        // 12 4-byte floats
        public float EnvironmentTemperature { get; set; }
        public float Radiator1Temperature { get; set; }
        public float Radiator2Temperature { get; set; }
        public float FootstepTemperature { get; set; }
        public float TurbineTemperature { get; set; }
        public float OilTemperature { get; set; }
        public float TransformatorTemperature { get; set; }
        public float CabinTemperature { get; set; }
        public float VoltageAkb { get; set; }
        public float Heater1FuelConsumption { get; set; }
        public float Heater2FuelConsumption { get; set; }
        public float AirHeaterFuelConsumption { get; set; }

        // 2-byte
        public int Heater1Flags { get; set; }
        public int Heater2Flags { get; set; }
        public int AirHeaterFlags { get; set; }

        public byte SystemFlags { get; set; }

        public ushort CrcData { get; set; }
    }
}
