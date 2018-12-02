using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour {

	[Tooltip("The radius at which the flag can detect the player")]
	public float radius;

	public string sceneName;

	private GameObject player;

	void Start() {

		player = PlayerController.Instance.gameObject;

	}

	void Update() {

		if (player != null) {

			if (Vector2.Distance(transform.position, player.transform.position) <= radius) {

				StartCoroutine(SceneTransition.Instance.LoadTargetScene(sceneName));

			}

		}

	}

	void OnDrawGizmos() {

		Gizmos.DrawWireSphere(transform.position, radius);

	}

}
