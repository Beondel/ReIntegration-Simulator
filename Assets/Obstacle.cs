using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * 5 * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (gameObject);
	}
}
