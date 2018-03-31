using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    private MakiData makiData;
    public List<GameObject> pizzasInRange;
    private float lastShotTime = 2;

	// Use this for initialization
	void Start () {
        lastShotTime = Time.time;
        makiData = gameObject.GetComponentInChildren<MakiData>();
        pizzasInRange = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject target = null;
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject pizza in pizzasInRange)
        {
            float distanceToGoal = pizza.GetComponent<movePizza>().distanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = pizza;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        if (target != null)
        {
            if (Time.time - lastShotTime > makiData.CurrentLevel.fireRate)
            {
                Shooting(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
        }
	}

    void OnPizzaDestroy (GameObject pizza)
    {
        pizzasInRange.Remove(pizza);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Pizza"))
        {
            pizzasInRange.Add(collision.gameObject);
            PizzaDestruction del = collision.gameObject.GetComponent<PizzaDestruction>();
            del.pizzaDelegate += OnPizzaDestroy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Pizza"))
        {
            pizzasInRange.Remove(collision.gameObject);
            PizzaDestruction del = collision.gameObject.GetComponent<PizzaDestruction>();
            del.pizzaDelegate -= OnPizzaDestroy;
        }
    }

    void Shooting(Collider2D target)
    {
        GameObject ricePrefab = makiData.CurrentLevel.rice;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = ricePrefab.transform.position.z;
        targetPosition.z = ricePrefab.transform.position.z;

        GameObject newRice = (GameObject)Instantiate(ricePrefab);
        newRice.transform.position = startPosition;
        RiceBehaviour riceComp = newRice.GetComponent<RiceBehaviour>();
        riceComp.target = target.gameObject;
        riceComp.startPosition = startPosition;
        riceComp.targetPosition = targetPosition;

        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }
}
