using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogicManagers;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public float horizontalSpeed = 0.0f;
    public Boundary boundary;

    //TODO: create a reference to the BulletPoolManager

    void Start()
    {
        boundary.Top = 2.45f;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(horizontalSpeed, bulletSpeed, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.y >= boundary.Top)
        {
            //TODO: This code needs to change to use the BulletPoolManager's
            //TODO: ResetBullet function which will return the bullet to the pool
            BulletPoolManager.Instance.ResetBullet(this.gameObject);
        }
    }
}
