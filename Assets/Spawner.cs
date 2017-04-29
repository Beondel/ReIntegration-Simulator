using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] obstacles;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;

	int randEnemy;

	void Start () {
		StartCoroutine (Spawn());
	}


	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (startWait);

		while (true) {
			randEnemy = Random.Range (0, obstacles.Length);
			Vector3 spawnPosition = GameObject.Find ("spawner").transform.position;
			Instantiate (obstacles[randEnemy], spawnPosition, gameObject.transform.rotation);
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
