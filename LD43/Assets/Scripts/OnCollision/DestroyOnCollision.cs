using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

	public LayerMask collideableLayers;

	void OnCollisionEnter2D(Collision2D col) {

		if (collideableLayers == (collideableLayers | (1 << col.gameObject.layer))) {

			Destroy(gameObject);
		
		}

	}

}
