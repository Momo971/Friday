using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FridayCard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FridayController
{
	public class ConfigDataManager : Singleton<ConfigDataManager>
	{
		private List<PirateCard> _pirateList = new List<PirateCard>();
		private List<SkillKind> _skillKindList = new List<SkillKind>();
		private List<SkillConfig> _skillConfigList = new List<SkillConfig>();
		private List<OriginCard> _originCardList = new List<OriginCard>();
		private List<AgingCard> _agingCardList = new List<AgingCard>();
		private List<HazardCard> _hazardCardList = new List<HazardCard>();

		private string _configAddress = Environment.CurrentDirectory + "\\Config\\{0}.json";
		private List<string> _configNameList = new List<string>
		{
			"PirateCard",
			"OriginCard",
			"SkillKind",
			"SkillConfig",
			"AgingCard",
			"HazardCard"
		};

		public ConfigDataManager()
		{
			LoadConfigData();
		}

		private void LoadConfigData()
		{
			foreach(var config in _configNameList)
			{
				foreach (var jtoken in GetJArrayByName(config))
				{
					AddListByType(config, jtoken);
				}
			}
		}

		private void AddListByType(string configName, JToken jtoken)
		{
			var jobj = GetJObjectByJToken(jtoken);
			switch (configName)
			{
				case "PirateCard":
					_pirateList.Add(Jobj2PirateCard(jobj));
					break;
				case "SkillKind":
					_skillKindList.Add(Jobj2SkillKind(jobj));
					break;
				case "SkillConfig":
					_skillConfigList.Add(Jobj2SkillConfig(jobj));
					break;
				case "OriginCard":
					_originCardList.Add(Jobj2OriginCard(jobj));
					break;
				case "AgingCard":
					_agingCardList.Add(Jobj2AgingCard(jobj));
					break;
				case "HazardCard":
					_hazardCardList.Add(Jobj2HazardCard(jobj));
					break;
			}
		}

		private JArray GetJArrayByName(string name)
		{
			string path = string.Format(_configAddress, name);
			string jsonTxt = File.ReadAllText(path, Encoding.UTF8);
			var objArray = JsonConvert.DeserializeObject(jsonTxt);
			return objArray as JArray;
		}

		private JObject GetJObjectByJToken(JToken token)
		{
			var jsonItemTxt = token.ToString();
			var jsonData = JsonConvert.DeserializeObject(jsonItemTxt);
			return jsonData as JObject;
		}

		private PirateCard Jobj2PirateCard(JObject jobj)
		{
			return new PirateCard(
					uint.Parse(jobj["PirateID"].ToString()),
					jobj["PirateName"].ToString(),
					uint.Parse(jobj["HazardValue"].ToString()),
					uint.Parse(jobj["SpecialSkill"].ToString()),
					uint.Parse(jobj["FreeCardsNum"].ToString())
					);
		}

		private SkillKind Jobj2SkillKind(JObject jobj)
		{
			return new SkillKind(
					uint.Parse(jobj["SkillKind"].ToString()),
					jobj["SkillDes"].ToString()
				);
		}

		private SkillConfig Jobj2SkillConfig(JObject jobj)
		{
			return new SkillConfig(
					uint.Parse(jobj["SkillID"].ToString()),
					uint.Parse(jobj["SkillKindID"].ToString()),
					jobj["SkillName"].ToString(),
					uint.Parse(jobj["Param"].ToString())
				);
		}

		private OriginCard Jobj2OriginCard(JObject jobj)
		{
			return new OriginCard(
					   uint.Parse(jobj["CardID"].ToString()),
					   jobj["CardName"].ToString(),
					   int.Parse(jobj["CombatEffectiveness"].ToString()),
					   uint.Parse(jobj["SpecialSkill"].ToString()),
					   uint.Parse(jobj["LifeValueDestroyNeeded"].ToString())
					   );

		}

		private AgingCard Jobj2AgingCard(JObject jobj)
		{
			return new AgingCard(
					   uint.Parse(jobj["CardID"].ToString()),
					   jobj["CardName"].ToString(),
					   int.Parse(jobj["CombatEffectiveness"].ToString()),
					   uint.Parse(jobj["SpecialSkill"].ToString()),
					   uint.Parse(jobj["LifeValueDestroyNeeded"].ToString()),
					   uint.Parse(jobj["IsHard"].ToString()) > 0
				);
		}

		private HazardCard Jobj2HazardCard(JObject jobj)
		{
			return new HazardCard(
					   uint.Parse(jobj["CardID"].ToString()),
					   jobj["CardName"].ToString(),
					   int.Parse(jobj["CombatEffectiveness"].ToString()),
					   uint.Parse(jobj["SpecialSkill"].ToString()),
					   uint.Parse(jobj["LifeValueDestroyNeeded"].ToString()),
					   uint.Parse(jobj["FreeCardsNum"].ToString()),
					   uint.Parse(jobj["HazardValue1"].ToString()),
					   uint.Parse(jobj["HazardValue2"].ToString()),
					   uint.Parse(jobj["HazardValue3"].ToString())
				);
		}

		public List<PirateCard> GetPirates()
		{
			return _pirateList;
		}

		public List<SkillKind> GetSkillKinds()
		{
			return _skillKindList;
		}

		public List<SkillConfig> GetSkillConfigs()
		{
			return _skillConfigList;
		}

		public List<OriginCard> GetOriginCards()
		{
			return _originCardList;
		}

		public List<AgingCard> GetAgingCards()
		{
			return _agingCardList;
		}

		public List<HazardCard> GetHazardCards()
		{
			return _hazardCardList;
		}


	}

}
