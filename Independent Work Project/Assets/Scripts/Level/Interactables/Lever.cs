using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : BaseInteractable
{
    private SpriteRenderer spriteRenderer;
    private bool isInteractable;//can the object be interacted at the moment

    public Sprite On, Off;
    public Text HeadsUp;
    public List<GameObject> InteractableList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable == true && Input.GetKeyDown(KeyCode.F))
        {
            if(isActive)
            {
                spriteRenderer.sprite = Off;
                isActive = !isActive;
                
            }
            else
            {
                spriteRenderer.sprite = On;
                isActive = !isActive;
                
            }
            UpdateIntractableState();
        }
    }

    //updates the state of interactables
    void UpdateIntractableState()
    {
        for(int i =0; i< InteractableList.Count; ++i)
        {
            if (InteractableList[i].GetComponent<BaseInteractable>() != null)
            {
                InteractableList[i].GetComponent<BaseInteractable>().isActive = !InteractableList[i].GetComponent<BaseInteractable>().isActive;
            }
            else if(InteractableList[i].CompareTag("Level"))
            {
                InteractableList[i].SetActive(true);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteractable = true;
            

            HeadsUp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteractable = false;
            //collision.gameObject.GetComponent<PlayerMovement>().type = PlayerMovement.DemonType.Spider;

            HeadsUp.gameObject.SetActive(false);
        }
    }
}
