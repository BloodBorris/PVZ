using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dave_Movement : MonoBehaviour
{

    int currentLane = 0;
    public GameObject bullet;
    public List<GameObject> Lanes = new List<GameObject>();
    public GameObject Dave;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Lanes[currentLane].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Actions();
    }

    void Actions()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentLane < 5)
            {
                currentLane += 1;
                transform.position = Lanes[currentLane].transform.position;
            }

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentLane > 0)
            {
                currentLane -= 1;
                transform.position = Lanes[currentLane].transform.position;
            }

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, Dave.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ZombBullet"))
        {
            Zombie_pool.Instance.ZombieGoback(gameObject);
        }
    }
}
