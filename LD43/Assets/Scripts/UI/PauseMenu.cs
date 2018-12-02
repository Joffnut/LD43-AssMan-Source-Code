using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	public string menuSceneName;

	public bool isPaused;

	public GameObject pauseMenu;

	void Update() {

		if (Input.GetKeyDown(KeyCode.Escape)) {

			if (isPaused) {
				UnPause();
			} else {
				Pause();
			}

		}

	}

	public void Pause() {

		pauseMenu.SetActive(true);

		Time.timeScale = 0f;
		isPaused = true;

	}

	public void UnPause() {

		pauseMenu.SetActive(false);

		Time.timeScale = 1f;
		isPaused = false;

	}

	public void OpenMenu() {

		UnPause();
		StartCoroutine(SceneTransition.Instance.LoadTargetScene(menuSceneName));

	}

	public void Quit() {

		Application.Quit();

	}

}
