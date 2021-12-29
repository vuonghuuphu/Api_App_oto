using System;
using System.Collections.Generic;

#nullable disable

namespace Api_AppAuto.Models
{
    public partial class Parameter
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string Engine { get; set; }
        public string MaximumPower { get; set; }
        public string Maximumtorque { get; set; }
        public int Acceleration { get; set; }
        public int Maximumspeed { get; set; }
        public string Fuel { get; set; }
        public string FuelTankCapacity { get; set; }
    }
}
