using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    Rigidbody2D rigidbody2D;

    Vector3 MousePosition;
    Vector2 MouseDirection;

    enum DemonType
    {
        Spider
    };


    //Spider Demon related values
    public float WebCooldown;
    public float WebDuration;
    public GameObject web;
    bool isWebActive = false;
    //
    public float OrbCooldown;
    public float OrbRange;
    public float OrbSpeed;
    public GameObject orb;
    bool isOrbActive = false;
    //
    public float HookCooldown;
    public float HookRange;
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
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement  , 0, 0) * Time.deltaTime * movementSpeed;

        if(Input.GetKeyDown("space") && Mathf.Abs(rigidbody2D.velocity.y) < 0.01f )
        {
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
        }
        if (rigidbody2D.velocity.y < 0.0f && Input.GetKeyDown(KeyCode.M) && WebCooldown <= 0.0f && !isWebActive)
        {
            BreakFall();
        }
        if(Input.GetKeyDown(KeyCode.B)&& OrbCooldown <= 0.0f)
        {
            VenomOrb();
        }
        if(Input.GetKeyDown(KeyCode.C) && HookCooldown <= 0.0f)
        {
            WebHook();
        }
        DoAbility();
    }


    #region SpiderDemonAbilities

    void BreakFall()
    {

        Vector3 tempPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        GameObject web_clone;
        web_clone = Instantiate(web, tempPos, Quaternion.identity) as GameObject;
        isWebActive = true;
        WebCooldown = 1.5f;
        WebDuration = 3f;
        return;
        
    }

    void VenomOrb()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        MouseDirection = (MousePosition - transform.position);
        MouseDirection.Normalize();
        GameObject VenomballClone;
        VenomballClone = Instantiate(orb, transform.position, Quaternion.identity) as GameObject;
        VenomballClone.GetComponent<VenomBallOrb>().Direction = MouseDirection;
        VenomballClone.GetComponent<VenomBallOrb>().InitalPosition = transform.position;
        VenomballClone.GetComponent<Rigidbody2D>().AddForce(MouseDirection * 5, ForceMode2D.Impulse);
        OrbCooldown = 0.5f;
        return;
    }

    void WebHook()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        MouseDirection = (MousePosition - transform.position);
        MouseDirection.Normalize();
        GameObject HookClone;
        HookClone = Instantiate(hook, transform.position, Quaternion.identity) as GameObject;
        /*
        1. shoot the hook
        2. let it fly
        3a. if out of range/hit nothing
        3a1. destroy

        3b. if collide with terrain
        3b1. yeets the player in the direction of the hook

        3c. if collide with enemy
        3c1. yeets the player in the diretion of the player
        */
        HookClone.GetComponent<VenomBallOrb>().Direction = MouseDirection;
        HookClone.GetComponent<VenomBallOrb>().InitalPosition = transform.position;
        HookClone.GetComponent<Rigidbody2D>().AddForce(MouseDirection * 7.5f, ForceMode2D.Impulse);
        HookCooldown = 0.5f;
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
    }

    //the abilities are updated here
    void DoAbility()
    {
        if(isWebActive)
        {
            if (WebDuration <= 0.0f)
            {
                isWebActive = false;
                return;
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                WebDuration -= Time.deltaTime;
            }
        }
    }
}
