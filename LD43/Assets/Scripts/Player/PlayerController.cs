using EZCameraShake;
using UnityEngine;
using Homebrew;

public class PlayerController : MonoBehaviour {

	public static PlayerController Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	[Foldout("Jump Data", true)]
	public float jumpHeight;

	public float fallMultiplier;
	public float lowJumpMultiplier;
	
	public bool grounded;
	
	public Transform groundPoint;					// Collision point

	[Foldout("Miscellaneous", true)]
	public float moveSpeed;
	public float collisionRadius;	

	public LayerMask collideableLayers;

	private Vector2 input;
	private Rigidbody2D rb2D;

	void Start() {

		rb2D = GetComponent<Rigidbody2D>();

	}

	void Update() {

		input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		grounded = IsColliding(groundPoint);

		Move();

	}

	void Move() {
		
		var gm = GameManager.Instance;
		
		if (gm != null) {
			if (gm.isSlowMo) return;
		}

		rb2D.velocity = new Vector2(input.x * moveSpeed, rb2D.velocity.y);

	}

	void FixedUpdate() {

		Jump();

	}

	void Jump() {

		if (Input.GetKeyDown(KeyCode.Space) && grounded) {

			rb2D.velocity = Vector2.up * jumpHeight;

		}

		if (rb2D.velocity.y < 0) {

			rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

		} else if (rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {

			rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

		}

	}

	bool IsColliding(Transform point) {

		return Physics2D.OverlapCircle(point.position, collisionRadius, collideableLayers);

	}

	void OnDrawGizmos() {

		Gizmos.DrawWireSphere(groundPoint.position, collisionRadius);

	}

}
