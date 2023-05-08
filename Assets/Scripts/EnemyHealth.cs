using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHitPoints = 5;

	[Tooltip("Adds amount to maxHitPoints when enemy dies.")]
	[SerializeField] int difficultyRamp = 1;
	int currentHitPoints = 0;

	Enemy enemy;

	private void OnEnable() {
		currentHitPoints = maxHitPoints;
	}
	private void Start() {
		enemy = GetComponent<Enemy>();
	}

	private void OnParticleCollision(GameObject other) {
		ProcessHit();
	}

	void ProcessHit() {
		currentHitPoints--;
		if(currentHitPoints <= 0) {
			gameObject.SetActive(false);
			maxHitPoints += difficultyRamp;
			//SoundManager.instance.PlaySound("gold");
			enemy.RewardGold();
		}
	}
}
