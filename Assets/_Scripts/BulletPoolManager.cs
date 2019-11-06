using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

namespace GameLogicManagers
{

    [System.Serializable]
    public class BulletPoolManager : MonoBehaviour
    {
        #region SingletonCode
        private static BulletPoolManager _instance;
        public static BulletPoolManager Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        #endregion

        public GameObject bulletObject;

        public GameObject bullet;
        public int poolSize = 50;

        //TODO: create a structure to contain a collection of bullets
        public Queue<GameObject> bulletPool = new Queue<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            // TODO: add a series of bullets to the Bullet Pool
            for (int counter = 0; counter < poolSize; counter++)
            {
                bullet = GameObject.Instantiate(bulletObject, Vector3.zero, Quaternion.identity);
                bulletPool.Enqueue(bullet);
                bullet.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        //TODO: modify this function to return a bullet from the Pool
        public GameObject GetBullet()
        {
            bulletPool.Peek().SetActive(true);
            return bulletPool.Dequeue();
        }

        public GameObject GetBullet(float speed)
        {
            bulletPool.Peek().SetActive(true);
            bulletPool.Peek().GetComponent<BulletController>().bulletSpeed = speed;
            return bulletPool.Dequeue();
        }

        public GameObject GetBullet(float speed, float horizontalSpeed)
        {
            bulletPool.Peek().SetActive(true);
            bulletPool.Peek().GetComponent<BulletController>().bulletSpeed = speed;
            bulletPool.Peek().GetComponent<BulletController>().horizontalSpeed = horizontalSpeed;
            return bulletPool.Dequeue();
        }


        //TODO: modify this function to reset/return a bullet back to the Pool 
        public void ResetBullet(GameObject bullet)
        {
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
}