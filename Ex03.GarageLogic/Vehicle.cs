using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private int m_NumOfWheels;
        private Engine m_Engine;
        private List<Wheel> m_Wheels;
        private float r_MaxFuel;
        private float r_MaxCharge;
        //private eVehicleType m_VehicleType; not sure if needed, can be checked with 'is' keyword
        private eFuelType m_FuelType;
        private float r_MaxWheelPressure;

        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public int NumOfWheels
        {
            get { return m_NumOfWheels; }
            set { m_NumOfWheels = value; }
        }

        public float MaxWheelPressure
        {
            get { return r_MaxWheelPressure; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType;}
            set { m_FuelType = value; }
        }

        public float MaxFuel
        {
            get { return r_MaxFuel; }
        }

        public float MaxCharge
        {
            get { return r_MaxCharge; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }
    }
}
