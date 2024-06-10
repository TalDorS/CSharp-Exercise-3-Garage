using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        private eFuelType m_FuelType;

        public ElectricEngine(float i_MaxCharge) : base(i_MaxCharge) { }

        public void AddCharge(float i_HoursToAdd)
        {
            AddFuelOrCharge(i_HoursToAdd);
        }

        public override string ToString()
        {
            return string.Format("Current Engine Charge: {0}", m_CurrentEnergy);
        }
    }
}
