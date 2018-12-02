using UnityEngine;

public class TimeDestruction : MonoBehaviour {

	[Tooltip("Time until destruction of object")]
	public float lifeTime;

	void Start() {

		Destroy(gameObject, lifeTime);

	}

}
