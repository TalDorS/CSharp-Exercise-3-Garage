using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheelsInTruck = 12;
        private const float k_MaxTruckWheelPressure = 28f;
        private const float k_MaxCarFuel = 120f;
        private const float k_MaxCarCharge = 3.5f;
        private bool m_IsDangerousMaterials;
        private float m_CargoCapacity;

        public Truck()
        {
            NumOfWheels = k_NumberOfWheelsInTruck;
            MaxWheelPressure = k_MaxTruckWheelPressure;
            FuelType = Enums.eFuelType.Soler;
            MaxFuel = k_MaxCarFuel;
        }

        public bool IsCarryingDangerousMaterials
        {
            get { return m_IsDangerousMaterials; }
            set { m_IsDangerousMaterials = value;}
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; }
            set { m_CargoCapacity = value;}
        }

        public void SetDangerousMaterials(string i_DangerousMaterialsInput)
        {
            if (!int.TryParse(i_DangerousMaterialsInput, out int o_DangerousMaterials))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            switch (o_DangerousMaterials)
            {
                case 0:
                    IsCarryingDangerousMaterials = false;
                    break;
                case 1:
                    IsCarryingDangerousMaterials = true;
                    break;
                default:
                    throw new ValueOutOfRangeException(0, 1);
            }
        }

        public void SetCargoCapacity(string i_CargoCapacityInput)
        {
            if (!float.TryParse(i_CargoCapacityInput, out float o_CargoCapacity))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            if (o_CargoCapacity < 0)
            {
                throw new ArgumentException("Cargo capacity cannot be negative!");
            }

            CargoCapacity = o_CargoCapacity;
        }

        public override string ToString()
        {
            return string.Format("Is The Truck Carrying Dangerous Material: {0}{1}Cargo Capacity: ", m_IsDangerousMaterials.ToString(), Environment.NewLine, m_CargoCapacity.ToString());
        }
    }
}
