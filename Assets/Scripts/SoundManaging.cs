using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManaging : MonoBehaviour
{
    public static AudioSource background;
    public GameObject musicPlayer;
    private static SoundManaging instance = null;
    public static SoundManaging Instance { get { return instance; } }
    // Use this for initialization

    private void Awake()
    {
        background = GetComponent<AudioSource>();
        string scene = SceneManager.GetActiveScene().name;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            background.Play();

        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
