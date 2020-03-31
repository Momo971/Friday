using System;
using System.Collections.Generic;
using System.Text;

namespace FridayController
{
	public static class GeneralUtils
	{
		//洗牌方法
		public static void ShuffleList<T>(List<T> list)
		{
			Random random = new Random();
			for (int i = 0; i < list.Count; i++)
			{
				var curCard = list[random.Next(i, list.Count)];
				list.Remove(curCard);
				list.Insert(0, curCard);
			}
		}
	}
}
