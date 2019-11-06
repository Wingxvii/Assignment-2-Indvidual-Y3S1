using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogicManagers
{
    public class BulletFactory : MonoBehaviour
    {
        #region SingletonCode
        private static BulletFactory _instance;
        public static BulletFactory Instance { get { return _instance; } }
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

        public float bulletSpeed { set; get; } = 0.0f;
        public float horizontalSpeed { set; get; } = 0.0f;


        //TODO: Here is also the factory
        public GameObject GetBullet()
        {
            GameObject factoryProduct = BulletPoolManager.Instance.GetBullet();
            factoryProduct.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            factoryProduct.GetComponent<BulletController>().horizontalSpeed = horizontalSpeed;
            return factoryProduct;
        }

    }

}