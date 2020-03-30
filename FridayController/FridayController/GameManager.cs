using System;
using System.Collections.Generic;
using System.Text;
using FridayCard;

namespace FridayController
{
	class GameManager : Singleton<GameManager>
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

			foreach (var card in hardCards)
			{
				AgingCardPile.AddCard(card);
			}

			foreach (var card in unhardCards)
			{
				AgingCardPile.AddCard(card);
			}
		}

		private void InitHazardCard()
		{
			foreach (var card in ConfigDataManager.GetInstance().GetHazardCards())
			{
				HazardCardPile.AddCard(card);
			}
			HazardCardPile.ShuffleCards();
		}

	}

	class CardPile<T> where T : class
	{
		private List<T> _cardLibrary = new List<T>();

		public T DrawOnce()
		{
			T card;
			if (_cardLibrary != null && _cardLibrary.Count != 0)
			{
				card = _cardLibrary[0];
				_cardLibrary.Remove(card);
				return card;
			}

			return null;
		}

		public void AddCard(T card)
		{
			_cardLibrary.Add(card);
		}

		public List<T> GetPile()
		{
			return _cardLibrary;
		}

		public void PileClear()
		{
			_cardLibrary.Clear();
		}

		public void ShuffleCards()
		{
			//todo
		}

	}

}
