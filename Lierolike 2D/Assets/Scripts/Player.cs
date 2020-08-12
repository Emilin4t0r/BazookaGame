using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce;
	public float fallSpeed;
	public float shootForce;
	public float hp;
	public float maxHP;
	public bool inGround;
	public GameObject bullet;
	public Rigidbody rb;
	public Animator anim;
	public SpriteRenderer sr;
	public SpriteRenderer wpnSr;
	public GameObject rotator;
	public GameObject aimPoint;
	public float counter;
	public float reloadTime;

	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;
	public KeyCode fire;
}
