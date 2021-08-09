using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispensor : EnemyBase
{
    public Sprite Firing, NotFiring;
    public GameObject Arrow;// what this thing shoots out
    public float ArrowSpeed;// how fast the arrow flies
    public float  RateOfFire;//how fast this thing shoots
    private float RoF;//same as above, but is affected by the time
    private SpriteRenderer spriteRenderer;
    private bool isActive = false;

    public enum direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    public direction Direction;

    /*
     how it works
     countdown
     in a set time, it instaniates a projectile
     projectile fires
     set time to 0
     
     */

    // Start is called before the first frame update
    void Start()
    {
        RoF = RateOfFire;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown();

        if(RoF <= 0.0f)
        {
            isActive = true;
            GameObject ArrowClone;
            ArrowClone = Instantiate(Arrow, transform.position, Quaternion.identity);
            ArrowClone.GetComponent<EnemyArrow>().InitalPosition = transform.position;
            switch(Direction)
            {
                case direction.UP:
                    {
                        ArrowClone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3, ForceMode2D.Impulse);
                        break;
                    }
                case direction.DOWN:
                    {
                        ArrowClone.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 3, ForceMode2D.Impulse);
                        break;
                    }
                case direction.LEFT:
                    {
                        ArrowClone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3, ForceMode2D.Impulse);
                        break;
                    }
                case direction.RIGHT:
                    {
                        ArrowClone.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 3, ForceMode2D.Impulse);
                        break;
                    }
            }
            RoF = RateOfFire;
        }
        else if(RoF <= 0.75 * RateOfFire)
        {
            isActive = false;
        }

        if(isActive==true)
        {
            spriteRenderer.sprite = Firing;
        }
        else
        {
            spriteRenderer.sprite = NotFiring;
        }

        
    }

    void countdown()
    {
        RoF -= Time.deltaTime;
    }
}
