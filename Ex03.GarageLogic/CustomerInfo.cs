using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CustomerInfo
    {
        private string m_Name;
        private string m_PhoneNumber;
        private eCarStatus k_CarStatus = eCarStatus.InRepair;

        public CustomerInfo(string i_Name, string i_PhoneNumber) 
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public eCarStatus CarStatus
        {
            get { return k_CarStatus; }
            set { k_CarStatus = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public override string ToString()
        {
            return string.Format("Owner Name: {0}{1}Current State: {2}", Name, Environment.NewLine, k_CarStatus);
        }
    }
}
