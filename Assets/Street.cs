using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), GameObject.FindGameObjectWithTag ("b9").GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
