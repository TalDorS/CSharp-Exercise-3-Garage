using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
        private Dictionary<string, CustomerInfo> m_CustomersInfo = new Dictionary<string, CustomerInfo>();

        public void InsertCarToGarage(Vehicle i_Vehicle, CustomerInfo i_ClientInfo)
        {
            m_Vehicles.Add(i_Vehicle.LicenseNumber, i_Vehicle);
            m_CustomersInfo.Add(i_Vehicle.LicenseNumber, i_ClientInfo);
        }

        public bool IsCarInGarage(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public Vehicle GetCarByLicenseNumber(string i_LicenseNumber)
        {
            if (!IsCarInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage.");
            }

            return m_Vehicles[i_LicenseNumber];
        }

        public void ChangeVehicleState(string i_LicenseNumber, eVehicleStatus i_Status) // 3
        {
            if (!IsCarInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage.");
            }

            m_CustomersInfo[i_LicenseNumber].CarStatus = i_Status;
        }

        public void InflateWheelsToMax(string i_LicenseNumber) // 4
        {
            if (!IsCarInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage.");
            }

            foreach(Wheel wheel in m_Vehicles[i_LicenseNumber].Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void FuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountOfFuel) // 5
        {
            if (!IsCarInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage.");
            }

            if (m_Vehicles[i_LicenseNumber].Engine is ElectricEngine)
            {
                throw new ArgumentException("You cannot fuel an electric vehicle.");
            }

            (m_Vehicles[i_LicenseNumber].Engine as FuelEngine).AddFuel(i_AmountOfFuel, i_FuelType);
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_MinutesToCharge) // 6
        {
            if (!IsCarInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage.");
            }

            if (m_Vehicles[i_LicenseNumber].Engine is FuelEngine)
            {
                throw new ArgumentException("You cannot charge an electric vehicle.");
            }

            (m_Vehicles[i_LicenseNumber].Engine as ElectricEngine).AddCharge(i_MinutesToCharge);
        }

        public string VehicleInfoToString(string i_LicenseNumber) // 7
        {
            Vehicle currentVehicle;
            CustomerInfo currentCustomer;

            if (!IsCarInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage.");
            }

            currentVehicle = m_Vehicles[i_LicenseNumber];
            currentCustomer = m_CustomersInfo[i_LicenseNumber];

            return string.Format("License Number: {0}{1}Model Name: {2}{1}{3}{1}{4}{1}{5}{1}{6}{1}"
                , i_LicenseNumber, Environment.NewLine, currentVehicle.ModelName, currentCustomer.ToString(), currentVehicle.Wheels[0].ToString(), currentVehicle.Engine.ToString(), currentVehicle.ToString());
        }
    }
}
