using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPackSpawner : MonoBehaviour {
	public GameObject medPack;
	public float counter;
	public float maxCounter;

	void Start() {

	}

	void Update() {
		if (counter < maxCounter) {
			counter += Time.deltaTime;
		} else {
			counter = 0;
			Instantiate(medPack, new Vector3(Random.Range(-35, 35), Random.Range(-20, 20), 0), Quaternion.identity);
		}
	}
}
