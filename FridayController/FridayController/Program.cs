using System;
using System.Collections.Generic;
using System.IO;
using FridayCard;
using Newtonsoft.Json;

namespace FridayController
{
	class Program
	{
		static void Main(string[] args)
		{
			var temp = ConfigDataManager.GetInstance().GetPirates()[0].ToString();
			Console.WriteLine(temp);
		}
	}
}
