using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeBall : MonoBehaviour {

	public GameObject numberOfStars;

	void Start() {
		UpdateUI ();
	}
	
	public void ChangeBallColorAndSpirte() {

		PlayerPrefs.SetInt ("white", 1);
		string buttonName = EventSystem.current.currentSelectedGameObject.name;
		GameObject[] ballsButtons = GameObject.FindGameObjectsWithTag ("ballColorsUI");
			
		if (PlayerPrefs.GetInt (buttonName) != 1) {
			int starsRequiredToUnlock = 200;
			if (buttonName.Equals ("football") || buttonName.Equals ("basketball") || buttonName.Equals ("golf") ||
			   buttonName.Equals ("beachVolleyball") || buttonName.Equals ("volleyball") || buttonName.Equals ("tennis")) {
				starsRequiredToUnlock = 500;
			}
			if (PlayerPrefs.GetInt ("numberOfStars") >= starsRequiredToUnlock) {
				PlayerPrefs.SetInt ("numberOfStars", PlayerPrefs.GetInt ("numberOfStars") - starsRequiredToUnlock);
				PlayerPrefs.SetInt ("starsSpent", PlayerPrefs.GetInt ("starsSpent") - starsRequiredToUnlock);


				if (buttonName.Equals("football")) {
					PlayerPrefs.SetInt ("unlockFootballBall", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("unlock football ball");
				}
				if (buttonName.Equals("golf")) {
					PlayerPrefs.SetInt ("unlockGolfBall", 1);
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
					GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("unlock golf ball");
				}

				PlayerPrefs.SetInt (buttonName, 1);
				PlayerPrefs.SetString ("selectedBall", buttonName);
				GameObject.Find ("shopBallsSound").GetComponent<AudioSource> ().Play ();
				numberOfStars.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString ();
				UpdateUI ();
				MarkSelectedBall ();
			} else {
				GameObject.Find ("deniedSound").GetComponent<AudioSource> ().Play ();
			}
		} else {
			GameObject.Find ("buttonClickSound").GetComponent<AudioSource> ().Play();
			PlayerPrefs.SetString ("selectedBall", buttonName);
			UpdateUI ();
			MarkSelectedBall ();
		}

	}

	public void AddStar(int star)
	{
		IAPManager.OnPurchaseSuccess = () =>
		{
			PlayerPrefs.SetInt ("numberOfStars", PlayerPrefs.GetInt ("numberOfStars") + star);
			numberOfStars.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString ();
		};
		
		switch (star)
		{
			case 50:
				IAPManager.Instance.BuyProductID(IAPKey.PACK1);
				break;
			case 200:
				IAPManager.Instance.BuyProductID(IAPKey.PACK2);
				break;
			case 500:
				IAPManager.Instance.BuyProductID(IAPKey.PACK3);
				break;
			case 1000:
				IAPManager.Instance.BuyProductID(IAPKey.PACK4);
				break;
		}
	}
	
	private void MarkSelectedBall() {
		EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color = new Color (1, 1, 1, 1);
	}
	private void UpdateUI() {
		GameObject[] ballsButtons = GameObject.FindGameObjectsWithTag ("ballColorsUI");
		bool allBallsUnlocked = true;
		foreach (GameObject ballImage in ballsButtons) {
			if (PlayerPrefs.GetInt (ballImage.name) == 1) {
				ballImage.transform.Find ("price").gameObject.SetActive (false);
				ballImage.transform.Find ("star").gameObject.SetActive (false);
			} else {
				allBallsUnlocked = false;
			}
			ballImage.GetComponent<Image> ().color = new Color (1, 1, 1, 0.2f);
		}
		if (allBallsUnlocked) {
			if (PlayerPrefs.GetInt ("allBallsUnlocked") != 1) {
				PlayerPrefs.SetInt ("allBallsUnlocked", 1);
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().enabled = true;
				GameObject.Find ("Canvas").GetComponent<AchievementUnlocked> ().NameOfTheAchievement ("unlock all balls");
			}
		}
	}
}
