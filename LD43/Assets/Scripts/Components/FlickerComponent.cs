using UnityEngine;
using Homebrew;

public class FlickerComponent : MonoBehaviour {

	[Foldout("Flicker Data", true)]
	public float flickerClamp;
	public float flickerFreq;

	private Vector3 originalSize;

	void Start() {

		originalSize = transform.localScale;

	}

	void Update() {

		transform.localScale = ExtraVector.Flicker(originalSize, flickerClamp, flickerFreq);

	}

}
