using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
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
        if (col.gameObject.tag == "Player" ||
            col.gameObject.tag == "PlayerBullet")
        {
            Destroy(col.gameObject);
            StartCoroutine(DestroyBullet(true));
        }
    }
}
