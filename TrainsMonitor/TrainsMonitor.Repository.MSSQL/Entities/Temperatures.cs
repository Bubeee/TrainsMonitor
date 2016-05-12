﻿namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class Temperatures : Entity
    {
        public float EnvironmentTemperature { get; set; }
        public float Radiator1Temperature { get; set; }
        public float Radiator2Temperature { get; set; }
        public float FootstepTemperature { get; set; }
        public float TurbineTemperature { get; set; }
        public float OilTemperature { get; set; }
        public float TransformatorTemperature { get; set; }
        public float CabinTemperature { get; set; }
        public int RecordId { get; set; }
    }
}
