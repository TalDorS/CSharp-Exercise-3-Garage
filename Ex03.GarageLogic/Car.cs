using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
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

        public override string ToString()
        {
            return string.Format("Car Color: {0}{1}Number Of Doors: ", m_CarColor.ToString(), Environment.NewLine, numOfDoors.ToString());
        }
    }
}
