using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable {

	public int healthAmount;
	protected int currentHealth;

	public virtual void Start() {

		currentHealth = healthAmount;

	}

	public virtual void TakeDamage(int dmg) {

		currentHealth -= dmg;

		if (currentHealth <= 0) Die();

	}

	public virtual void Die() {

		Destroy(gameObject);

	}

}
