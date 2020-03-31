namespace FridayCard
{
	/// <summary>
	/// 战斗卡
	/// </summary>
	public class FightingCard
	{
		public uint CardID;
		public string CardName;
		public int CombatEffectiveness;
		public uint SpecialSkill;
		public uint LifeValueDestroyNeeded;

		public FightingCard(uint cardID, string cardName, int combatEffectiveness, uint specialSkill, uint lifeValueDestroyNeeded)
		{
			CardID = cardID;
			CardName = cardName;
			CombatEffectiveness = combatEffectiveness;
			SpecialSkill = specialSkill;
			LifeValueDestroyNeeded = lifeValueDestroyNeeded;
		}

		public override string ToString()
		{
			return CardID.ToString() + "  " + CardName;
		}
	}

	public class OriginCard : FightingCard
	{
		public OriginCard(uint cardID, string cardName, int combatEffectiveness, uint specialSkill, uint lifeValueDestroyNeeded) : base(cardID, cardName, combatEffectiveness, specialSkill, lifeValueDestroyNeeded)
		{
		}
	}

	/// <summary>
	/// 衰老卡
	/// </summary>
	public class AgingCard : FightingCard
	{
		public bool IsHard;

		public AgingCard(uint cardID, string cardName, int combatEffectiveness, uint specialSkill, uint lifeValueDestroyNeeded, bool isHard) : base(cardID, cardName, combatEffectiveness, specialSkill, lifeValueDestroyNeeded)
		{
			IsHard = isHard;
		}


		public override string ToString()
		{
			return CardID.ToString() + "  " + CardName+ "  " + IsHard.ToString();
		}
	}

	/// <summary>
	/// 冒险卡
	/// </summary>
	public class HazardCard : FightingCard
	{
		public uint FreeCardsNum;
		public uint HazardValue1;
		public uint HazardValue2;
		public uint HazardValue3;

		public HazardCard(uint cardID, string cardName, int combatEffectiveness, uint specialSkill, uint lifeValueDestroyNeeded, uint freeCardsNum, uint hazardValue1, uint hazardValue2, uint hazardValue3) : base(cardID, cardName, combatEffectiveness, specialSkill, lifeValueDestroyNeeded)
		{
			FreeCardsNum = freeCardsNum;
			HazardValue1 = hazardValue1;
			HazardValue2 = hazardValue2;
			HazardValue3 = hazardValue3;
		}
	}

	/// <summary>
	/// 海盗卡
	/// </summary>
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
	}

	/// <summary>
	/// 技能种类
	/// </summary>
	public class SkillKind
	{
		public uint SkillKindID;
		public string SkillDes;

		public SkillKind(uint skillKindId, string skillDes)
		{
			SkillKindID = skillKindId;
			SkillDes = skillDes;
		}

		public override string ToString()
		{
			return SkillKindID.ToString() + "-" + SkillDes;
		}
	}

	/// <summary>
	/// 技能配置
	/// </summary>
	public class SkillConfig
	{
		public uint SkillID;
		public uint SkillKindID;
		public string SkillName;
		public uint Param;

		public SkillConfig(uint skillID, uint skillKindID, string skillName, uint param)
		{
			SkillID = skillID;
			SkillKindID = skillKindID;
			SkillName = skillName;
			Param = param;
		}
	}
}