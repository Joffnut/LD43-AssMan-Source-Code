using UnityEngine;

public class AmmoBar : MonoBehaviour {

	private bool removeAnimationDone;

	public Animator animator;

	public void RemoveBar() {

		animator.SetBool("Remove", true);

	}

	public void DestroyThis() {

		Destroy(this.gameObject);

	}

}
