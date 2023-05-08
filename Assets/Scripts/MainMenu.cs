using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[SerializeField] GameObject buttonsLayout;
	[SerializeField] GameObject levelsScreen;
	[SerializeField] GameObject settingsScreen;

    public void SelectLevels() {
		buttonsLayout.SetActive(false);
		levelsScreen.SetActive(true);
	}

	public void Settings() {
		buttonsLayout.SetActive(false);
		settingsScreen.SetActive(true);
	}

    public void Back() {
		levelsScreen.SetActive(false);
		settingsScreen.SetActive(false);
		buttonsLayout.SetActive(true);
	}
	
	public void Quit() {
		Application.Quit();
	}
}
