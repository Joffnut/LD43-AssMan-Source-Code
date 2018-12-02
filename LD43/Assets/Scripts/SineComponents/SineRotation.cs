using UnityEngine;
using Homebrew;

public class SineRotation : MonoBehaviour {

	public float freq;
	public float clamp;

	private Vector3 originalRotation;

	[Foldout("Rotation Booleans Data", true)]
	public bool rotateX;
	public bool rotateY;
	public bool rotateZ;

	void Start() {

		originalRotation = transform.eulerAngles;

	}

	void Update() {

		if (rotateX) {

			transform.eulerAngles = new Vector3(
				
				originalRotation.x + ExtraFloat.GetTimeSin(clamp, freq),
				transform.eulerAngles.y,
				transform.eulerAngles.z
			
			);

		}

		if (rotateY) {

			transform.eulerAngles = new Vector3(

				transform.eulerAngles.x,				
				originalRotation.y + ExtraFloat.GetTimeSin(clamp, freq),
				transform.eulerAngles.z
			
			);

		}

		if (rotateZ) {

			transform.eulerAngles = new Vector3(
				
				transform.eulerAngles.x,
				transform.eulerAngles.y,
				originalRotation.z + ExtraFloat.GetTimeSin(clamp, freq)

			);

		}

	}

}
