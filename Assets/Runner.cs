using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

	private float speed;
	public Rigidbody2D _rigidbody;
	public Transform _transform;
	public BoxCollider2D _collider;

	void Start () {
		speed = 10;
		isOnGround = false;
		_transform = GetComponent(typeof(Transform)) as Transform;
		_rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		_collider = GetComponent (typeof(BoxCollider2D)) as BoxCollider2D;
	}
		
	void Update () {
		movement ();
	}

	void movement(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} 
		if (Input.GetKeyDown (KeyCode.UpArrow) && isOnGround(GameObject.Find("ground_placeholder").collider2D)) {
			_rigidbody.AddForce (new Vector2(0, 7f), ForceMode2D.Impulse);
		}
	}
	/*
	void onCollisionEnter2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			isOnGround = true;
		}
	}

	void onCollisionExit2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			isOnGround = false;
		}
	}
*/
	bool isOnGround(Collider2D other){
		return _collider.IsTouching (other);
	}
}
