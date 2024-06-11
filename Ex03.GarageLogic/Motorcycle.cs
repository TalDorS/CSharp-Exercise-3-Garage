using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_MinLicenseNum = 1;
        private const int k_MaxLicenseNum = 4;
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

        public void SetLicenseType(string i_LicenseInput)
        {
            if (!int.TryParse(i_LicenseInput, out int o_LicenseInput))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            if (o_LicenseInput < k_MinLicenseNum || o_LicenseInput > k_MaxLicenseNum)
            {
                throw new ValueOutOfRangeException(k_MinLicenseNum, k_MaxLicenseNum);
            }

            m_LicenseType = (eLicenseType)o_LicenseInput;
        }

        public void SetEngineCapacity(string i_EngineCapacity)
        {
            if (!int.TryParse(i_EngineCapacity, out int o_EngineCapacity))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            if (o_EngineCapacity < 0)
            {
                throw new ArgumentException("Engine capacity cannot be negative!");
            }

            EngineCapacity = o_EngineCapacity;
        }

        public override string ToString()
        {
            return string.Format("License Type: {0}{1}Engine Capacity: ", m_LicenseType.ToString(), Environment.NewLine, m_EngineCapacity.ToString());
        }
    }
}
