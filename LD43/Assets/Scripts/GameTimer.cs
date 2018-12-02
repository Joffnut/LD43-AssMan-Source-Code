using UnityEngine.UI;
using UnityEngine;

/// <summary> GameTimer handles how much time you have to complete a level </summary>
public class GameTimer : MonoBehaviour {

	[Tooltip("The time you have to complete the level")]
	public float maxLevelCompletionTime;
	private float startMaxCompletionTime;

	public Image timerFillImage;

	void Start() {

		startMaxCompletionTime = maxLevelCompletionTime;

	}

	void Update() {

		if (maxLevelCompletionTime > 0f) {
		
			maxLevelCompletionTime -= Time.deltaTime;
			timerFillImage.fillAmount = maxLevelCompletionTime / startMaxCompletionTime;
		
		} else {
			
			var health = PlayerHealth.Instance;
			if (health != null) {

				health.TakeDamage(health.healthAmount);

			}

			TimesUpUI.Instance.uiParent.SetActive(true);

		}

	}

}
