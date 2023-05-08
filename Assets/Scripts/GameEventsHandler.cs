using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventsHandler
{
	public static event Action onWin;
	public static event Action onLose;
	public static event Action onRestartGame;
	public static event Action onNextLevel;
	public static event Action<int, int> onUpdateCurrency;



	public static void Win() {
		onWin?.Invoke();
	}

	public static void Lose() {
		onLose?.Invoke();
	}
	
	public static void RestartGame() {
		onRestartGame?.Invoke();
	}

	public static void NextLevel() {
		onNextLevel?.Invoke();
	}

	public static void UpdateCurrency(int currency, int goldLeft) {
		onUpdateCurrency?.Invoke(currency, goldLeft);
	}
}
