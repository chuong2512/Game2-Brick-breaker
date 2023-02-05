using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBall : MonoBehaviour {

	public Sprite[] ballSprites;
	void Start () {
		ShootTheBall ();
	}
	void OnEnable() {
		ShootTheBall ();
	}

	private void ShootTheBall() {
		BallColorAndSprite ();
		Time.timeScale = 1;
		int xForce = Random.Range (100, 200);
		int yForce = Random.Range (100, 200);
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(xForce, yForce));
	}
	public void BallColorAndSprite() {
		SpriteRenderer sp = GetComponent<SpriteRenderer> ();
		sp.sprite = ballSprites [0];
		if (PlayerPrefs.GetString ("selectedBall").Equals ("white")) {
			sp.color = new Color32 (255, 255, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("green")) {
			sp.color = new Color32 (0, 255, 44, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("blue")) {
			sp.color = new Color32 (0, 128, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("pink")) {
			sp.color = new Color32 (251, 0, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("red")) {
			sp.color = new Color32 (255, 0, 0, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("yellow")) {
			sp.color = new Color32 (255, 255, 0, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("brown")) {
			sp.color = new Color32 (136, 84, 11, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("silver")) {
			sp.color = new Color32 (192, 192, 192, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("aqua")) {
			sp.color = new Color32 (0, 255, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("purple")) {
			sp.color = new Color32 (128, 0, 128, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("olive")) {
			sp.color = new Color32 (128, 128, 0, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("violet")) {
			sp.color = new Color32 (138, 43, 226, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("football")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [1];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("basketball")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [2];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("golf")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [3];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("beachVolleyball")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [4];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("volleyball")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [5];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("tennis")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [6];
		}
	}
}
