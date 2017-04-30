using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner2 : MonoBehaviour {

	public Sprite[] textures;

	void Start () {
	}

	void Update () {
		if (Time.frameCount % 2 == 0) {
			runAnimation (Time.frameCount / 2);
		}
	}



	void runAnimation(int time){
		GetComponent<SpriteRenderer> ().sprite = textures [time % 8];
	}
		

	public void restart() {
		this.gameObject.transform.position = new Vector2 (6.61f, 7.27f);
	}
}
