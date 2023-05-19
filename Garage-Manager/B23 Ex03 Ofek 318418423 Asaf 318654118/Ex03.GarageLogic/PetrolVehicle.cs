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

    class PetrolVehicle : Vehicle
    {
        protected ePetrolType m_PetrolType;
        protected float m_CurrentLiterInTank;
        protected float m_MaxTankInLiter;

        public PetrolVehicle(float i_MaxTankInLiter, ePetrolType i_PetrolType, string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure) : base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName,
            i_CurrentAirPressure, i_MaxAirPressure) 
        {
            this.m_CurrentLiterInTank = 0;
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
                return this.m_CurrentLiterInTank;
            }
            set
            {
                this.m_CurrentLiterInTank = value;
            }
        }

        public ePetrolType GetPetrolType()
        {
            return this.PetrolType;
        }

        public override void AddEnergy(float i_LitersToAdd)
        {
            FillTank(i_LitersToAdd);
        }

        public void FillTank(float i_LitersToAdd)
        {
            float sizeAfterFilling = this.CurrentTankInLiter + i_LitersToAdd;

            if (sizeAfterFilling > this.m_MaxTankInLiter)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxTankInLiter - this.CurrentTankInLiter);
            }
            else
            {
                this.CurrentTankInLiter = sizeAfterFilling;
            }
        }

        public override float GetCurrentEnergyLeft()
        {
            return this.CurrentTankInLiter;
        }

        public override float GetMaxEnergy()
        {
            return this.m_MaxTankInLiter;
        }
    }
}
