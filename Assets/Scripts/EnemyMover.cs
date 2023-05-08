using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)]float speed = 1;

    Enemy enemy;

    void OnEnable() {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

	private void Start() {
        enemy = GetComponent<Enemy>();
	}

	void FindPath() {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform) {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint!= null) {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart() {
        transform.position = path[0].transform.position;
	}

    void FinishPath() {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath() {
        foreach(var waypoint in path) {
            float travelPercent = 0;
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            transform.LookAt(waypoint.transform.position);

            while (travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }  
		}
        FinishPath();
    }
}
