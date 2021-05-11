using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFallWeb : MonoBehaviour
{
    public float Duration;
    public GameObject web;
    public GameObject player;

    void Start()
    {
       
    }


    void Update()
    {
        if(Duration <= 0.0f)
        {
            Destroy(web);
            return;
        }
        else
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Duration -= Time.deltaTime;
        }
    }
}
