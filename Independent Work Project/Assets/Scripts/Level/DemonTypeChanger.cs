using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonTypeChanger : MonoBehaviour
{
    public Text Demon_Type, DemonTypeHeadsUp;
    //temp stuff, will refactor


    // Start is called before the first frame update
    void Start()
    {
        Demon_Type.text = "Demon Type: Default";
        DemonTypeHeadsUp.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           
            collision.gameObject.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;
            Demon_Type.text = "Demon Type: Spider";
            //Debug.Log(collision.gameObject.GetComponent<PlayerMovement>().type);
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    Debug.Log("ayayaya");
            //    collision.gameObject.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;
            //    Debug.Log(collision.gameObject.GetComponent<PlayerMovement>().type);
            //}
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.T))
    //    {

    //        Debug.Log("pingpong");
            
    //    }
    //}
}
