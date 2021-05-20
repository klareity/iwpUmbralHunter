using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomBallOrb : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    bool isActive;
    public Rigidbody2D rigidbody { get; set; }
    public GameObject orb;
    public float range;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
