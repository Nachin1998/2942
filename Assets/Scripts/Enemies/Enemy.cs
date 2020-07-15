using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    public GameObject gun;
    public Bullet bullet;
    public float shootRate;
    public Explosion enemyExplosion;

    [Space]

    [Header("Enemy Audio")]
    public AudioSource source;
    public AudioClip audios;

    float timer;
    float movementOverTime;
    Vector3 currentPos;
    Vector3 endPos;

    void Start()
    {
        timer = 0;
        movementOverTime = 0;
        source.clip = audios;
        currentPos = transform.position;
        endPos = -currentPos;
    }

    void Update()
    {
        timer += Time.deltaTime;
        movementOverTime += Time.deltaTime / 6;        

        transform.position = Vector2.Lerp(currentPos, endPos, movementOverTime);
        
        if (timer > shootRate)
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            source.Play();
            timer = 0;
        }

        if (transform.position == endPos)
        {
            Destroy(gameObject);
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
