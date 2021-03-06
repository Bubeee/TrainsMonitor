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
    
    public partial class Temperature
    {
        public int Id { get; set; }
        public Nullable<float> EnvironmentTemperature { get; set; }
        public Nullable<float> Radiator1Temperature { get; set; }
        public Nullable<float> Radiator2Temperature { get; set; }
        public Nullable<float> FootstepTemperature { get; set; }
        public Nullable<float> TurbineTemperature { get; set; }
        public Nullable<float> OilTemperature { get; set; }
        public Nullable<float> TransformatorTemperature { get; set; }
        public Nullable<float> CabinTemperature { get; set; }
        public Nullable<int> RecordId { get; set; }
    
        public virtual SystemData SystemData { get; set; }
    }
}
