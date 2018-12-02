using UnityEngine;

public class BendableVegetation : MonoBehaviour {

	public float bendRotation = 15f;
	public float bendSpeed;

	public float startZRotation;

	public bool interactingWithObject;

	private Vector3 startRotation;
	private Vector3 targetRotation;

	public Transform objToRotate;

	public LayerMask collideableLayers;

	void Start() {

		startRotation = objToRotate.eulerAngles;
		startZRotation = objToRotate.eulerAngles.z;

	}

	void Update() {
		
		if (interactingWithObject) {

			objToRotate.eulerAngles = ExtraVector.AngleLerp(objToRotate.eulerAngles, targetRotation, bendSpeed * Time.deltaTime);

		} else {

			objToRotate.eulerAngles = ExtraVector.AngleLerp(objToRotate.eulerAngles, startRotation, bendSpeed * Time.deltaTime);

		}

	}

	void OnTriggerStay2D(Collider2D col) {

		if (collideableLayers == (collideableLayers | (1 << col.gameObject.layer))) {

			var direction = (transform.position - col.transform.position).normalized;
			int bendDirection = (col.transform.position.x >= transform.position.x) ? 1 : -1;
			
			float targetZRotation = bendRotation * bendDirection;		// Makes the variable negative or positive depending on the col's position
			targetRotation = new Vector3(0f, 0f, startZRotation + targetZRotation);

			interactingWithObject = true;

		}

	}

	void OnTriggerExit2D(Collider2D col) {

		if (collideableLayers == (collideableLayers | (1 << col.gameObject.layer))) {

			interactingWithObject = false;

		}

	}

}
