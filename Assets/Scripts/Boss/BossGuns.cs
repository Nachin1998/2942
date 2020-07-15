using UnityEngine;

public class BossGuns : MonoBehaviour
{
    enum GunsState
    {
        Searching, 
        Aiming
    }
    GunsState gunsState;

    public Player player;
    public BossBullet bullets;
    public GameObject gunCannon;
    public Explosion explosion;

    public int gunHealth = 15;
    float fireRate;
    float endFireTimer;

    public AudioSource source;
    public AudioClip audios;

    Vector2 target;
    float aimTimer;
    float fireTimer;
    float maxfireTimer;
    float shootRate;
    float rotation;
    bool lockOn;

    void Start()
    {
        source.clip = audios;

        gunsState = GunsState.Searching;
        fireRate = 0.2f;
        target = player.transform.position;
        lockOn = false;
        maxfireTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player || player.won)
        {
            return;
        }
        
        target = player.transform.position;

        if(gunHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (lockOn)
        {
            gunsState = GunsState.Aiming;
        }
        else
        {
            gunsState = GunsState.Searching;
        }

        switch (gunsState) {
            case GunsState.Searching:
                Search();
                break;

            case GunsState.Aiming:
                Fire();
                break;
        }        
    }

    void Search()
    {
        aimTimer += Time.deltaTime;

        if (aimTimer > 2)
        {
            lockOn = true;
        }
    }

    void Fire()
    {
        gameObject.transform.LookAt(target);
    
        endFireTimer += Time.deltaTime;
        fireTimer += Time.deltaTime;

        if(fireTimer > fireRate)
        {
            bullets.target = player.transform.position;
            Instantiate(bullets, gunCannon.transform.position, gunCannon.transform.rotation);
            source.Play();
            fireTimer = 0;
        }

        if(endFireTimer > maxfireTimer)
        {
            aimTimer = 0;
            fireTimer = 0;
            endFireTimer = 0;
            lockOn = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerBullet")
        {
            gunHealth--;
            Destroy(col.gameObject);
        }
    }
}
