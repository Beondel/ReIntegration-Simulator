using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

	//public GameObject text;
	public Rigidbody2D _rigidbody;
	public Transform _transform;
	public BoxCollider2D _collider;
	public Sprite[] textures;
	public bool gameOver;

	void Start () {
		gameOver = false;
		_transform = GetComponent<Transform> ();//(typeof(Transform)) as Transform;
		_rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		_collider = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		_rigidbody.freezeRotation = true;
	}
		
	void Update () {
		movement ();
	}

	bool isOnGround(Collider2D other){
		return _collider.IsTouching (other);
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
		
	void runAnimation(int time){
		GetComponent<SpriteRenderer> ().sprite = textures [time % 8];
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "antispawn") {
			GameObject.Find ("lossScreen").transform.position = new Vector2 (15f, 12f);
			GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("Finish");
			for (int i = 1; i < obstacles.Length; i++) {
				Destroy (obstacles [i]);
			}
			GameObject.FindGameObjectWithTag ("restart").transform.position = new Vector2 (Screen.width / 2, (Screen.height / 2) - 150);
			gameOver = true;
		}
	}

	public void restart() {
		this.gameObject.transform.position = new Vector2 (6.73f, 8.11f);
		GameObject.FindGameObjectWithTag ("b9").GetComponent<Runner2> ().restart ();


		GameObject.FindGameObjectWithTag ("b1").transform.position = new Vector2 (11.96f, 8.11f);
		GameObject.FindGameObjectWithTag ("b2").transform.position = new Vector2 (24.63f, 8.11f);
		GameObject.FindGameObjectWithTag ("b3").transform.position = new Vector2 (20.43f, 8.23f);
		GameObject.FindGameObjectWithTag ("b4").transform.position = new Vector2 (19.51f, 8.52f);
		GameObject.FindGameObjectWithTag ("b5").transform.position = new Vector2 (14.75f, 8.03f);
		GameObject.FindGameObjectWithTag ("b6").transform.position = new Vector2 (22.35f, 8.11f);
		GameObject.FindGameObjectWithTag ("b7").transform.position = new Vector2 (14.76f, 11.4f);
		GameObject.FindGameObjectWithTag ("b8").transform.position = new Vector2 (34.5f, 8.47f);

		GameObject.Find ("winScreen").transform.position = new Vector2 (500f, 500f);
		GameObject.Find ("lossScreen").transform.position = new Vector2 (500f, 500f);
		GameObject.FindGameObjectWithTag("restart").transform.position = new Vector2 (500f, 500f);
		this.gameOver = false;
	}
}
