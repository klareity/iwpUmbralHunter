using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebHook : MonoBehaviour
{
    public Vector3 InitalPosition { get; set; }
    public Vector3 Direction { get; set; }
    //public Rigidbody2D rigidbody;
    public GameObject hook;
    public GameObject player { get; set; }
    public float range;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - InitalPosition).magnitude >= range)
        {
            
            Destroy(hook);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("World"))
        //{
        //    Direction = (transform.position - InitalPosition).normalized;
        //    //Direction.Normalize();
            
        //    //player.GetComponent<Rigidbody2D>().isKinematic = false;
        //    player.GetComponent<Rigidbody2D>().AddForce(Direction * speed, ForceMode2D.Impulse) ;          
        //    Destroy(hook);
        //    return;
        //}
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Direction = (InitalPosition - collision.gameObject.transform.position).normalized;
            //Direction.Normalize();
            Debug.Log(Direction);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Direction * speed, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<EnemyBase>().health -= 2;
            Destroy(hook);
            return;
        }
    }
}
