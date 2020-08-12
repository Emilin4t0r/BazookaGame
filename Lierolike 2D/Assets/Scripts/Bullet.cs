using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject explosion;
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player") {
			Blowup();
		}
	}

	void Blowup() {
		GameObject expl = Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
		Destroy(expl, 1);
	}
}
