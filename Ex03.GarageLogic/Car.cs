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
        private const int k_MinColorNum = 1;
        private const int k_MaxColorNum = 4;
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private const int k_NumberOfWheelsInCar = 5;
        private const float k_MaxCarWheelPressure = 31f;
        private const float k_MaxCarFuel = 45f;
        private const float k_MaxCarCharge = 3.5f;
        private eCarColor m_CarColor;
        private int numOfDoors;

        public Car() 
        {
            NumOfWheels = k_NumberOfWheelsInCar;
            MaxWheelPressure = k_MaxCarWheelPressure;
            FuelType = Enums.eFuelType.Octan95;
            MaxFuel = k_MaxCarFuel;
            MaxCharge = k_MaxCarCharge;
        }

        public int NumOfDoors
        {
            get { return numOfDoors; }
            set { numOfDoors = value; }
        }

        public eCarColor ColorOfCar
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public void SetNumOfDoors(string i_NumOfDoorsInput)
        {
            if(!int.TryParse(i_NumOfDoorsInput, out int o_NumOfDoors))
            {
                throw new FormatException("Invalid input! can only accept integers");
            }

            if(numOfDoors < k_MinNumOfDoors || numOfDoors > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, k_MaxNumOfDoors);
            }

            NumOfDoors = o_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format("Car Color: {0}{1}Number Of Doors: ", m_CarColor.ToString(), Environment.NewLine, numOfDoors.ToString());
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

            ColorOfCar = (eCarColor)o_CarColor;
        }
    }
}
