using UnityEngine;

public class RestartUI : MonoBehaviour {

	public void Restart() {

		var pauseMenu = PauseMenu.Instance;
		if (pauseMenu != null) pauseMenu.UnPause(); 

		GameManager.Instance.Restart();

	}

}
