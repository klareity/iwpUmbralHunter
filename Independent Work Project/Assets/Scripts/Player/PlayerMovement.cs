using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    public int PlayerHealth;
    public Text HealthUI, AbilityOne, AbilityTwo, AbilityThree;
    Rigidbody2D rigidbody2D { get; set; }
    public GameObject itself;

    Vector3 MousePosition;
    Vector2 MouseDirection;

    public enum DemonType
    {
        Default,
        Spider,
        Fox
    };
    public DemonType type = DemonType.Default;

    //Spider Demon related values
    //the movement thing
    public float WebCooldown;//5
    public float WebSpeed;
    public GameObject web;
    bool isWebActive = false;
    //
    public float OrbCooldown;
    public float OrbSpeed;
    public GameObject orb;//1
    bool isOrbActive = false;
    //
    //the hooking in enemy thing
    public float HookCooldown;//3
    public float HookSpeed;
    public GameObject hook;
    bool isHookActive = false;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Cooldown();
        UpdateUI();

        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;


        if (Input.GetKeyDown("space") && Mathf.Abs(rigidbody2D.velocity.y) < 0.01f)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }


        switch(type)
        {
            case DemonType.Spider:
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && WebCooldown <= 0.0f)
                    {
                        BreakFall();
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha1) && OrbCooldown <= 0.0f)
                    {
                        VenomOrb();
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1) && HookCooldown <= 0.0f)
                    {
                        WebHook();
                    }
                    break;
                }
        }



        //DoAbility();
    }


    #region SpiderDemonAbilities

    //to be reworked where it helps with the player's mobilities as opposed to dropping down.

    void BreakFall()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        MouseDirection = (MousePosition - transform.position).normalized;

        GameObject WebClone;
        WebClone = Instantiate(web, transform.position, Quaternion.identity) as GameObject;
        WebClone.GetComponent<BreakFallWeb>().InitalPosition = transform.position;
        WebClone.GetComponent<Rigidbody2D>().AddForce(MouseDirection * WebSpeed, ForceMode2D.Impulse);
        WebClone.GetComponent<BreakFallWeb>().player = itself;
        WebCooldown = 5.0f;
        return;  
    }

    void VenomOrb()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        MouseDirection = (MousePosition - transform.position);
        MouseDirection.Normalize();
        GameObject VenomballClone;
        VenomballClone = Instantiate(orb, transform.position, Quaternion.identity) as GameObject;
        //VenomballClone.GetComponent<VenomBallOrb>().Direction = MouseDirection;
        VenomballClone.GetComponent<VenomBallOrb>().InitalPosition = transform.position;
        VenomballClone.GetComponent<Rigidbody2D>().AddForce(MouseDirection * OrbSpeed, ForceMode2D.Impulse);
        OrbCooldown = 2.0f;
        return;
    }

    void WebHook()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        MouseDirection = (MousePosition - transform.position).normalized;
        //MouseDirection.Normalize();
        GameObject HookClone;
        HookClone = Instantiate(hook, transform.position, Quaternion.identity) as GameObject;
        /*
        1. shoot the hook
        2. let it fly
        3a. if out of range/hit nothing
        3a1. destroy
        3c. if collide with enemy
        3c1. yeets the player in the diretion of the player
        */
        //HookClone.GetComponent<WebHook>().Direction = MouseDirection;
        HookClone.GetComponent<WebHook>().InitalPosition = transform.position;
        HookClone.GetComponent<Rigidbody2D>().AddForce(MouseDirection * HookSpeed, ForceMode2D.Impulse);
        HookClone.GetComponent<WebHook>().player = itself;
        HookCooldown = 3.0f;
        return;
    }

    #endregion

    //manages the cooldowns of abilities
    void Cooldown()
    {
        if (WebCooldown >= 0f)
        {
            WebCooldown -= Time.deltaTime;
        }
        if(OrbCooldown>=0)
        {
            OrbCooldown -= Time.deltaTime;
        }
        if(HookCooldown >= 0)
        {
            HookCooldown -= Time.deltaTime;
        }
    }

    //the abilities are updated here
    void DoAbility()
    {
        //if(isWebActive)
        //{
        //    if (WebDuration <= 0.0f)
        //    {
        //        isWebActive = false;
        //        return;
        //    }
        //    else
        //    {
        //        rigidbody2D.velocity = new Vector2(0, 0);

        //        WebDuration -= Time.deltaTime;
        //    }
        //}
    }

    void UpdateUI()
    {
        int tempWeb, tempHook, tempOrb;
        tempWeb = (int)WebCooldown;
        tempHook = (int)HookCooldown;
        tempOrb = (int)OrbCooldown;

        AbilityOne.text = "Web Cooldown: " + tempWeb.ToString();
        AbilityTwo.text = "Hook Cooldown: " + tempHook.ToString();
        AbilityThree.text = "OrbCooldown: " + tempOrb.ToString();
        HealthUI.text = "Health : " + PlayerHealth.ToString();
    }
}
