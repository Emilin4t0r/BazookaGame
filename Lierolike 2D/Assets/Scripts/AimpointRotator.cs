using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimpointRotator : MonoBehaviour {
	private GameObject plr;
	private PlayerCharacter ctrls;
	private void Start() {
		plr = transform.parent.gameObject;
		ctrls = plr.GetComponent<PlayerCharacter>();
	}
	void Update() {
		if (Input.GetKey(ctrls.left) && Input.GetKey(ctrls.up)) {
			ChangeAim(315);
		}
		if (Input.GetKeyDown(ctrls.left)
			|| (Input.GetKeyUp(ctrls.up) && Input.GetKey(ctrls.left))
			|| (Input.GetKeyUp(ctrls.down) && Input.GetKey(ctrls.left))) {
			ChangeAim(0);
		}
		if (Input.GetKey(ctrls.right) && Input.GetKey(ctrls.up)) {
			ChangeAim(225);
		}
		if (Input.GetKeyDown(ctrls.up)
			|| (Input.GetKeyUp(ctrls.left) && Input.GetKey(ctrls.up))
			|| (Input.GetKeyUp(ctrls.right) && Input.GetKey(ctrls.up))) {
			ChangeAim(270);
		}
		if (Input.GetKey(ctrls.right) && Input.GetKey(ctrls.down)) {
			ChangeAim(135);
		}
		if (Input.GetKeyDown(ctrls.right)
			|| (Input.GetKeyUp(ctrls.down) && Input.GetKey(ctrls.right))
			|| (Input.GetKeyUp(ctrls.up) && Input.GetKey(ctrls.right))) {
			ChangeAim(180);
		}
		if (Input.GetKey(ctrls.left) && Input.GetKey(ctrls.down)) {
			ChangeAim(45);
		}
		if (Input.GetKeyDown(ctrls.down)
			|| (Input.GetKeyUp(ctrls.left) && Input.GetKey(ctrls.down))
			|| (Input.GetKeyUp(ctrls.right) && Input.GetKey(ctrls.down))) {
			ChangeAim(90);
		}
	}

	void ChangeAim(float angle) {
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
