using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;

	private Vector2 moveDirection;
	private Rigidbody2D rb2D;

	void Start() {

		rb2D = GetComponent<Rigidbody2D>();

	}

	void Update() {

		rb2D.velocity = moveDirection * speed;

	}

	public void SetMoveDirection(Vector2 dir) {

		moveDirection = dir;

	}

}
