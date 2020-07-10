using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rb;
    Vector2 speed;

    GameObject child;

    float timer;
    bool activeTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, movementSpeed);

        child = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "PlayerBullet")
        {
            rb.velocity = speed * Time.deltaTime;
        }
        else if (gameObject.tag == "EnemyBullet")
        {
            rb.velocity = -speed * Time.deltaTime;
        }

        if (activeTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.5f)
        {
            Destroy(child);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
            activeTimer = true;
            gameObject.transform.DetachChildren();

            Destroy(child);

            Debug.Log("Bruh");
        
    }
}
