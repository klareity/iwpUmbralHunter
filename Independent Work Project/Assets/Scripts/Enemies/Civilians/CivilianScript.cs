using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianScript : EnemyBase
{

    //waypoints that the ai should go to. there should be only 2
    public List<Vector2> Waypoints = new List<Vector2>();

    public float panicRadius;

    public bool isRight;//basically where is is facing

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
