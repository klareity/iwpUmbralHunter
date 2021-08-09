using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lamp : BaseInteractable
{
    private SpriteRenderer spriteRenderer;
    public Sprite On, Off;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            spriteRenderer.sprite = On;
        }
        else
        {
            spriteRenderer.sprite = Off;
        }
    }
}
