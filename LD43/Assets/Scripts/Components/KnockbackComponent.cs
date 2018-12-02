using EZCameraShake;
using UnityEngine;
using Homebrew;

public class KnockbackComponent : MonoBehaviour {

	public float knockbackAmount;

	public LayerMask knockbackableLayers;

	[Foldout("Camera Shake Data", true)]
	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;

	void OnCollisionEnter2D(Collision2D col) {
		
		AddKnockBack(col.gameObject);
		CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);

	}

	public virtual void AddKnockBack(GameObject obj) {

		Rigidbody2D rb2D = obj.GetComponent<Rigidbody2D>();
		Vector2 forceDirection = obj.transform.position - transform.position;

		if (rb2D != null) {

			rb2D.AddForce(forceDirection * knockbackAmount);

		}

	}

}
