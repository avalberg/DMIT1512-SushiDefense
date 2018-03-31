using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MakiLevel
{
    public int cost;
    public GameObject sprite;
    public GameObject rice;
    public float fireRate;
}
public class MakiData : MonoBehaviour {
    public List<MakiLevel> levels;
    private MakiLevel currentLevel;

    public MakiLevel CurrentLevel { get { return currentLevel; }
        set {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);
            GameObject levelSprite = levels[currentLevelIndex].sprite;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelSprite != null)
                {
                    if (i == currentLevelIndex)
                        levels[i].sprite.SetActive(true);
                    else
                        levels[i].sprite.SetActive(false);
                }
            }
        }
    }

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public MakiLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
            return levels[currentLevelIndex + 1];
        else
            return null;
    }

    public void increaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
            CurrentLevel = levels[currentLevelIndex + 1];
    }
}
