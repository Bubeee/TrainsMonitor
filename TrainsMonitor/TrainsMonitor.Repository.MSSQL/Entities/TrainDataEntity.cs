using System;

namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class TrainDataEntity
    {
        public int Id { get; set; }
        public ushort PackageNumber { get; set; }
        public ushort SystemSerialNumber { get; set; }

        // byte[15]
        public string ProviderName { get; set; }
        public DateTime DateTime { get; set; }

        // 12 4-byte floats
        public float EnvironmentTemperature { get; set; }
        public float Radiator1Temperature { get; set; }
        public float Radiator2Temperature { get; set; }
        public float FootstepTemperature { get; set; }
        public float TurbineTemperature { get; set; }
        public float OilTemperature { get; set; }
        public float TransformatorTemperature { get; set; }
        public float CabinTemperature { get; set; }
        public float Voltage { get; set; }
        public float Heater1FuelConsumption { get; set; }
        public float Heater2FuelConsumption { get; set; }
        public float AirHeaterFuelConsumption { get; set; }

        // 2-byte
        public ushort Heater1Flags { get; set; }
        public ushort Heater2Flags { get; set; }
        public ushort HeaterAirFlags { get; set; }

        public byte SystemFlags { get; set; }

        public ushort CrcData { get; set; }
    }
}
