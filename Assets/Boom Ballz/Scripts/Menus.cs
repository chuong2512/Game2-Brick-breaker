using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	public GameObject mainBall;
	public GameObject mainMenuBouncingBall;
	public GameObject mainMenu;
	public GameObject ballsShop;
	public GameObject upperMenu;
	public GameObject gameoverMenuUI;
	public GameObject pauseMenuUI;
	public GameObject achievementsUI;
	public GameObject bestScoreMainMenu;

	public GameObject numberOfStarsMainMenu;
	public GameObject numberOfStarsShop;
	private AudioSource buttonClickSound;

	void Start() {
		numberOfStarsMainMenu.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();

		if (PlayerPrefs.GetInt ("currentLanguage") == 0) {
			bestScoreMainMenu.GetComponent<Text> ().text = "best\n" + PlayerPrefs.GetInt ("bestScore").ToString ();
		} else if (PlayerPrefs.GetInt ("currentLanguage") == 1) {
			bestScoreMainMenu.GetComponent<Text> ().text = "migliore\n" + PlayerPrefs.GetInt ("bestScore").ToString ();
		} else if (PlayerPrefs.GetInt ("currentLanguage") == 2) {
			bestScoreMainMenu.GetComponent<Text> ().text = "rekord\n" + PlayerPrefs.GetInt ("bestScore").ToString ();
		}

		buttonClickSound = GameObject.Find ("buttonClickSound").GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("restartTheGame") == 1) {
			PlayerPrefs.SetInt ("restartTheGame", 0);
			upperMenu.SetActive (true);
			mainMenuBouncingBall.SetActive (false);
			mainBall.SetActive (true);
			mainMenu.SetActive (false);
		}
	}
		
	public void StartTheGame() {
		buttonClickSound.Play ();
		upperMenu.SetActive (true);
		mainMenuBouncingBall.SetActive (false);
		mainBall.SetActive (true);
		mainMenu.SetActive (false);

		PlayerPrefs.SetInt ("numberOfGames", PlayerPrefs.GetInt ("numberOfGames") + 1);
		if (PlayerPrefs.GetInt ("numberOfGames") >= 10) {
			if (PlayerPrefs.GetInt ("play10Games") != 1) {
				PlayerPrefs.SetInt ("play10Games", 1);
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("play 10 Games");
			}
		}
		if (PlayerPrefs.GetInt ("numberOfGames") >= 100) {
			if (PlayerPrefs.GetInt ("play100Games") != 1) {
				PlayerPrefs.SetInt ("play100Games", 1);
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("play 100 Games");
			}
		}
		if (PlayerPrefs.GetInt ("numberOfGames") >= 1000) {
			if (PlayerPrefs.GetInt ("play1000Games") != 1) {
				PlayerPrefs.SetInt ("play1000Games", 1);
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("play 1000 Games");
			}
		}
	}
	public void AchievementsMenu() {
		buttonClickSound.Play ();
		achievementsUI.SetActive (true);
	}
	public void ExitAchievementsMenu() {
		buttonClickSound.Play ();
		achievementsUI.SetActive (false);
	}

	public void BallsShop() {
		numberOfStarsShop.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();
		buttonClickSound.Play ();
		ballsShop.SetActive (true);
	}
	public void ExitBallsShop (){
		numberOfStarsMainMenu.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();
		buttonClickSound.Play ();
		ballsShop.SetActive (false);
	}

	public void ExitToMainMenu() {
		buttonClickSound.Play ();
		Vars.RestartAllVariables ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ShowGameoverMenu () {
		GameObject.Find ("gameOverSound").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("ball").GetComponent<MainBall> ().enabled = false;
		gameoverMenuUI.SetActive (true);
	}
	public void ShowPauseMenu() {
		GameObject.Find ("pauseButtonSound").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("ball").GetComponent<MainBall> ().enabled = false;
		Time.timeScale = 0;
		pauseMenuUI.SetActive (true);
	}
	public void HidePauseMenu() {
		buttonClickSound.Play ();
		GameObject.Find ("ball").GetComponent<MainBall> ().enabled = true;
		Time.timeScale = 1;
		pauseMenuUI.SetActive (false);
	}
	public void ContinueGame() {
		Debug.Log ("Put your code that shows rewarded ad and than call method ContinueGame() from Menus.cs script on line 117");
		buttonClickSound.Play ();
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("object");
		foreach (GameObject sceneObject in objects) {
			if (sceneObject.GetComponent<Rigidbody2D> ().position.y < -0.5f) {
				Destroy (sceneObject);
			}
		}

		GameObject.Find ("ball").GetComponent<MainBall> ().enabled = true;
		gameoverMenuUI.SetActive (false);

	}
	public void SpeedUpGame() {
		buttonClickSound.Play ();
		Time.timeScale = 5f;
		GameObject.Find ("speedUpButton").SetActive (false);
	}
	public void RestartGame () {
		buttonClickSound.Play ();
		PlayerPrefs.SetInt ("restartTheGame", 1);
		Vars.RestartAllVariables ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	private void ResetVariables() {
		Vars.level = 1;
		Vars.numberOfBalls = 1;
		Vars.newBalls = 1;
		Vars.ballHitBottom = 0;
		Vars.lastBallHitBottom = false;
		Vars.startMovingTowardsMainBall = false;
		Vars.ballsReachedDistance = 0;
		Vars.firstBallHitBottomCollider = false;
		Vars.firstBallHitXPos = 0;
		Vars.canContinue =  true;
		Vars.newWaveOfBricks = false;
		Vars.speedUpTimer = 0;
	}
}
