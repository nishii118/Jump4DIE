using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFitter : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BackgroundSprite[] backgroundSprites;
    private void Start()
    {
        //backgroundSprites = new List<>();
        //spriteRenderer = GetComponent<SpriteRenderer>();

        //spriteRenderer.sprite = 
        string currentNameSprite = PlayerPrefs.GetString("SelectedBackground");
        BackgroundSprite currentSprite = Array.Find(backgroundSprites, x => x.name == currentNameSprite);
        spriteRenderer.sprite = currentSprite.sprite;
        ResizeBackground();
    }

    public void ResizeBackground()
    {
        if (spriteRenderer == null) return;

        transform.localScale = Vector3.one;

        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
    }
}
