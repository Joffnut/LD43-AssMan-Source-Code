using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour {

	public static AmmoUI Instance;
	void Awake() {

		if (Instance == this) {
			return;
		}

		Instance = this;

	}

	public RectTransform ammoBarParent;
	public GameObject ammoBarPrefab;

	public List<GameObject> ammoBars;

	public void EnableAmmoBarParent() {

		ammoBarParent.gameObject.SetActive(true);

	}

	public void DisableAmmoBarParent() {

		ammoBarParent.gameObject.SetActive(false);

	}

	public void AddAmmoBar(int amount) {

		for (int i = 0; i < amount; i++) {

			GameObject bar = Instantiate(ammoBarPrefab, transform.position, Quaternion.identity);
			bar.transform.SetParent(ammoBarParent, false);

			ammoBars.Add(bar);

		}

	}

	public IEnumerator RemoveAmmoBar(int amount) {

		if (ammoBars.Count >= amount) {

			for (int i = 0; i < amount; i++) {

				var bar = ammoBars[ammoBars.Count - 1].GetComponent<AmmoBar>();
				if (bar != null) bar.RemoveBar();	// Plays an animation

				yield return new WaitForSeconds(0.3f);

				ammoBars.RemoveAt(ammoBars.Count - 1);

			}

		}

	}

}
