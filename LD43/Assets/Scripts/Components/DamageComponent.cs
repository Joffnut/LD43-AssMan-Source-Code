using UnityEngine;

public class DamageComponent : MonoBehaviour {

	public int damageAmount;

	public LayerMask collideableLayers;

	void OnCollisionEnter2D(Collision2D col) {

		DealDamage(col.gameObject);

	} 

	public virtual void DealDamage(GameObject obj) {
		
		if (obj == this.gameObject) return;

		IDamageable health = obj.GetComponent<IDamageable>();

		if (health != null) {
			health.TakeDamage(damageAmount);
		}

	}

}
