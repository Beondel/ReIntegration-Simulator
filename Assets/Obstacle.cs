using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public Rigidbody2D _rigidbody;
	public Transform _transform;
	public BoxCollider2D _collider;
	public Sprite[] textures;

	void Start () {
		Physics2D.IgnoreCollision (GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag ("b8").GetComponent<Collider2D>());
		_transform = GetComponent(typeof(Transform)) as Transform;
		_rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		_collider = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		_rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * 5 * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "antispawn") {
			Destroy (gameObject);
		}
	}
}
