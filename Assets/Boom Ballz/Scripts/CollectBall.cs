using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("ball")) {
			GameObject.Find ("ballCollectSound").GetComponent<AudioSource> ().Play ();
			Vars.newBalls++;

			PlayerPrefs.SetInt ("numberOfBallsCollected", PlayerPrefs.GetInt ("numberOfBallsCollected") + 1);
			if (PlayerPrefs.GetInt ("numberOfBallsCollected") >= 1000) {
				if (PlayerPrefs.GetInt ("collect1000balls") != 1) {
					PlayerPrefs.SetInt ("collect1000balls", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("collect 1000 balls");
				}
			}

			Destroy (this.gameObject);
		}
	}
}
