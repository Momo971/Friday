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
	/// 游戏进程
	/// </summary>
	public enum GAME_PROGRESS
	{
		READY, //准备
		GREEN,
		YELLOW,
		RED,
		DUEL //决战
	}
}