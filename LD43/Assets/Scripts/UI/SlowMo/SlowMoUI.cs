using UnityEngine.UI;
using UnityEngine;

public class SlowMoUI : MonoBehaviour {

	public static SlowMoUI Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	public Animator animator;
	public Image fillImage;

	public void SetFillAmount(float amount) {

		fillImage.fillAmount = amount;

	}

	public void OpenSlowMoBar() {

		animator.SetBool("Close", false);
		animator.SetBool("Open", true);

	}

	public void CloseSlowMoBar() {

		animator.SetBool("Open", false);
		animator.SetBool("Close", true);

	}

}
