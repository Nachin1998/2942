using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    void Start()
    {
        GetComponents();
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    void Update()
    {
        DestroyBulletAfterTime();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" ||
            col.gameObject.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
            StartCoroutine(DestroyBullet());                       
        }
    }
}
