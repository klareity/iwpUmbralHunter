using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//changed to web sling (temp name)
public class BreakFallWeb : MonoBehaviour
{
    public GameObject web;
    public Vector3 InitalPosition { get; set; }
    public Vector3 Direction { get; set; }

    public GameObject player { get; set; }
    public float range;
    public float speed;

    void Start()
    {
       
    }


    void Update()
    {
        if ((transform.position - InitalPosition).magnitude >= range)
        {
            DoSling();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("World"))
        {
            DoSling();

            return;
        }
    }

    void DoSling()
    {
        Direction = (transform.position - InitalPosition).normalized;
        //Direction.Normalize();
        Debug.Log(Direction);

        player.GetComponent<Rigidbody2D>().AddForce(Direction * speed, ForceMode2D.Impulse);
        Destroy(web);
        return;
    }
}
