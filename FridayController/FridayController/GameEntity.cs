namespace FridayCard
{
	class FightingCard
	{
		public uint CardID;
		public string CardName;
		public int CombatEffectiveness;
		public byte SpecialSkill;
		public uint LifeValueDestroyNeeded;
	}

	class OriginCard : FightingCard
	{

	}

	class AngingCard : FightingCard
	{
		public bool IsHard;
	}

	class HazardCard : FightingCard
	{
		public uint FreeCardsNum;
		public uint HazardValue1;
		public uint HazardValue2;
		public uint HazardValue3;
	}

	public class PirateCard
	{
		public uint PirateID;
		public string PirateName;
		public uint HazardValue;
		public uint SpecialSkill;
		public uint FreeCardsNum;

		public PirateCard(uint pirateID, string pirateName, uint hazardValue, uint specialSkill, uint freeCardsNum)
		{
			PirateID = pirateID;
			PirateName = pirateName;
			HazardValue = hazardValue;
			SpecialSkill = specialSkill;
			FreeCardsNum = freeCardsNum;
		}

		override public string ToString()
		{
			return "My Name is " + PirateName + " ~";
		}
	}
}