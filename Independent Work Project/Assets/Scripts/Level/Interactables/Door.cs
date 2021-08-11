using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseInteractable
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D BoxCollider2D;
    public Sprite Open, Close;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            spriteRenderer.sprite = Open;
            BoxCollider2D.isTrigger = true;
        }
        else
        {
            spriteRenderer.sprite = Close;
            BoxCollider2D.isTrigger = false;
        }
    }
}
