using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFall : MonoBehaviour
{
    //activate this ability to break the player's fall. lasts for a few seconds

    public float Cooldown;
    public float Duration;
    public GameObject web;

    bool isActive = false;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Cooldown >= 0f)
        {
            Cooldown -= Time.deltaTime;
        }
        if (rigidbody.velocity.y < 0.0f && Input.GetKeyDown(KeyCode.M) && Cooldown <= 0.0f && !isActive)
        {
            Vector3 tempPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject web_clone;
            web_clone = Instantiate(web, tempPos, Quaternion.identity) as GameObject;
            DoAbility();
            isActive = true;
            Cooldown = 1.5f;
            Duration = 3f;
            return;
        }
        if(isActive)
        {
            DoAbility();
        }
    }

    void DoAbility()
    {
        if (Duration <= 0.0f)
        {
            isActive = false;
            return;
        }
        else
        {
            rigidbody.velocity = new Vector2(0, 0);
            Duration -= Time.deltaTime;
        }
       
    }
}
