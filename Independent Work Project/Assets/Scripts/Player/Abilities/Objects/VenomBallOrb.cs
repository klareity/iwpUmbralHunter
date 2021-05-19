using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomBallOrb : MonoBehaviour
{
    Vector3 OGPosition;
    Vector3 mousePos = new Vector3();
    Vector3 mouseDir;
    bool isActive;
    Rigidbody2D rigidbody;
    public GameObject orb;
    public float range;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        rigidbody = GetComponent<Rigidbody2D>();
        
        OGPosition = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

    }

    // Update is called once per frame
    void Update()
    {
        
        mouseDir = (mousePos - OGPosition).normalized;
        if ((transform.position - OGPosition).magnitude >= range)
        {
            Destroy(orb);
            return;
        }
        else
        {
            transform.position += mouseDir.normalized * Time.deltaTime * speed;
        }
        //Debug.Log(rigidbody.velocity);
    }
}
