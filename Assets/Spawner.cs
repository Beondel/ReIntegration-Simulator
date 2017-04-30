using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] obstacles;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool coroutineIsStopped;

	int randEnemy;

	void Start () {
		coroutineIsStopped = false;
		StartCoroutine (Spawn());

	}


	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
		if ((GameObject.FindGameObjectWithTag ("Player").GetComponent<Runner> ().gameOver) && coroutineIsStopped) {
			StartCoroutine (Spawn ());
		}
	}

	public IEnumerator Spawn(){
		coroutineIsStopped = false;
		yield return new WaitForSeconds (startWait);

		while (!(GameObject.FindGameObjectWithTag ("Player").GetComponent<Runner> ().gameOver)) {
			randEnemy = Random.Range (0, obstacles.Length);
			Vector3 spawnPosition = GameObject.Find ("spawner").transform.position;
			Instantiate (obstacles[randEnemy], spawnPosition, gameObject.transform.rotation);
			coroutineIsStopped = false;
			yield return new WaitForSeconds (spawnWait);
		}
		coroutineIsStopped = true;
	}
}
