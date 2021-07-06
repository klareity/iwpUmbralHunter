using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTypeChanger : MonoBehaviour
{
    //temp stuff, will refactor


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("pingpong");
            collision.gameObject.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;
            //Debug.Log(collision.gameObject.GetComponent<PlayerMovement>().type);
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    Debug.Log("ayayaya");
            //    collision.gameObject.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;
            //    Debug.Log(collision.gameObject.GetComponent<PlayerMovement>().type);
            //}
        }
    }
}
