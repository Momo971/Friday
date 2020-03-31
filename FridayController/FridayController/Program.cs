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
			foreach(var card in GameManager.GetInstance().AgingCardPile.GetPile())
			{
				Console.WriteLine(card.ToString());
			}

		}
	}
}
