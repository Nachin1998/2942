using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject gun;
    public Bullet bullet;
    public float shootRate;
    public Explosion enemyExplosion;

    public AudioSource source;
    public AudioClip audios;
    float timer;
    float movementOverTime;
    Vector3 currentPos;
    Vector3 endPos;

    bool reachedFirstPos;
    bool reachedFinalPos;
    void Start()
    {
        timer = 0;
        movementOverTime = 0;
        source.clip = audios;
        currentPos = transform.position;
        endPos = -currentPos;

        reachedFirstPos = false;
        reachedFinalPos = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        movementOverTime += Time.deltaTime / 4;

        
        if(currentPos != endPos && !reachedFirstPos)
        {
            transform.position = Vector2.Lerp(currentPos, endPos, movementOverTime);
        }
        else
        {
            endPos = -currentPos;
            currentPos = transform.position;
            movementOverTime = 0;
            reachedFirstPos = true;
        }

        if (reachedFirstPos)
        {
            transform.position = Vector2.Lerp(currentPos, endPos, movementOverTime);
        }
        
        if (timer > shootRate)
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            source.Play();
            timer = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerBullet" ||
            col.gameObject.tag == "Shield")
        {
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
