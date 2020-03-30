using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FridayCard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FridayController
{
	public class ConfigDataManagement : Singleton<ConfigDataManagement>
	{
		private List<PirateCard> _pirateList = new List<PirateCard>();

		private string _configAddress = Environment.CurrentDirectory + "\\Config\\{0}.txt";
		private string _pirateJsonName = "PirateConfig";
		private Dictionary<string, Type> _configDictionary = new Dictionary<string, Type>
		{
			{ "PirateConfig", typeof(PirateCard)},
			{ "OriginCard", typeof(OriginCard)},
		};

		public ConfigDataManagement()
		{
			LoadConfigData();
		}

		private void LoadConfigData()
		{
			foreach(var config in _configDictionary)
			{
				foreach (var jtoken in GetJArrayByName(config.Key))
				{
					AddListByType(config.Key, jtoken);
				}
			}
		}

		private void AddListByType(string configName, JToken jtoken)
		{
			switch (configName)
			{
				case "PirateConfig":
					_pirateList.Add(Jobj2PirateCard(jtoken));
					break;
			}
		}

		private JArray GetJArrayByName(string name)
		{
			string path = string.Format(_configAddress, _pirateJsonName);
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

		private PirateCard Jobj2PirateCard(JToken token)
		{
			var jobj = GetJObjectByJToken(token);
			return new PirateCard(
					uint.Parse(jobj["PirateID"].ToString()),
					jobj["PirateName"].ToString(),
					uint.Parse(jobj["HazardValue"].ToString()),
					uint.Parse(jobj["SpecialSkill"].ToString()),
					uint.Parse(jobj["FreeCardsNum"].ToString())
					);
		}

		private void AddItemToList(Type type)
		{

		}

		public List<PirateCard> GetPirates()
		{
			return _pirateList;
		}

	}

}
