using UnityEngine;
using Homebrew;

public class FlyBehaviour : MonoBehaviour {

	[Tooltip("The radius in which the fly can move")]
	[Foldout("Fly Data", true)]
	public float flyRadius;
	public float flySpeed;

	private float waitTime;
	public Vector2 waitTimeRange;

	private Vector2 targetPosition;
	private Vector2 startPosition;

	[Foldout("Hover Data", true)]
	public float hoverClamp;
	public float hoverFreq;

	public GameObject hoverGO;

	void Start() {

		startPosition = transform.position;
		targetPosition = GetNewTargetPosition();

		waitTime = GetNewWaitTime();

	}

	void Update() {

		if (Time.timeScale <= 0f) return;

		Hover();

		if (Vector2.Distance(transform.position, targetPosition) < 0.1f) {

			if (waitTime > 0f) {
			
				waitTime -= Time.deltaTime;
			
			} else {

				targetPosition = GetNewTargetPosition();
				waitTime = GetNewWaitTime();
			
			}

		} else {

			transform.position = Vector3.Slerp(transform.position, targetPosition, flySpeed * Time.deltaTime);

		}


	}

	void Hover() {

		hoverGO.transform.position = new Vector3(

			hoverGO.transform.position.x,
			hoverGO.transform.position.y + ExtraFloat.GetTimeSin(hoverClamp, hoverFreq),
			hoverGO.transform.position.z

		);

	}

	float GetNewWaitTime() {

		return Random.Range(waitTimeRange.x, waitTimeRange.y);

	}

	Vector3 GetNewTargetPosition() {

		Vector2 randomPos =  Random.insideUnitCircle * flyRadius;
		return startPosition + randomPos;

	}

	void OnDrawGizmos() {

		Gizmos.DrawWireSphere(transform.position, flyRadius);

	}

}
