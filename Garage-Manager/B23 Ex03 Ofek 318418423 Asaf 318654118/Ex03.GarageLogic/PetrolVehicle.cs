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
        protected float m_CurrentTankInLiter;
        protected float m_MaxLiterInTank;

        public PetrolVehicle(float i_MaxTankInLiter, ePetrolType i_PetrolType, string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure, string i_OwnerName, string i_OwnerPhone, float i_CurrentLiterInTank) : base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName,
            i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone)
        {
            this.m_CurrentTankInLiter = i_CurrentLiterInTank;
            this.m_MaxLiterInTank = i_MaxTankInLiter;
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

        public override void AddEnergy(float i_LitersToAdd)
        {
            FillTank(i_LitersToAdd);
        }

        public void FillTank(float i_LitersToAdd)
        {
            float sizeAfterFilling = this.CurrentTankInLiter + i_LitersToAdd;

            if (sizeAfterFilling > this.m_MaxLiterInTank)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxLiterInTank - this.CurrentTankInLiter);
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
            return this.m_MaxLiterInTank;
        }

        public override string ToString()
        {
            string msg = base.ToString();

            msg += string.Format("Petrol Type: {0}{1}", m_PetrolType, Environment.NewLine);
            msg += string.Format("Current Liter In Tank: {0}{1}", m_CurrentTankInLiter, Environment.NewLine);
            msg += string.Format("Max Tank In Liter: {0}{1}", m_MaxLiterInTank, Environment.NewLine);

            return msg;
        }
    }
}
