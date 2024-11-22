using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Behaviour_Shooter : MonoBehaviour
{
    public GameObject Dave;
    public GameObject zombBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.5f * Time.deltaTime, 0, 0);

        InvokeRepeating("shoot", 3.0f, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Zombie_pool.Instance.ZombieGoback(gameObject);
        }
        if (other.tag == "Loss")
        {
            Destroy(Dave);
            Debug.Log("you lose you suck");
        }

    }

    void shoot()
    {
        Instantiate(zombBullet);
    }
}
