using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelmanager;
	
	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();	
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		print("Trigger");
		levelmanager.LoadLevel("Lose");
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		print("Collision");
	}
	
	
}
