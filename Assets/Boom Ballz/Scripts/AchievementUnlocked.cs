using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUnlocked : MonoBehaviour {

	private GameObject achievement;
	private float timer = 0;
	private bool down = true;

	public Sprite collect1000Stars;
	public Sprite collect1000Balls;
	public Sprite destroy100Bricks;
	public Sprite destroy1000Bricks;
	public Sprite destroy10000Bricks;
	public Sprite play10Games;
	public Sprite play100Games;
	public Sprite play1000Games;
	public Sprite score100Points;
	public Sprite unlockAllBalls;
	public Sprite unlockFootballBall;
	public Sprite unlockGolfBall;

	void OnEnable () {
		achievement = Instantiate (Resources.Load<GameObject> ("achievementPanel"), new Vector2 (Vars.firstBallHitXPos, 7), Quaternion.identity);
	}

	public void NameOfTheAchievement(string name) {
		if (PlayerPrefs.GetInt ("currentLanguage") == 0) {
			achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = name;
		} else if (PlayerPrefs.GetInt ("currentLanguage") == 1) {
			achievement.transform.Find ("achievementUlnockedText").GetComponent<TextMesh> ().text = "OBIETTIVO SBLOCCATO:";
			if (name.Equals ("play 10 Games")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "gioca 10 partite";
			}
			if (name.Equals ("play 100 Games")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "gioca 100 partite";
			}
			if (name.Equals ("play 1000 Games")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "gioca 1000 partite";
			}
			if (name.Equals ("destroy 100 bricks")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "distruggere 100 mattoni";
			}
			if (name.Equals ("destroy 1000 bricks")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "distruggere 1000 mattoni";
			}
			if (name.Equals ("destroy 10000 bricks")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "distruggere 10000 mattoni";
			}
			if (name.Equals ("collect 1000 balls")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "raccogliere 1000 palline";
			}
			if (name.Equals ("collect 1000 stars")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "colleziona 1000 stelle";
			}
			if (name.Equals ("score 100 points")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "segna 100 punti";
			}
			if (name.Equals ("unlock football ball")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "sbloccare pallone da calcio";
			}
			if (name.Equals ("unlock golf ball")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "sbloccare la pallina da golf";
			}
			if (name.Equals ("unlock all balls")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "sblocca tutte le palle";
			}
		} else if (PlayerPrefs.GetInt ("currentLanguage") == 2) {
			achievement.transform.Find ("achievementUlnockedText").GetComponent<TextMesh> ().text = "OSVOJENA MEDALJA:";
			if (name.Equals ("play 10 Games")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "odigraj 10 partija";
			}
			if (name.Equals ("play 100 Games")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "odigraj 100 partija";
			}
			if (name.Equals ("play 1000 Games")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "odigraj 1000 partija";
			}
			if (name.Equals ("destroy 100 bricks")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "uništi 100 cigala";
			}
			if (name.Equals ("destroy 1000 bricks")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "uništi 1000 cigala";
			}
			if (name.Equals ("destroy 10000 bricks")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "uništi 10000 cigala";
			}
			if (name.Equals ("collect 1000 balls")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "sakupi 1000 lopti";
			}
			if (name.Equals ("collect 1000 stars")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "sakupi 1000 yveyda";
			}
			if (name.Equals ("score 100 points")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "osvoji 100 bodova";
			}
			if (name.Equals ("unlock football ball")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "otključaj fudbalsku loptu";
			}
			if (name.Equals ("unlock golf ball")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "otključaj lopticu za golf";
			}
			if (name.Equals ("unlock all balls")) {
				achievement.transform.Find ("nameOfAchievement").GetComponent<TextMesh> ().text = "otključaj sve lopte";
			}
		}
		if (name.Equals ("play 10 Games")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = play10Games;
		}
		if (name.Equals ("play 100 Games")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = play100Games;
		}
		if (name.Equals ("play 1000 Games")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = play1000Games;
		}
		if (name.Equals ("destroy 100 bricks")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = destroy100Bricks;
		}
		if (name.Equals ("destroy 1000 bricks")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = destroy1000Bricks;
		}
		if (name.Equals ("destroy 1000 bricks")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = destroy10000Bricks;
		}
		if (name.Equals ("collect 1000 balls")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = collect1000Balls;
		}
		if (name.Equals ("collect 1000 stars")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = collect1000Stars;
		}
		if (name.Equals ("score 100 points")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = score100Points;
		}
		if (name.Equals ("unlock football ball")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = unlockFootballBall;
		}
		if (name.Equals ("unlock golf ball")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = unlockGolfBall;
		}
		if (name.Equals ("unlock all balls")) {
			achievement.transform.Find ("achievementSprite").GetComponent<SpriteRenderer> ().sprite = unlockAllBalls;
		}

	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.01f) {
			timer = 0;
			if (down) {
				achievement.transform.localPosition = new Vector2 (0, achievement.transform.localPosition.y - 0.05f);
				if (achievement.transform.localPosition.y <= 4.3f) {
					down = false;
					timer = -5;
				}
			} else {
				achievement.transform.localPosition = new Vector2 (0, achievement.transform.localPosition.y + 0.05f);
				if (achievement.transform.localPosition.y >= 7) {
					Destroy (achievement);
					down = true;
					GetComponent<AchievementUnlocked> ().enabled = false;
				}
			}
		}
	}
}
