using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const string k_CarColor = "1";
        private const string k_NumberOfDoors = "2";
        private const int k_MinColorNum = 1;
        private const int k_MaxColorNum = 4;
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private const int k_NumberOfWheelsInCar = 5;
        private const float k_MaxCarWheelPressure = 31f;
        private const float k_MaxCarFuel = 45f;
        private const float k_MaxCarCharge = 3.5f;
        private eCarColor m_CarColor;
        private int m_NumOfDoors;

        public Car() 
        {
            NumOfWheels = k_NumberOfWheelsInCar;
            MaxWheelPressure = k_MaxCarWheelPressure;
            FuelType = Enums.eFuelType.Octan95;
            MaxFuel = k_MaxCarFuel;
            MaxCharge = k_MaxCarCharge;
        }

        public override string GetSpecialAttributeString(string i_SpecialAttributeNumber)
        {
            string attributeString = string.Empty;

            switch (i_SpecialAttributeNumber)
            {
                case k_CarColor:
                {
                    attributeString = "Please choose a car color (Yellow, White, Red, Black): ";
                    break;
                }
                case k_NumberOfDoors:
                {
                    attributeString = "Please choose number of doors (2 to 5): ";
                    break;
                }
                default:
                {
                    throw new ValueOutOfRangeException(1, 2);
                }
            }

            return i_SpecialAttributeNumber;
        }

        public override void SetAttribute(string i_AttributeNum, string i_AttributeValue)
        {
            switch (i_AttributeNum)
            {
                case k_CarColor:
                    {
                        this.SetNumOfDoors(i_AttributeValue);
                        break;
                    }
                case k_NumberOfDoors:
                    {
                        this.SetCarColor(i_AttributeValue);
                        break;
                    }
                default:
                    {
                        throw new ValueOutOfRangeException(1, 2);
                    }
            }
        }

        public void SetNumOfDoors(string i_NumOfDoorsInput)
        {
            if(!int.TryParse(i_NumOfDoorsInput, out int o_NumOfDoors))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            if(o_NumOfDoors < k_MinNumOfDoors || o_NumOfDoors > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, k_MaxNumOfDoors);
            }

            m_NumOfDoors = o_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format("Car Color: {0}{1}Number Of Doors: ", m_CarColor.ToString(), Environment.NewLine, m_NumOfDoors.ToString());
        }

        public void SetCarColor(string i_CarColorInput)
        {
            if (!int.TryParse(i_CarColorInput, out int o_CarColor))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            if (o_CarColor < k_MinColorNum || o_CarColor > k_MaxColorNum)
            {
                throw new ValueOutOfRangeException(k_MinColorNum, k_MaxColorNum);
            }

            m_CarColor = (eCarColor)o_CarColor;
        }
    }
}
