using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBalls : MonoBehaviour {

	private Rigidbody2D rb;
	private bool waveEnd = false;
	private float ballStuckTimer = 0;
	private float ballStuckYPos = 0;
	public Sprite[] ballSprites;
	void Start() {
		BallColorAndSprite ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Vars.startMovingTowardsMainBall) {
			float step = 35 * Time.deltaTime;
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (Vars.firstBallHitXPos, -3), step);
			if (Vector3.Distance (transform.position, new Vector2 (Vars.firstBallHitXPos, -3)) == 0 && waveEnd == false) {
				waveEnd = true;
				Vars.ballsReachedDistance++;
				if (Vars.ballsReachedDistance == Vars.numberOfBalls) {
					Vars.ballsReachedDistance = 0;
					Vars.canContinue = true;
					Vars.startMovingTowardsMainBall = false;
					Vars.firstBallHitBottomCollider = false;
					Vars.newWaveOfBricks = true;
				}
			}
		} else {
			waveEnd = false;
			if (transform.position.y == -3)
					return;
			if ((Mathf.Round(transform.position.y * 10f) / 10f) != (Mathf.Round(ballStuckYPos * 10f) / 10f)) {
				ballStuckYPos = transform.position.y;
				ballStuckTimer = 0;
			} else {
				ballStuckTimer += Time.deltaTime;
				if (ballStuckTimer >= 5) {
					rb.AddForce (new Vector2(0, 100));
					ballStuckTimer = 0;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Equals ("borderBottom")) {
			if (Vars.firstBallHitBottomCollider == false) {
				Vars.firstBallHitBottomCollider = true;
				Vars.firstBallHitXPos = transform.position.x;
			}
			Vars.ballHitBottom++;
			rb.velocity = Vector2.zero;
			rb.position = new Vector2 (rb.position.x, -3f);
			if (Vars.ballHitBottom == Vars.numberOfBalls) {
				Vars.ballHitBottom = 0;
				Vars.startMovingTowardsMainBall = true;
			}
		}
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
