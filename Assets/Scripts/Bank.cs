using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
	[SerializeField] int startingBalance = 150;
	[SerializeField] int currentBalance;

	[SerializeField] int levelGoldGoal = 1000;
	public int CurrentBalance { get { return currentBalance; } }


	[SerializeField] TextMeshProUGUI displayBalance;

	private void Awake() {
		currentBalance = startingBalance;
		UpdateCurrency();
	}

	public void Deposit(int amount) {
		currentBalance += Mathf.Abs(amount);
		levelGoldGoal -= amount;
		SoundManager.instance.PlaySound("gold");
		UpdateCurrency();
		if(levelGoldGoal == 0) {
			GameEventsHandler.Win();
		}
	}

	public void Withdraw(int amount) {
		currentBalance -= Mathf.Abs(amount);
		if(currentBalance < 0) {
			GameEventsHandler.Lose();
		}
		UpdateCurrency();
	}

	void UpdateCurrency() {
		GameEventsHandler.UpdateCurrency(currentBalance, levelGoldGoal);
	}
}
