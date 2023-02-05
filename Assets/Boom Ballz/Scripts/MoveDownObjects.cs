using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownObjects : MonoBehaviour {

	private bool moveBrickDown = false;
	private float newPositionY = 0;
	private bool firstRow = true;
	public Rigidbody2D rb;
	MoveDownObjects moveDownObjectsScript;
	private float movingDownStep = 0.04f;

	void Start() {
		moveDownObjectsScript = GetComponent<MoveDownObjects> ();
	}

	public void MoveObjectkDown() {
		moveBrickDown = true;
		newPositionY = rb.transform.position.y - 0.85f;
	}

	void FixedUpdate() {
		if (firstRow) {
			rb.transform.position = new Vector2 (rb.transform.position.x, rb.transform.position.y - movingDownStep);
			if (rb.transform.position.y <= 4.55f) {
				rb.transform.position = new Vector2 (rb.transform.position.x, 4.55f);
				firstRow = false;
				moveDownObjectsScript.enabled = false;
			}
		}
		if (moveBrickDown) {
			if (rb.transform.position.y > newPositionY) {
				rb.transform.position = new Vector2 (rb.transform.position.x, rb.transform.position.y - movingDownStep);
				if (rb.transform.position.y <= -2.30f) {
					if (this.gameObject.name.Contains ("brick")) {
						GameObject.Find ("Canvas").GetComponent<Menus> ().ShowGameoverMenu ();
						Destroy (this.gameObject);
					} else {
						Destroy (this.gameObject);
					}
				}
			} else {
				moveBrickDown = false;
				rb.transform.position = new Vector2 (rb.transform.position.x, newPositionY);
				moveDownObjectsScript.enabled = false;
			}
		}
	}
}
