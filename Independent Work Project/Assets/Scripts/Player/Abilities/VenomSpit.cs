using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomSpit : MonoBehaviour
{
    Vector3 mousePos = new Vector3();
    public GameObject VenomBall;

    bool isActive;


    public float range;
    public float cooldown;
    public float speed;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown >= 0f)
        {
            cooldown -= Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.B) && cooldown <= 0.0f)
        {
            GameObject VenomballClone;
            VenomballClone = Instantiate(VenomBall, transform.position, Quaternion.identity) as GameObject;
            cooldown = 0.5f;
            return;
        }
    }
}
