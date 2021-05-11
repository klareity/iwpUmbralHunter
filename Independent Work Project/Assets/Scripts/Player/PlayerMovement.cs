using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement  , 0, 0) * Time.deltaTime * movementSpeed;

        if(Input.GetKeyDown("space") && Mathf.Abs(rigidbody2D.velocity.y) < 0.01f )
        {
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
        }
    }




}
