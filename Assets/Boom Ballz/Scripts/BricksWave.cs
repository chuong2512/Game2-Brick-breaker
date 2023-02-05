using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksWave : MonoBehaviour {

	private int wave = 1;
	private Rigidbody2D rb;
	private TextMesh waveText;
	private AudioSource brickHitSound;
	void Start() {
		brickHitSound = GameObject.Find ("brickHitSound").GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		if (transform.Find ("brickWaveText") != null) {
			waveText = transform.Find ("brickWaveText").GetComponent<TextMesh> ();

			if (Vars.level < 10) {
				wave = Random.Range (1, 3);
			} else {
				wave = Random.Range ((int)(Vars.level / 5), (int)(Vars.level / 2));
			}
			waveText.text = wave.ToString ();
		}


		if(this.gameObject.name.Contains("brick")) {
			ColorBrick ();
		}
	}
		
	void OnCollisionEnter2D(Collision2D col) {
		if (!brickHitSound.isPlaying) {
			brickHitSound.Play ();
		}
		wave--;
		ColorBrick ();
		waveText.text = wave.ToString();
		if (wave <= 0) {

			PlayerPrefs.SetInt ("numberOfBricksDestroyed", PlayerPrefs.GetInt ("numberOfBricksDestroyed") + 1);
			if (PlayerPrefs.GetInt ("numberOfBricksDestroyed") >= 100) {
				if (PlayerPrefs.GetInt ("destroy100bricks") != 1) {
					PlayerPrefs.SetInt ("destroy100bricks", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("destroy 100 bricks");
				}
			}

			if (PlayerPrefs.GetInt ("numberOfBricksDestroyed") >= 1000) {
				if (PlayerPrefs.GetInt ("destroy1000bricks") != 1) {
					PlayerPrefs.SetInt ("destroy1000bricks", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("destroy 1000 bricks");
				}
			}

			if (PlayerPrefs.GetInt ("numberOfBricksDestroyed") >= 10000) {
				if (PlayerPrefs.GetInt ("destroy10000bricks") != 1) {
					PlayerPrefs.SetInt ("destroy10000bricks", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("destroy 10000 bricks");
				}
			}

			Destroy (this.gameObject);
		}
	}

	public void ColorBrick() {
		if (wave <= 30) {
			GetComponent<SpriteRenderer> ().color = new Color (1, (1 - ((float)wave / 30)), 0);
		} else if (wave <= 60) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 0, (float)(wave - 30) / 30);
		} else {
			float redColorValue = 1-(((float)wave - 60) / 30);
			if (redColorValue < 1) {
				GetComponent<SpriteRenderer> ().color = new Color (redColorValue, 0, 1);
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 1);
			}
		}
	}
}
