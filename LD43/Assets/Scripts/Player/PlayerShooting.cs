using EZCameraShake;
using UnityEngine;
using Homebrew;

public class PlayerShooting : MonoBehaviour {

	public AudioClip shootClip;
	private AudioSource audio;

	[Foldout("Thrust Shooting Data", true)]
	public float defaultThrustAmount;
	public float maxThrustAmount;
	private float thrustAmount;

	public float sizeDecreaseByShot;
	public Transform objectToScaleDown;

	[Tooltip("The speed at which we want to increase the thrust amount when holding space")]
	public float thrustChargeSpeed;

	public float startCooldown;
	private float cooldownTimer;

	public Transform firePoint;

	public GameObject thrustProjectile;
	public GameObject thrustParticle;

	[Foldout("SlowMo Data", true)]
	[Range(0f, 1f)] public float slowMoTimeScale = 0.2f;
	public float slowMoDuration;
	private float slowMoTimer;

	[Foldout("Rotation Data", true)]
	[Tooltip("The speed at which the player will rotate (in slowMo)")]
	public float rotationSpeed;

	[Foldout("Ammo Data", true)]
	public int startAmmoAmount;
	private int ammoAmount;

	[Foldout("Camera Shake Data", true)]
	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;

	private Rigidbody2D rb2D;

	void Start() {

		audio = GetComponent<AudioSource>();

		slowMoTimer = slowMoDuration;
		ammoAmount = startAmmoAmount;

		cooldownTimer = startCooldown;

		if (AmmoUI.Instance != null) {
		
			AmmoUI.Instance.AddAmmoBar(startAmmoAmount);
		
		}

		ResetThrustAmountToDefault();
		rb2D = GetComponent<Rigidbody2D>();

	}

	void Update() {

		AddThrustAndShoot();
		DecrementCoolDownTimer();

	}
	
	public void AddAmmo(int amount) {

		ammoAmount += amount;
		AmmoUI.Instance.AddAmmoBar(amount);

	}

	void IncrementThrustAmount() {

		if (thrustAmount < maxThrustAmount) {

			thrustAmount += thrustChargeSpeed * Time.deltaTime;

		}

	}

	void ResetThrustAmountToDefault() {

		thrustAmount = defaultThrustAmount;

	}

	void DecrementCoolDownTimer() {

		if (cooldownTimer > 0f) {

			cooldownTimer -= Time.deltaTime;

		}

	}

	void AddThrustAndShoot() {

		if (cooldownTimer > 0f) return;

		if (ammoAmount > 0) {
		
			if (Input.GetKey(KeyCode.LeftShift)) {

				IncrementThrustAmount();

			}

			if (Input.GetKeyUp(KeyCode.LeftShift)) {

				audio.clip = shootClip;
				audio.Play();

				CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);

				SlowMotion.RemoveSlowMo();

				SlowMoUI.Instance.CloseSlowMoBar();
				SlowMoUI.Instance.SetFillAmount(1f);

				slowMoTimer = slowMoDuration;

				rb2D.AddForce(transform.up * thrustAmount);
					
				SpawnProjectile();
				SpawnThrustParticle();

				ResetThrustAmountToDefault();
				DepleteAmmo();

				var scale = objectToScaleDown.localScale;

				scale.x -= sizeDecreaseByShot;
				scale.y -= sizeDecreaseByShot;
				scale.z -= sizeDecreaseByShot;

				objectToScaleDown.localScale = scale;

				cooldownTimer = startCooldown;

			}

		}

		SlowMotionHandler();

	}	
	
	void SlowMotionHandler() {

		if (Input.GetKeyDown(KeyCode.LeftShift) && ammoAmount > 0) {

			SlowMotion.AddSlowMo(slowMoTimeScale);
			SlowMoUI.Instance.OpenSlowMoBar();

		}

		// Remove slowMo after duration expires
		if (Input.GetKey(KeyCode.LeftShift) && ammoAmount > 0) {

			PlayerRotation();

			if (slowMoTimer > 0f) {

				slowMoTimer -= Time.unscaledDeltaTime;
				SlowMoUI.Instance.SetFillAmount(slowMoTimer / slowMoDuration);

			} else {

				SlowMotion.RemoveSlowMo();
				SlowMoUI.Instance.CloseSlowMoBar();

			}

		}

	}

	void PlayerRotation() {

		float input = Input.GetAxisRaw("Horizontal");

		if (input > 0f) {

			transform.Rotate(-Vector3.forward * rotationSpeed * Time.unscaledDeltaTime);

		}

		if (input < 0f) {

			transform.Rotate(Vector3.forward * rotationSpeed * Time.unscaledDeltaTime);

		}
	
	}

	void DepleteAmmo() {

		if (AmmoUI.Instance != null) {

			StartCoroutine(AmmoUI.Instance.RemoveAmmoBar(1));

		}

		ammoAmount--;

	}
	
	void SpawnThrustParticle() {

		var particle = Instantiate(thrustParticle, firePoint.position, Quaternion.identity);
		particle.transform.parent = transform;

	}

	void SpawnProjectile() {

		var obj = Instantiate(thrustProjectile, firePoint.position, Quaternion.identity);
		var projectile = obj.GetComponent<Projectile>();

		if (projectile != null) {

			projectile.SetMoveDirection(-firePoint.up);

		}

	}

}
