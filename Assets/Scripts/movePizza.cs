using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePizza : MonoBehaviour {
    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWayPoint = 0;
    private float lastWayPointSwitchTime;
    public float speed = 1.0f;

	void Start () {
        lastWayPointSwitchTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 startPosition = waypoints[currentWayPoint].transform.position;
        Vector3 endPosition = waypoints[currentWayPoint + 1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWayPointSwitchTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWayPoint < waypoints.Length - 2)
            {
                currentWayPoint++;
                lastWayPointSwitchTime = Time.time;
            }
            else
            {
                if (gameObject.name == "bosspizza(Clone)")
                {
                    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.PlayOneShot(audioSource.clip);
                    GameManager.Won = false;
                    GameManager.GameOver();
                }
                else
                {
                    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.PlayOneShot(audioSource.clip);
                    GameManager.health--;
                    Destroy(gameObject);
                }
            }
        }
    }

    public float distanceToGoal()
    {
        float distance = 0;
        distance += Vector3.Distance(gameObject.transform.position, waypoints[currentWayPoint + 1].transform.position);
        for (int i = currentWayPoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector3.Distance(startPosition, endPosition);
        }
        return distance;
    }
}
