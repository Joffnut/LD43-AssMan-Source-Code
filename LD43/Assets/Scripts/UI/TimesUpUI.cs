using UnityEngine;

public class TimesUpUI : MonoBehaviour {

	public static TimesUpUI Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	public string mainMenuName;

	public GameObject uiParent;

	void Start() {

		uiParent.SetActive(false);

	}

	public void LoadMenu() {

		StartCoroutine(SceneTransition.Instance.LoadTargetScene(mainMenuName));

	}

	public void Quit() {

		Application.Quit();

	}

}
