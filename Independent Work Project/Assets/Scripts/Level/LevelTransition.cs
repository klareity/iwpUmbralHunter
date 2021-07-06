using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    //current level at which the LevelTransitor is on
    public int CurrentLevel;
    //the next level's spawnpoint
    public Vector3 NextLevelSpawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            //Debug.Log(NextLevelSpawnpoint);
            collision.gameObject.transform.position = NextLevelSpawnpoint;
        }
        else
        {
            return;
        }
    }
}
