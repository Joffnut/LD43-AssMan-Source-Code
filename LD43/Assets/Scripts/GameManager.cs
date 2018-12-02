using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	void Awake() {

		if (Instance == null) {
			
			Instance = this;
			DontDestroyOnLoad(transform.gameObject);

		} else if (Instance != this) {
			
			Destroy(this.gameObject);	
			return;
		
		}

	}

	public bool isSlowMo;

	public GameObject player;

	void Start() {

		if (player == null) {

			player = GameObject.FindGameObjectWithTag("Player");

		}

	}

	public GameObject GetPlayer() {

		if (player == null) return null;
		return player;

	}

	public void Restart() {

		StartCoroutine(SceneTransition.Instance.LoadTargetScene(SceneManager.GetActiveScene().name));

	}

}
