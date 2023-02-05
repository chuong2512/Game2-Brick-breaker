using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBall : MonoBehaviour {

	public Rigidbody2D rb;
	private TextMesh numberOfBalls;
	private bool canShoot = true;
	private GameObject lines;
	private bool multipleBalls = false;
	private int ballsShooted = 0;
	private float timer = 0;
	private bool waveEnd = false;
	private float ballStuckTimer = 0;
	private float ballStuckYPos = 0;
	private Text score;
	private Text bestScore;
	private float speedUpTimer = 0;
	private GameObject speedUpButton;
	public GameObject ballNumberText;
	public Sprite[] ballSprites;
	GameObject[] ballz;
	void Start() {
		Time.timeScale = 1;
		numberOfBalls = ballNumberText.GetComponent<TextMesh> ();
		score = GameObject.Find ("scoreText").GetComponent<Text> ();
		bestScore = GameObject.Find ("bestScoreText").GetComponent<Text> ();
		if (PlayerPrefs.GetInt ("currentLanguage") == 0) {
			bestScore.text = "best\n" + PlayerPrefs.GetInt ("bestScore").ToString ();
		} else if (PlayerPrefs.GetInt ("currentLanguage") == 1) {
			bestScore.text = "migliore\n" + PlayerPrefs.GetInt ("bestScore").ToString ();
		} else if (PlayerPrefs.GetInt ("currentLanguage") == 2) {
			bestScore.text = "rekord\n" + PlayerPrefs.GetInt ("bestScore").ToString ();
		}
		GetComponent<ObjectPlacement> ().PlaceNewObjectsOnTheScene ();
		lines = transform.Find ("lines").gameObject;
		GameObject.Find ("numberOfStarsText").GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();
		lines.SetActive (false);
		speedUpButton = GameObject.Find ("speedUpButton");
		speedUpButton.SetActive (false);
		BallColorAndSprite ();
	}

	void OnEnable() {
		ballNumberText.SetActive (true);
		BallColorAndSprite ();
	}

	void OnDisable() {
		if (ballNumberText != null) {
			ballNumberText.SetActive (false);
		}
	}

	void Update() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (mousePosition.y > 5) {//Not to react on click if user presses pause button or something from upper menu
			lines.SetActive(false);
			return;
		}
		if (mousePosition.y < -3f) {
			if (Input.GetMouseButton (0) && canShoot && Vars.canContinue) {
				float px = transform.position.x - mousePosition.x;
				float py = transform.position.y - mousePosition.y;
				transform.localRotation = Quaternion.Euler (0, 0, Mathf.Rad2Deg * Mathf.Atan2 (py, px));
				lines.SetActive (true);
			}
		} else {
			if (Input.GetMouseButton (0) && canShoot && Vars.canContinue) {
				float px = transform.position.x - mousePosition.x;
				float py = transform.position.y - mousePosition.y;
				transform.localRotation = Quaternion.Euler (0, 0, Mathf.Rad2Deg * Mathf.Atan2 (-py, -px));
				lines.SetActive (true);
			}
		}

		if (Input.GetMouseButtonUp (0) && canShoot && Vars.canContinue) {
			speedUpTimer = 0;
			lines.SetActive (false);
			numberOfBalls.color = new Color (1, 1, 1, 0);
			canShoot = false;
			rb.AddForce (transform.right * 1250);
			if (Vars.numberOfBalls > 1) {
				multipleBalls = true;
			}

		}

		speedUpTimer += Time.deltaTime;
		if (speedUpTimer >= 7 + (Vars.numberOfBalls / 10)) {
			speedUpTimer = 0;
			if (Time.timeScale == 1 && !canShoot) {
				speedUpButton.SetActive (true);
			}
		}

		if (multipleBalls == true) {
			timer += Time.deltaTime;
			if (timer >= 0.1f) {
				timer = 0;
				if (Vars.numberOfBalls > ballsShooted+1) {
					ballz = GameObject.FindGameObjectsWithTag ("ball");
					ballz [ballsShooted].transform.localRotation = transform.localRotation;
					ballz [ballsShooted].GetComponent<Rigidbody2D> ().AddForce (transform.right * 1250);
					ballsShooted++;

				} else {
					multipleBalls = false;
					ballsShooted = 0;
				}
			}
		}

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
			if (Vars.newWaveOfBricks) {
				GameObject[] allBallsOnTheScene = GameObject.FindGameObjectsWithTag ("ball");
				Vars.numberOfBalls = Vars.newBalls;
				while(allBallsOnTheScene.Length+1 < Vars.numberOfBalls){
					Instantiate (Resources.Load<GameObject> ("ball"), new Vector2 (Vars.firstBallHitXPos, -3), Quaternion.identity);
					allBallsOnTheScene = GameObject.FindGameObjectsWithTag ("ball");
				}
				Vars.newWaveOfBricks = false;
				GameObject[] objects = GameObject.FindGameObjectsWithTag ("object");
				foreach (GameObject sceneObjects in objects) {
					sceneObjects.GetComponent<MoveDownObjects> ().enabled = true;
					sceneObjects.GetComponent<MoveDownObjects> ().MoveObjectkDown ();
				}
				GetComponent<ObjectPlacement> ().PlaceNewObjectsOnTheScene ();
				score.text = Vars.level.ToString ();
				if (Vars.level >= 100) {
					if (PlayerPrefs.GetInt ("score100points") != 1) {
						PlayerPrefs.SetInt ("score100points", 1);
						GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
						GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("score 100 points");
					}
				}

				if (Vars.level > PlayerPrefs.GetInt ("bestScore")) {
					PlayerPrefs.SetInt ("bestScore", Vars.level);

					if (PlayerPrefs.GetInt ("currentLanguage") == 0) {
						bestScore.text = "best\n" + Vars.level;
					} else if (PlayerPrefs.GetInt ("currentLanguage") == 1) {
						bestScore.text = "migliore\n" + Vars.level;
					} else if (PlayerPrefs.GetInt ("currentLanguage") == 2) {
						bestScore.text = "rekord\n" + Vars.level;
					}
				}
				Vars.level++;
				canShoot = true;
				Vars.numberOfBalls = Vars.newBalls;

				numberOfBalls.text = Vars.numberOfBalls + "x";
				numberOfBalls.GetComponentInParent<Transform> ().transform.position = new Vector2 (transform.position.x, -2.4f);
				numberOfBalls.color = new Color (1, 1, 1, 1);//Show number of balls above balls 
				speedUpTimer = 0;
				speedUpButton.SetActive (false);
				Time.timeScale = 1;
			}

			if (transform.position.y == -3)
				return;
			if ((Mathf.Round(transform.position.y * 10f) / 10f) != (Mathf.Round(ballStuckYPos * 10f) / 10f)) {//Check if ball is stuck on y position
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
		
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Equals ("borderBottom")) {
			Vars.ballHitBottom++;

			rb.velocity = Vector2.zero;
			rb.position = new Vector2 (rb.position.x, -3f);
		
			if (Vars.firstBallHitBottomCollider == false) {
				Vars.firstBallHitBottomCollider = true;
				Vars.firstBallHitXPos = transform.position.x;
			}

			if (Vars.ballHitBottom == Vars.numberOfBalls) {
				Vars.ballHitBottom = 0;
				Vars.startMovingTowardsMainBall = true;
			}
		}
	}

	private void BallColorAndSprite() {
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
