using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonTypeChanger : MonoBehaviour
{
    public Text Demon_Type, DemonTypeHeadsUp;
    bool isInteractble;
    public GameObject player;

    public enum DemonTypeSetting
    {
        Default,
        Spider,
        Fox
    };

    public DemonTypeSetting dts;
    //temp stuff, will refactor


    // Start is called before the first frame update
    void Start()
    {
        //Demon_Type.text = "Demon Type: Default";
        //DemonTypeHeadsUp.text = " ";
        isInteractble = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteractble == true && Input.GetKeyDown(KeyCode.F))
        {
            player.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;
            Demon_Type.text = "Demon Type: Spider";
        }
    }

    //if within range, allow the player to interact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInteractble = true;
            //collision.gameObject.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;
            
            DemonTypeHeadsUp.gameObject.SetActive(true);
        }
    }

    //if not within range, dont allow the player to interact
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteractble = false;
            DemonTypeHeadsUp.gameObject.SetActive(false);

        }
    }

}
