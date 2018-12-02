using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string tutorialSceneName;
	public string firstLevel;

	public void LoadFirstLevel() {

		StartCoroutine(SceneTransition.Instance.LoadTargetScene(firstLevel));

	}

	public void LoadTutorialLevel() {

		StartCoroutine(SceneTransition.Instance.LoadTargetScene(tutorialSceneName));

	}

	public void Quit() {

		Application.Quit();

	}

}
