using System;
using System.Collections.Generic;
using System.Text;

namespace FridayController
{
	class Player : Singleton<Player>
	{
		uint _helthPoint;
		uint _helthPointMax;

		public void InitPlayer()
		{
			_helthPoint = 20;
			_helthPointMax = 22;
		}

		public void HealHelth(uint value)
		{
			if (value <= 0) return;

			_helthPoint += value;

			if(_helthPoint >= _helthPointMax)
			{
				_helthPoint = _helthPointMax;
			}
		}

		public void DeductHelth(uint value)
		{
			if (value <= 0) return;

			_helthPoint -= value;

			if(_helthPoint <= 0)
			{
				GameManager.GetInstance().GameOver();
			}
		}
	}
}
