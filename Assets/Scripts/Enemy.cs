using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject gun;
    public Bullet bullet;
    public float shootRate;
    public Explosion enemyExplosion;
    float timer;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > shootRate)
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerBullet")
        {
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
