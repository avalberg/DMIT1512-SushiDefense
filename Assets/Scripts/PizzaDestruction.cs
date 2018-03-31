using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDestruction : MonoBehaviour {
    public delegate void PizzaDelegate(GameObject pizza);
    public PizzaDelegate pizzaDelegate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        if (pizzaDelegate != null)
        {
            pizzaDelegate(gameObject);
        }
    }
}
