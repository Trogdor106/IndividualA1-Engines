using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager instance = null;

    public GameObject bullet;

    //Using a singleton to access data across all the files easily
    //TODO: create a structure to contain a collection of bullets
    Queue<GameObject> BulletPool = new Queue<GameObject>();
    public int MaxBullets;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {       
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < MaxBullets; i++)
        {
            GameObject newObject = Instantiate(bullet, this.transform);
            BulletPool.Enqueue(newObject);
            newObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        bullet = BulletPool.Dequeue(); //Pulls a bullet out of the queue
        bullet.SetActive(true);

        return bullet; //Returns the now active bullet
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        BulletPool.Enqueue(bullet);
        bullet.SetActive(false);
    }
}