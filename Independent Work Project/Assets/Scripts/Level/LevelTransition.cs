using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//where all the spawning, restarting, changing level stuff happens
public class LevelTransition : MonoBehaviour
{
    //current level at which the LevelTransitor is on
    public int CurrentLevel;
    //the next level's spawnpoint
    public Vector3 NextLevelSpawnpoint;
    //list of all the level's spawnpoint
    public List<Vector3> Spawnpoints = new List<Vector3>();

    //list of prefabs for the thing to spawn in
    public GameObject[] GameObjects;

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

    //this function destroys all currently active gameobjects that are tagged as "Interactables" and "Enemy"
    public void ClearGameObjects()
    {
        GameObject[] interactables;
        GameObject[] enemies;

        interactables = GameObject.FindGameObjectsWithTag("Interactables");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject go in interactables)
        {
            Destroy(go);
        }
        foreach(GameObject go2 in enemies)
        {
            Destroy(go2);
        }
    }

    //this function spawns in all the objects of a certain level (Interactables and Enemy)
    public void SpawnInObjects()
    {
        switch(CurrentLevel)
        {
            case 1:
                {
                    GameObject pewpew = Instantiate(GameObjects[3],new Vector3(-6.67f, 15.19f, 0), Quaternion.identity);
                    pewpew.GetComponent<ArrowDispensor>().Direction = ArrowDispensor.direction.UP;
                    break;
                }
        }
    }

    public void OnRestartClick()
    {
        ClearGameObjects();
        SpawnInObjects();
    }

    public void OnPreviousLevelClick()
    {
        if(CurrentLevel <= 1)
        {
            return;
        }
        //change level
        ClearGameObjects();
        SpawnInObjects();
    }

    public void OnNextLevelClick()
    {
        if(CurrentLevel >= 7)
        {
            return;
        }
        //change level
        ClearGameObjects();
        SpawnInObjects();
    }
}
