using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
	[SerializeField] [Range(0, 50)] int poolSize = 5;
	[SerializeField] [Range(0.1f, 30)]float spawnTimer = 1;

	GameObject[] pool;


	private void Awake() {
		CreatePool();
	}
	private void Start() {
		StartCoroutine(SpawnEnemy());
	}

	void EnableObjectInPool() {
		for (int i = 0; i < pool.Length; i++) {
			if(pool[i].activeInHierarchy == false) {
				pool[i].SetActive(true);
				return;
			}
		}
	}

	void CreatePool() {
		pool = new GameObject[poolSize];
		for (int i = 0; i < pool.Length; i++) {
			pool[i] = Instantiate(enemyPrefab, transform);
			pool[i].SetActive(false);
		}
	}

	IEnumerator SpawnEnemy() {
		while (true) {
			EnableObjectInPool();
			yield return new WaitForSeconds(spawnTimer);
		}
	}
}
