using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

	public Rigidbody2D _rigidbody;
	public Transform _transform;
	public BoxCollider2D _collider;
	public Sprite[] textures;

	void Start () {
		_transform = GetComponent(typeof(Transform)) as Transform;
		_rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		_collider = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		_rigidbody.freezeRotation = true;
	}
		
	void Update () {
		movement ();
	}

	void movement(){
		if (isOnGround(GameObject.Find("ground_placeholder").GetComponent<Collider2D>())){
			if (Time.frameCount % 2 == 0) {
				runAnimation (Time.frameCount / 2);
			}
		} 
		if (Input.GetKeyDown (KeyCode.UpArrow) && isOnGround(GameObject.Find("ground_placeholder").GetComponent<Collider2D>())) {
			_rigidbody.AddForce (new Vector2(0, 10f), ForceMode2D.Impulse);

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = textures [4];
		}
	}

	bool isOnGround(Collider2D other){
		return _collider.IsTouching (other);
	}

	void runAnimation(int time){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = textures [time % 8];
	}
}
