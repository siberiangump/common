namespace Common.ActionWraping
{
	using System.Collections.Generic;
	using System;

	public class ActionChainPlayer
	{
		private Dictionary<List<Action<Action>>, short> ChainsIndex = new Dictionary<List<Action<Action>>, short>();

		public void ExecuteChain(List<Action<Action>> chain)
		{
			if (ChainsIndex.ContainsKey(chain))
				return;
			ChainsIndex.Add(chain, -1);
			ExecuteNext(chain);
		}

		private void ExecuteNext(List<Action<Action>> chain)
		{
			ChainsIndex[chain]++;
			if (ChainsIndex[chain] == chain.Count - 1)
			{
				chain[ChainsIndex[chain]](EndEmptyCallback);
				ChainsIndex.Remove(chain);
				return;
			}
			chain[ChainsIndex[chain]](() => ExecuteNext(chain));
		}

		private void EndEmptyCallback() { }
	}

	public sealed class ActionChain : List<Action<Action>> { }
}