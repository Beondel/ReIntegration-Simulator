using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	public float totalDistanceTravelled;

	// Use this for initialization
	void Start () {
		totalDistanceTravelled = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * 0.5f * Time.deltaTime);
	}
}
