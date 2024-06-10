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
        private const int k_MinutesInHour = 60;
        private eFuelType m_FuelType;

        public ElectricEngine(float i_MaxCharge) : base(i_MaxCharge) { }

        public void AddCharge(float i_MinutesToAdd)
        {
            float minutesToAdd = (float)(i_MinutesToAdd / k_MinutesInHour);

            AddFuelOrCharge(minutesToAdd);
        }

        public override string ToString()
        {
            return string.Format("Current Engine Charge: {0}", m_CurrentEnergy);
        }
    }
}
