using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
	public GameObject player;
	float hp;
	public string playerColor;
	Text text;

	void Start() {
		text = transform.GetComponent<Text>();
		hp = player.GetComponent<PlayerCharacter>().hp;
		UpdateHealth();
	}

	public void UpdateHealth() {
		hp = player.GetComponent<PlayerCharacter>().hp;
		text.text = playerColor + " HP: " + hp.ToString();
	}
}
