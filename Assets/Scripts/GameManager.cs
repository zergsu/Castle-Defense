using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] UIManager uiManager;

    void Awake() {
        GameEventsHandler.onRestartGame += RestartGame;
        GameEventsHandler.onLose += LoseGame;
        GameEventsHandler.onWin += WinGame;
        GameEventsHandler.onNextLevel += NextLevel;
    }

    void LoseGame() {
        SoundManager.instance.PlaySound("lose");
        uiManager.loseScreen.SetActive(true);
    }

    void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    void WinGame() {
        Time.timeScale = 0;
        SoundManager.instance.PlaySound("win");
        uiManager.victoryScreen.SetActive(true);
    }

    void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
