using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Transform transform2D;
    Vector2 finalpos;
    // Start is called before the first frame update
    void Start()
    {
        transform2D = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float Horizontalmovement = 0f;
        float Verticalmovement = 0f;

        Horizontalmovement = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.Space))
        {
            Verticalmovement = 80f;
        }

        Vector3 movement = new Vector3(Horizontalmovement, Verticalmovement, 0);//add jumping later

        finalpos = transform2D.position + movement.normalized;

        transform2D.position = Vector2.MoveTowards(transform2D.position, finalpos, Time.fixedDeltaTime * movementSpeed);
    }
}
