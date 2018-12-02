using UnityEngine;
using EZCameraShake;
using Homebrew;

public class PlayerHealth : HealthBase {

	public static PlayerHealth Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	public AudioClip deathClip;
	private AudioSource audio;

	public BodyPartManager bodyParts;
	public Transform gfxObject;

	[Foldout("Camera Shake Data", true)]
	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;

	public override void Start() {

		base.Start();

		audio = GetComponent<AudioSource>();

	}

	void Update() {

		if (gfxObject.localScale.x <= 0.4f && gfxObject.localScale.y <= 0.4f && gfxObject.localScale.z <= 0.4f) {

			Die();

		}

	}

	public override void Die() {
		
		audio.clip = deathClip;
		audio.Play();

		SlowMotion.RemoveSlowMo();
		bodyParts.DisassembleParts();

		CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);

		var scripts = GetComponents(typeof(MonoBehaviour));

		foreach(MonoBehaviour script in scripts) {
			Destroy(script);
		}

	}

}
