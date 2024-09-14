using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFitter : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;

        transform.localScale = Vector3.one;

        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
    }
}
