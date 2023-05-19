using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private string m_ErrorMsg;

        public ValueOutOfRangeException(float i_MinVal, float i_MaxVal) : base()
        {
            m_ErrorMsg = string.Format("Value is out of range. It has to be between {0} and {1}", i_MinVal, i_MaxVal);
        }  
    }
}
