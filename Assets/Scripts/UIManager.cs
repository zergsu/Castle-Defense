using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject settingsScreen, buttonsLayout;
    public GameObject gameMenu;
    public GameObject loseScreen;
    public GameObject victoryScreen;

    [SerializeField] TextMeshProUGUI currencyText, goldLeftText;

    bool gamePaused = false;

	private void Awake() {
        GameEventsHandler.onUpdateCurrency += UpdateCurrency;
	}

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) && !loseScreen.activeInHierarchy && !victoryScreen.activeInHierarchy) {
            GameMenu();
        }
    }

    void GameMenu() {
        gamePaused = !gamePaused;
        gameMenu.SetActive(gamePaused);
		if (gamePaused) {
            Time.timeScale = 0;
		} else { Time.timeScale = 1; }
    }



    public void Resume() {
        gameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Settings() {
        buttonsLayout.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void LeaveGame() {
        SceneManager.LoadScene(0);
    }

    public void RestartGame() {
        GameEventsHandler.RestartGame();
	}

    public void NextLevel() {
        Time.timeScale = 1;
        GameEventsHandler.NextLevel();
	}

    public void BackToMenu() {
        settingsScreen.SetActive(false);
        buttonsLayout.SetActive(true);
    }

    void UpdateCurrency(int currency, int goldLeft) {
        currencyText.text = "Gold: " + currency;
        goldLeftText.text = "Gold Goal: " + goldLeft;
    }
}
