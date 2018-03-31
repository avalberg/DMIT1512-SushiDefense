using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMaki : MonoBehaviour {
    public GameObject makiPrefab, maki2Prefab;
    private GameObject maki;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool canPlaceMaki()
    {
        int cost;
        if (SelectedMaki.currentMaki == "makismile")
            cost = makiPrefab.GetComponent<MakiData>().levels[0].cost;
        else
            cost = maki2Prefab.GetComponent<MakiData>().levels[0].cost;
        return maki == null && GameManager.ingredients >= cost;
    }

    private void OnMouseUp()
    {
        if (canPlaceMaki())
        {
            if (SelectedMaki.currentMaki == "makismile")
                maki = (GameObject)Instantiate(makiPrefab, transform.position, Quaternion.identity);
            else
                maki = (GameObject)Instantiate(maki2Prefab, transform.position, Quaternion.identity);
            GameManager.ingredients -= maki.GetComponent<MakiData>().CurrentLevel.cost;
        }
        else if (canUpgradeMaki())
        {
            maki.GetComponent<MakiData>().increaseLevel();
            GameManager.ingredients -= maki.GetComponent<MakiData>().CurrentLevel.cost;
        }
    }

    private bool canUpgradeMaki()
    {
        if (maki != null)
        {
            MakiData makiData = maki.GetComponent<MakiData>();
            MakiLevel nextLevel = makiData.getNextLevel();
            if (nextLevel != null)
                return GameManager.ingredients >= nextLevel.cost;
        }
        return false;
    }
}
