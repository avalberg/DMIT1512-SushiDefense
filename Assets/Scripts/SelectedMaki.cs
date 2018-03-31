using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMaki : MonoBehaviour {
    public Sprite maki1, maki2;
    private SpriteRenderer spriteRenderer;
    public static string currentMaki;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = maki1;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeSprite();
        currentMaki = spriteRenderer.sprite.name;
        spriteRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    void ChangeSprite()
    {
        if (spriteRenderer.sprite == maki1)
            spriteRenderer.sprite = maki2;
        else
            spriteRenderer.sprite = maki1;
    }
}
