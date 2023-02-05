using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour {

	public void TurnOnOffSound() {
		if (AudioListener.volume > 0) {
			AudioListener.volume = 0;
			transform.Find ("off").GetComponent<Text> ().enabled = true;
		} else {
			AudioListener.volume = 1f;
			transform.Find ("off").GetComponent<Text> ().enabled = false;
		}
		GameObject.Find ("buttonClickSound").GetComponent<AudioSource> ().Play ();
	}
}
