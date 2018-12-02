using System.Collections.Generic;
using UnityEngine;
using Homebrew;

public class BodyPartManager : MonoBehaviour {

	[Foldout("Body Part Data", true)]
	[Tooltip("Force to add to bodyParts once disassembled")]
	public float disassembleForce;

	public List<GameObject> bodyParts;

	public void DisassembleParts() {

		for (int i = 0; i < bodyParts.Count; i++) {

			Rigidbody2D rb = bodyParts[i].GetComponent<Rigidbody2D>();
			if (rb == null) bodyParts[i].AddComponent<Rigidbody2D>();

			DistanceJoint2D joint = bodyParts[i].GetComponent<DistanceJoint2D>();
			if (joint != null) Destroy(joint);

			bodyParts[i].transform.parent = null;

			AddForceToObject(bodyParts[i]);

		}

	}

	void AddForceToObject(GameObject obj) {

		if (obj == null) return;

		Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
		if (rb == null) return;

		Vector3 forceDirection = transform.position - obj.transform.position;
		rb.AddForce(forceDirection * disassembleForce);


	}

}
