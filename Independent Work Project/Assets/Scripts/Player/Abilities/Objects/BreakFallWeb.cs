using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFallWeb : MonoBehaviour
{
    public float Duration;
    public GameObject web;


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
            Duration -= Time.deltaTime;
        }
    }
}
