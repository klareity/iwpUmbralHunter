using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomBallOrb : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public Rigidbody2D rigidbody;
    public GameObject orb;
    public float range;
    public float speed;
    public Vector3 InitalPosition { get; set; }

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if((transform.position - InitalPosition).magnitude>= range)
        {
            Destroy(orb);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("World"))
        {
            Destroy(orb);
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("ouch");
            collision.gameObject.GetComponent<EnemyBase>().health -= 3;
            Destroy(orb);
            return;
        }
    }

}
