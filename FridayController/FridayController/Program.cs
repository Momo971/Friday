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
			var card = GameManager.GetInstance().PlayerCardPile.DrawOnce();
			Console.WriteLine(card.ToString());
		}
	}
}
