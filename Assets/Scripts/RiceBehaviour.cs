using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceBehaviour : MonoBehaviour {
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

	void Start () {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
	}
	
	// Update is called once per frame
	void Update () {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition) && target.tag.Equals("Pizza") && target.name != "bosspizza(Clone)")
        {
            if (target != null)
            {
                Destroy(target);
                GameManager.ingredients++;
            }
            Destroy(gameObject);
        }
        else if (gameObject.transform.position.Equals(targetPosition) && target.name == "bosspizza(Clone)")
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.FindChild("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    GameManager.Won = true;
                    GameManager.GameOver();
                }
            }
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y < -6)
            Destroy(gameObject);
	}
}
