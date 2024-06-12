using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        // CTOR
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        // Properties
        public string Manufacturer
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure;}
            set { m_CurrentAirPressure = value;}
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        // Methods
        public void AddAir(float i_AirToAdd)
        {
            float newAirPressure = m_CurrentAirPressure + i_AirToAdd;

            if(newAirPressure > r_MaxAirPressure || newAirPressure < m_CurrentAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure - m_CurrentAirPressure);
            }

            m_CurrentAirPressure = newAirPressure;
        }

        public void InflateToMax()
        {
            float newAirPressure = MaxAirPressure - m_CurrentAirPressure;

            AddAir(newAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
@"
Current Wheel Air Pressure: {0}
Max Wheel Air Pressure: {1}
Wheel's Manufacturer Name: {2}",
CurrentAirPressure,
MaxAirPressure,
Manufacturer);
        }
    }
}
