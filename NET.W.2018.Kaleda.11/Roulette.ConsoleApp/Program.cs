using System.Collections.Generic;
using Roulette.Listeners;

namespace Roulette.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var roulette = new Roulette();

			var listeners = new List<IRouletteSpinListener>
			{
				new BlackNumbersListener(),
				new RedNumbersListener(),
				new EvenNumbersListener(),
				new OddNumbersListener(),
				new NumberListener(0)
			};

			foreach (var listener in listeners)
				listener.Subscribe(roulette);

			for (int i = 0; i < 50; i++)
				roulette.Spin();
		}
	}
}
