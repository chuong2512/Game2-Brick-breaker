using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStar : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("ball")) {
			PlayerPrefs.SetInt ("numberOfStars", PlayerPrefs.GetInt ("numberOfStars") + 1);
			GameObject.Find ("numberOfStarsText").GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();
			GameObject.Find ("starCollectedSound").GetComponent<AudioSource> ().Play ();

			if (PlayerPrefs.GetInt ("numberOfStars") - PlayerPrefs.GetInt ("starsSpent") >= 1000) {
				if (PlayerPrefs.GetInt ("collect1000Stars") != 1) {
					PlayerPrefs.SetInt ("collect1000Stars", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("collect 1000 stars");
				}
			}

			Destroy (this.gameObject);
		}
	}
}
