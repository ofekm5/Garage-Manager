using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum ePetrolType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    public class ValueOutOfRangeException : Exception
    {

    }

    class PetrolVehicle : Vehicle
    {
        private ePetrolType m_PetrolType;
        private float m_CurrentTankInLiter;
        private float m_MaxTankInLiter;

        public PetrolVehicle(float i_MaxTankInLiter, ePetrolType i_PetrolType)
        {
            this.m_CurrentTankInLiter = 0;
            this.m_MaxTankInLiter = i_MaxTankInLiter;
            this.m_PetrolType = i_PetrolType;
        }

        public ePetrolType PetrolType
        {
            get
            {
                return this.m_PetrolType;
            }
            set
            {
                this.m_PetrolType = value;
            }
        }

        public float CurrentTankInLiter
        {
            get
            {
                return this.m_CurrentTankInLiter;
            }
            set
            {
                this.m_CurrentTankInLiter = value;
            }
        }

        public ePetrolType GetPetrolType()
        {
            return this.PetrolType;
        }

        public void FillTank(float i_LitersToAdd)
        {
            float sizeAfterFilling = this.CurrentTankInLiter + i_LitersToAdd;

            if (sizeAfterFilling > this.m_MaxTankInLiter)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                this.CurrentTankInLiter = sizeAfterFilling;
            }
        }

        public float GetCurrentTankLeft()
        {
            return this.CurrentTankInLiter;
        }

        public float GetMaxTank()
        {
            return this.m_MaxTankInLiter;
        }
    }
}
