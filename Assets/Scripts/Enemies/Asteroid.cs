using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [HideInInspector] public float speed;

    Vector2 movement;
    Rigidbody2D rb;

    public Explosion asteroidExplosion;
    float randRotation;
    float timer = 0;
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

        if (timer > 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            StartCoroutine(ChangeBodyType());
        }
        else if (col.gameObject.tag != "Asteroid")
        {
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator ChangeBodyType()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(4f);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
