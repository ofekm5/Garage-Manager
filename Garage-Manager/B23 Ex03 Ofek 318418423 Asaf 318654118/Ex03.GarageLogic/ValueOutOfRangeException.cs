using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MinVal, float i_MaxVal) : base(
            string.Format("The specified value is out of range. It has to be between {0} and {1}", i_MinVal, i_MaxVal))
        {
           
        }  
    }
}
