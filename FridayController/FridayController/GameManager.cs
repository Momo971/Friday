using System;
using System.Collections.Generic;
using System.Text;
using FridayCard;

namespace FridayController
{
	public class GameManager : Singleton<GameManager>
	{
		private GAME_PROGRESS _gameProgress;

		//起始牌库
		public CardPile<FightingCard> PlayerCardPile = new CardPile<FightingCard>();
		//衰老牌库
		public CardPile<AgingCard> AgingCardPile = new CardPile<AgingCard>();
		//冒险牌库
		public CardPile<HazardCard> HazardCardPile = new CardPile<HazardCard>();
		//弃牌堆
		public CardPile<FightingCard> PlayerDiscardPile = new CardPile<FightingCard>();
		//冒险弃牌堆
		public CardPile<HazardCard> HazardDiscardPile = new CardPile<HazardCard>();

		public GameManager()
		{
			_gameProgress = GAME_PROGRESS.READY;
			InitCardPiles();
		}

		/// <summary>
		/// 游戏开始时，初始化所有牌堆
		/// </summary>
		private void InitCardPiles()
		{
			InitOriginCard();
			InitAgingCardPile();
			InitHazardCard();
			PlayerDiscardPile.PileClear();
			HazardCardPile.PileClear();
		}

		private void InitOriginCard()
		{
			foreach (var card in ConfigDataManager.GetInstance().GetOriginCards())
			{
				PlayerCardPile.AddCard(card);
			}
			PlayerCardPile.ShuffleCards();
		}

		private void InitAgingCardPile()
		{
			var hardCards = ConfigDataManager.GetInstance().GetAgingCards().FindAll(card => card.IsHard);
			var unhardCards = ConfigDataManager.GetInstance().GetAgingCards().FindAll(card => !card.IsHard);

			GeneralUtils.ShuffleList<AgingCard>(hardCards);
			GeneralUtils.ShuffleList<AgingCard>(unhardCards);

			AgingCardPile.AddCardList(unhardCards);
			AgingCardPile.AddCardList(hardCards);
		}

		private void InitHazardCard()
		{
			HazardCardPile.AddCardList(ConfigDataManager.GetInstance().GetHazardCards());
			HazardCardPile.ShuffleCards();
		}

	}


}
