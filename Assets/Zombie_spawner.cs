using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_spawner : MonoBehaviour
{

    int RLaneSelect = 0;
    Vector3 spawnPos;
    public List<GameObject> ZLanes = new List<GameObject>();
    float SpawnTime = 0;
    int spawnRate = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Random.Range(1, spawnRate + 1) == spawnRate)
        {
            RandomSpawn();
            if(spawnRate != 5)
            {
                spawnRate = spawnRate - 1;
            }
           
        }
            
        
    }

    void RandomSpawn()
    {
        RandomSelect();
        
        GameObject Zomb = Zombie_pool.Instance.getZombiefrompool();
        Zomb.transform.position = spawnPos;
        Debug.Log(Zomb.transform.position);

    }

    void RandomSelect()
    {
        RLaneSelect = Random.Range(0, 5);
       spawnPos = ZLanes[RLaneSelect].transform.position; ;
        Debug.Log(spawnPos + "Spawn pos");
    }
}
