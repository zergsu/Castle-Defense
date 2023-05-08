using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
	[SerializeField] int levelIndex;

	public void OpenScene() {
		SceneManager.LoadScene(levelIndex);
	}
}
