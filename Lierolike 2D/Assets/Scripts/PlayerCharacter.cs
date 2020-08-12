using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Player {

	public enum PlayerType { Light, Heavy, Normal, Super };
	public PlayerType pt;
	private bool movingl;
	private bool movingr;

	public GameObject healthCounter;

	void Awake() {
		if (pt == PlayerType.Light) {
			moveSpeed = 15;
			jumpForce = 30;
			fallSpeed = 10;
			shootForce = 30;
			hp = 3;
			maxHP = 3;
			reloadTime = 0.5f;
			left = KeyCode.LeftArrow;
			right = KeyCode.RightArrow;
			up = KeyCode.UpArrow;
			down = KeyCode.DownArrow;
			fire = KeyCode.Space;
		}
		if (pt == PlayerType.Heavy) {
			moveSpeed = 12.5f;
			jumpForce = 25;
			fallSpeed = 10;
			shootForce = 40;
			hp = 4;
			maxHP = 4;
			reloadTime = 0.75f;
			left = KeyCode.A;
			right = KeyCode.D;
			up = KeyCode.W;
			down = KeyCode.S;
			fire = KeyCode.G;
		}
	}

	void Update() {
		if (Input.GetKey(left)) {
			sr.flipX = true;
			wpnSr.flipY = false;
			movingl = true;
			movingr = false;
		} else if (Input.GetKey(right)) {
			sr.flipX = false;
			wpnSr.flipY = true;
			movingr = true;
			movingl = false;
		} else {
			movingr = false;
			movingl = false;
		}

		if (movingr) {
			transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
			anim.SetBool("Running", true);
		} else if (movingl) {
			transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
			anim.SetBool("Running", true);
		} else {
			anim.SetBool("Running", false);
		}
		if (Input.GetKeyDown(up) && inGround) {
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			inGround = false;
		}
		if (!inGround) {
			rb.AddForce(0, -fallSpeed, 0);
		}

		if (counter > reloadTime) {
			if (Input.GetKey(fire)) {
				GameObject blt = Instantiate(bullet, aimPoint.transform.position, rotator.transform.rotation);
				Vector3 dir = (aimPoint.transform.position - rotator.transform.position).normalized;
				blt.GetComponent<Rigidbody>().AddForce(dir * shootForce, ForceMode.Impulse);
				Destroy(blt, 5);
				counter = 0;
			}
		} else {
			counter += Time.deltaTime;
		}

		if (hp < 1) {
			Destroy(gameObject);

		}

		RaycastHit hit;
		Vector3 dwn = transform.TransformDirection(Vector3.down);
		Debug.DrawRay(transform.position, dwn * 1.5f, Color.green, 1f);
		if (Physics.Raycast(transform.position, dwn, out hit, 1.5f) && hit.transform.CompareTag("Ground")) {
			inGround = true;
		} else {
			inGround = false;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Explosion") {
			hp--;
			healthCounter.GetComponent<UIHealth>().UpdateHealth();
		}
		if (other.gameObject.tag == "MedPack") {
			if (hp < maxHP)
				hp++;
			healthCounter.GetComponent<UIHealth>().UpdateHealth();
			Destroy(other.gameObject);
		}
	}
}
