using UnityEngine;
using Homebrew;

public class ParticleOnCollision : MonoBehaviour {

	[Tooltip("Only spawn particle if the magnitude is greater than spawnMagnitude")]
	[Foldout("Magnitude Spawn Data")] public bool spawnOverMagnitude;
	
	[Foldout("Magnitude Spawn Data")] public float spawnMagnitude;

	public GameObject particlePrefab;

	private Rigidbody2D rb2D;
	public LayerMask collideableLayers;

	void Start() {

		if (spawnOverMagnitude) {

			rb2D = GetComponent<Rigidbody2D>();

		}

	}

	void OnCollisionEnter2D(Collision2D col) {

		if (spawnOverMagnitude) {

			if (rb2D.velocity.magnitude >= spawnMagnitude) {

				SpawnParticle(col.gameObject.layer, col.contacts[0].point);

			}

		} else {

			SpawnParticle(col.gameObject.layer, col.contacts[0].point);

		}

	}

	void SpawnParticle(int layer, Vector2 spawnPoint) {

		if (collideableLayers == (collideableLayers | (1 << layer))) {

			Instantiate(particlePrefab, spawnPoint, Quaternion.identity);

		}

	}

}
