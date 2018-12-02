using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

	public static SceneTransition Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	public Animator transitionAnim;

	public IEnumerator LoadTargetScene(string sceneName) {

		transitionAnim.SetTrigger("End");

		yield return new WaitForSeconds(1.5f);

		SceneManager.LoadScene(sceneName);

	}

}
