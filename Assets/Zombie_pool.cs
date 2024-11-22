using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Zombie_pool : MonoBehaviour
{
    public Queue<GameObject> zGrave = new Queue<GameObject>();
    public Queue<GameObject> zGraveShooter = new Queue<GameObject>();
    int ZpoolSize = 50;
    int ZpoolSizeShooter = 50;
    public GameObject zombie_pref;
    public GameObject zombie_pref_Shooter;
    public static Zombie_pool Instance;



    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < ZpoolSize; i++)
        {
            GameObject zombie = Instantiate(zombie_pref);
            zombie.SetActive(false);
            zGrave.Enqueue(zombie);
        }
        for (int i = 0; i < ZpoolSizeShooter; i++)
        {
            GameObject zombie = Instantiate(zombie_pref_Shooter);
            zombie.SetActive(false);
            zGrave.Enqueue(zombie);
        }
    }


    public GameObject getZombiefrompool()
    {
        if (Random.Range(1, 5 + 1) <= 3)
        {
            if (zGrave.Count > 0)
            {
                GameObject zombie = zGrave.Dequeue();
                zombie.SetActive(true);
            }
        }
        else
        {
            if (zGrave.Count > 0)
            {
                GameObject zombie = zGraveShooter.Dequeue();
                zombie.SetActive(true);
            }
        }
           
           
        return zombie_pref;
    }

    public void ZombieGoback(GameObject newZombie)
    {
        zombie_pref.SetActive(false);
        zGrave.Enqueue(zombie_pref);
    }
}
