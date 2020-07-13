using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    [HideInInspector] public float speed;
    
    Vector2 movement;
    Rigidbody2D rb;

    public Explosion asteroidExplosion;
    float randRotation;
    float timer =0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, speed);

        randRotation = Random.Range(-2, 2);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }


    private void FixedUpdate()
    {
        rb.velocity = movement * Time.deltaTime;
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(0, 0, randRotation);

        if(timer > 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Shield" ||
           col.gameObject.tag == "PlayerBullet" ||
           col.gameObject.tag == "Player")
        {            
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Enemy")
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
