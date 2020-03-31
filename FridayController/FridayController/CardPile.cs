using System;
using System.Collections.Generic;
using System.Text;

namespace FridayController
{
	public class CardPile<T> where T : class
	{
		private List<T> _cardPile = new List<T>();

		/// <summary>
		/// 抽一张牌
		/// </summary>
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

		/// <summary>
		/// 插入一张牌到顶部
		/// </summary>
		public void InsertCardFirst(T card)
		{
			_cardPile.Insert(0, card);
		}

		/// <summary>
		/// 插入一张牌到底部
		/// </summary>
		/// <param name="card"></param>
		public void InsertCardLast(T card)
		{
			_cardPile.Insert(_cardPile.Count, card);
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
				_cardPile.Remove(curCard);
				InsertCardFirst(curCard);
			}
		}

	}
}
