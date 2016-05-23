﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);	
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		if (Input.GetMouseButtonDown(0) && !hasStarted) {
			print ("mouse clicked, launch ball");
			this.rigidbody2D.velocity = new Vector2 (Random.Range(8f,10f), 12f);
			hasStarted = true;
		}	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
	
		if (hasStarted) {
			audio.Play();
		}
	}
}
