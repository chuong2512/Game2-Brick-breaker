using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementMenu : MonoBehaviour {

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

	void OnEnable() {
		if (PlayerPrefs.GetInt ("play10Games") == 1) {
			GameObject.Find ("play10games").GetComponent<Image> ().sprite = play10Games;
			GameObject.Find ("play10games").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("play100Games") == 1) {
			GameObject.Find ("play100games").GetComponent<Image> ().sprite = play100Games;
			GameObject.Find ("play100games").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("play1000Games") == 1) {
			GameObject.Find ("play1000games").GetComponent<Image> ().sprite = play1000Games;
			GameObject.Find ("play1000games").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("collect1000balls") == 1) {
			GameObject.Find ("collect1000balls").GetComponent<Image> ().sprite = collect1000Balls;
			GameObject.Find ("collect1000balls").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("collect1000Stars") == 1) {
			GameObject.Find ("collect1000stars").GetComponent<Image> ().sprite = collect1000Stars;
			GameObject.Find ("collect1000stars").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("destroy100bricks") == 1) {
			GameObject.Find ("100bricks").GetComponent<Image> ().sprite = destroy100Bricks;
			GameObject.Find ("100bricks").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("destroy1000bricks") == 1) {
			GameObject.Find ("1000bricks").GetComponent<Image> ().sprite = destroy1000Bricks;
			GameObject.Find ("1000bricks").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("destroy10000bricks") == 1) {
			GameObject.Find ("10000bricks").GetComponent<Image> ().sprite = destroy10000Bricks;
			GameObject.Find ("10000bricks").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("score100points") == 1) {
			GameObject.Find ("score100points").GetComponent<Image> ().sprite = score100Points;
			GameObject.Find ("score100points").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("unlockFootballBall") == 1){
			GameObject.Find ("unlockFootballBall").GetComponent<Image> ().sprite = unlockFootballBall;
			GameObject.Find ("unlockFootballBall").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("unlockGolfBall") == 1) {
			GameObject.Find ("unlockGolfBall").GetComponent<Image> ().sprite = unlockGolfBall;
			GameObject.Find ("unlockGolfBall").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		if (PlayerPrefs.GetInt ("allBallsUnlocked") == 1) {
			GameObject.Find ("unlockAllBalls").GetComponent<Image> ().sprite = unlockAllBalls;
			GameObject.Find ("unlockAllBalls").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
	}
}
