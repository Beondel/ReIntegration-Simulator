using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			GameObject.Find ("winScreen").transform.position = new Vector2 (15f, 12f);
		} 

		if (other.gameObject.tag == "b9") {
			GameObject.Find ("lossScreen").transform.position = new Vector2 (15f, 12f);
		}

		transform.position = new Vector2 (500f, 500f);
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("Finish");
		for (int i = 1; i < obstacles.Length; i++) {
			Destroy (obstacles [i]);
		}
		GameObject.FindGameObjectWithTag ("restart").transform.position = new Vector2 (Screen.width / 2, (Screen.height / 2) - 150);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Runner> ().gameOver = true;
	}
}
