using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianScript : MonoBehaviour
{
    public int health;
    //set the boundaries of the enemy whilst patrolling. these should be positive numbers.
    public float minX;//the delta of how left the object can move
    public float maxX;//the delta of how right the object can move
    public Vector3 InitialPosition { set; get; }

    public bool isRight;//basically where is is facing
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
