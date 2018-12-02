using EZCameraShake;
using UnityEngine;
using Homebrew;

public class ShakeOnCollision : MonoBehaviour {

	[Foldout("Camera Shake Data", true)]
	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;

	[Foldout("Magnitude Shake Data")] public float spawnMagnitude;
	[Foldout("Magnitude Shake Data")] public bool spawnOverMagnitude;

	private Rigidbody2D rb2D;
	public LayerMask collideableLayers;

	void Start() {

		if (spawnOverMagnitude) {

			rb2D = GetComponent<Rigidbody2D>();

		}

	}

	void OnCollisionEnter2D(Collision2D col) {

		if (collideableLayers == (collideableLayers | (1 << collideableLayers))) {

			if (spawnOverMagnitude) {

				if (rb2D.velocity.magnitude >= spawnMagnitude) {

					CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);

				}

			} else {

				CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);

			}

		}

	}

}
