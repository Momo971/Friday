namespace FridayCard
{
	public enum SKILL_KIND
	{
		ADD_HP = 10001,
		EXTRAL_CARD,
		DESTROY,
		DOUBLE,
		COPY,
		BACK,
		SORT,
		EXCHANGE = 20001,
		BELOW_STACK,
		MINUS_HP = 30001,
		HIGHTEST_COMBAT,
		STOP,
		DOUBLE_COST = 40001,
		HALF_CARDS,
		REMAINING_HAZARD,
		AGING_COST,
		ADD_COMBAT
	}

	/// <summary>
	/// ��Ϸ����
	/// </summary>
	public enum GAME_PROGRESS
	{
		READY, //׼��
		GREEN,
		YELLOW,
		RED,
		DUEL //��ս
	}
}