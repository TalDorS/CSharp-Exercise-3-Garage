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
        private float m_MaxFuel;
        private float m_MaxCharge;
        private eVehicleType m_VehicleType;
        private eFuelType m_FuelType;
        private float m_MaxWheelPressure;

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
            get { return m_MaxWheelPressure; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType;}
            set { m_FuelType = value; }
        }

        public float MaxFuel
        {
            get { return m_MaxFuel; }
        }

        public float MaxCharge
        {
            get { return m_MaxCharge; }
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

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public eVehicleType VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }
    }
}
