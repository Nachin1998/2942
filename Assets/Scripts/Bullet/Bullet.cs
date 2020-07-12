using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;

    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D bc;
    [HideInInspector] public ParticleSystem ps;

    [HideInInspector] public Vector2 speed;

    public float timeUntillDestroyed;

    public void GetComponents()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        ps = GetComponentInChildren<ParticleSystem>();

        speed = new Vector2(0, movementSpeed);
    }

    public void MoveBullet()
    {
        rb.velocity = speed * Time.deltaTime;
    }

    public void DestroyBulletAfter(float time)
    {
        timeUntillDestroyed += Time.deltaTime;

        if(timeUntillDestroyed > time)
        {
            StartCoroutine(DestroyBullet());
        }
    }

    public IEnumerator DestroyBullet()
    {
        sr.color = Color.clear;
        Destroy(bc);
        ps.Stop();

        yield return new WaitForSeconds(0.3f);
        Destroy(ps);
        Destroy(gameObject);
    }
}
