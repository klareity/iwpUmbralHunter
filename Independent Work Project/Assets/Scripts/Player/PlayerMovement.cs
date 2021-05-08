using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Transform transform2D;
    // Start is called before the first frame update
    void Start()
    {
        transform2D = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
