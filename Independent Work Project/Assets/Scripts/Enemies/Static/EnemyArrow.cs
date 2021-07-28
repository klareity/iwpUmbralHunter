using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public Vector3 InitalPosition { get; set; }
    public GameObject itself;
    public float range;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position-InitalPosition).magnitude >= range)
        {
            Destroy(itself);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(itself);
            return;
        }
    }
}
