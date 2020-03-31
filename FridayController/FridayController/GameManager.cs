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

			AgingCardPile.AddCardList(hardCards);
			AgingCardPile.AddCardList(unhardCards);
		}

		private void InitHazardCard()
		{
			HazardCardPile.AddCardList(ConfigDataManager.GetInstance().GetHazardCards());
			HazardCardPile.ShuffleCards();
		}

	}

	public class CardPile<T> where T : class
	{
		private List<T> _cardPile = new List<T>();

		public T DrawOnce()
		{
			T card;
			if (_cardPile != null && _cardPile.Count != 0)
			{
				card = _cardPile[0];
				_cardPile.Remove(card);
				return card;
			}

			return null;
		}

		public void AddCard(T card)
		{
			_cardPile.Add(card);
		}

		public void AddCardList(List<T> cards)
		{
			_cardPile.AddRange(cards);
		}

		public List<T> GetPile()
		{
			return _cardPile;
		}

		public void PileClear()
		{
			_cardPile.Clear();
		}

		/// <summary>
		/// 洗牌
		/// </summary>
		public void ShuffleCards()
		{
			Random random = new Random();
			for (int i = 0; i < _cardPile.Count; i++)
			{
				var curCard = _cardPile[random.Next(i, _cardPile.Count)];
			}

		}

	}

}
