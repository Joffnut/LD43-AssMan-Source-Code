using UnityEngine;
using System;

public static class Explosion2D {

	/// <summary> Adds an explosion force depending on origin and rb2D.position </summary>
	/// <param name="rb2D"> The rigibody of the object we want to add explosion force to </param>
	/// <param name="origin"> The origin of the explosion </param>
	/// <param name="force"> The amount of force we want to add </param>
	public static void AddExplosionForce2D(this Rigidbody2D rb2D, Transform origin, float force) {

		var explosionDirection = rb2D.position - (Vector2)origin.position;
		rb2D.AddForce(explosionDirection * force);

	}

}

public static class SlowMotion {

	/// <summary> Enables a smooth slowmotion by changing timeScale and fixedDeltaTime </summary>
	/// <param name="targetTimeScale"> The amount of slow motion you want, higher = slower slow motion </param> 
	public static void AddSlowMo(float targetTimeScale) {

		Time.timeScale = targetTimeScale;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;

		GameManager.Instance.isSlowMo = true;

	}

	/// <summary> Removes slowmotion if slowmotion was enabled </summary>
	public static void RemoveSlowMo() {

		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f;

		GameManager.Instance.isSlowMo = false;

	}

}

public static class ExtraQuaternion {

	/// <summary> A 2D version of LookAt, Rotates on z axis </summary>
	public static Quaternion LookAt2D(Vector2 forward) {
		
		float angle = Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis(angle, Vector3.forward);
		
	}

}

public static class ExtraVector {

	/// <summary> Let's you lerp eulerangles without it going from -1 to 359 etc </summary>
	/// <param name="startAngle"> This is the starting eulerangles </param>
	/// <param name="finishAngle"> The angle we want the eulerangle to have </param>
	/// <param name="t"> The speed at which we want to lerp between variables </param>
	public static Vector3 AngleLerp(Vector3 startAngle, Vector3 finishAngle, float t) {

		float xLerp = Mathf.LerpAngle(startAngle.x, finishAngle.x, t);
		float yLerp = Mathf.LerpAngle(startAngle.y, finishAngle.y, t);
		float zLerp = Mathf.LerpAngle(startAngle.z, finishAngle.z, t);

		Vector3 lerped = new Vector3(xLerp, yLerp, zLerp);
		return lerped;

	}

	/// <summary> This changes a Vector3 by increasing and decreasing it using Mathf.Sin and Time.time </summary>
	/// <param name="originalSize"> The original size of the Vector3 </param>
	/// <param name="clamp"> The clamp of the Vectors scale, the lower the clamp the lower the Vector will scale </param>
	/// <param name="freq"> The frequency at which the scale should change </param>
	public static Vector3 Flicker(Vector3 originalSize, float clamp, float freq) {

		Vector3 flickerVector = new Vector3(

			originalSize.x + (clamp * (Mathf.Sin(Time.time * freq))),
			originalSize.y + (clamp * (Mathf.Sin(Time.time * freq))),
			originalSize.z + (clamp * (Mathf.Sin(Time.time * freq)))

		);

		return flickerVector;

	}

}

public static class ExtraFloat {

	/// <summary> Returns a float that changes by Mathf.Sin(Time.time), the float will fluctuate at a rate depending on fps </summary>
	/// <param name="clamp"> The clamp of the Vectors scale, the lower the clamp the lower the Vector will scale </param>
	/// <param name="freq"> The frequency at which the scale should change </param>
	public static float GetTimeSin(float clamp, float freq) {

		return clamp * (Mathf.Sin(Time.time * freq));

	}

}
