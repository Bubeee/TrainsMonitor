//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainsMonitor.Repository.MSSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class FuelConsumption
    {
        public int Id { get; set; }
        public Nullable<float> Heater1FuelConsumption { get; set; }
        public Nullable<float> Heater2FuelConsumption { get; set; }
        public Nullable<float> AirHeaterFuelConsumption { get; set; }
        public Nullable<int> RecordId { get; set; }
    
        public virtual SystemData SystemData { get; set; }
    }
}