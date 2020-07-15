using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private ParticleSystem ps;

    [HideInInspector] public Vector2 speed;

    float timer = 0;
    public float delayUntillDestroyed;

    public void GetComponents()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInChildren<ParticleSystem>();

        speed = new Vector2(0, movementSpeed);
    }

    public void MoveBullet()
    {
        rb.velocity = speed * Time.deltaTime;
    }

    public void DestroyBulletAfterTime()
    {
        timer += Time.deltaTime;

        if(timer > delayUntillDestroyed)
        {
            StartCoroutine(DestroyBullet());
        }
    }

    public IEnumerator DestroyBullet()
    {
        sr.color = Color.clear;
        ps.Stop();

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
