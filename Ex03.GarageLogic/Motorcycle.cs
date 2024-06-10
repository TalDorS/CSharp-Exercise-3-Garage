using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheelsInMotorcycle = 2;
        private const float k_MaxMotorcycleWheelPressure = 33f;
        private const float k_MaxMotorcycleFuel = 5.5f;
        private const float k_MaxMotorcycleCharge = 2.5f;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle()
        {
            NumOfWheels = k_NumberOfWheelsInMotorcycle;
            MaxWheelPressure = k_MaxMotorcycleWheelPressure;
            FuelType = Enums.eFuelType.Octan98;
            MaxFuel = k_MaxMotorcycleFuel;
            MaxCharge = k_MaxMotorcycleCharge;
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public override string ToString()
        {
            return string.Format("License Type: {0}{1}Engine Capacity: ", m_LicenseType.ToString(), Environment.NewLine, m_EngineCapacity.ToString());
        }
    }
}
