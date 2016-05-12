namespace TrainsMonitor.Repository.MSSQL.Entities
{
    public class FuelConsumptions : Entity
    {
        public float Heater1FuelConsumption { get; set; }
        public float Heater2FuelConsumption { get; set; }
        public float AirHeaterFuelConsumption { get; set; }
    }
}