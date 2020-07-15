using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public int lives;
    public float power;
    public float movement;

    [Space]

    public Bullet bullet;
    public Shield shield;
    public GameObject[] gun;
    public Explosion explosion;
    public Image powerBar;

    int maxX;
    int maxY;
    Rigidbody2D rb;
    Vector2 input;
    Vector2 velocity;

    [HideInInspector] public bool isDead;
    [HideInInspector] public bool gotHit;
    [HideInInspector] public bool won;

    [Space]
    [Header("Player Audio")]

    public AudioSource source;
    public AudioClip hitSound;
    public List<AudioClip> laserSounds = new List<AudioClip>();
    [HideInInspector] public int sound;

    private void Start()
    {
        lives = 5;
        power = 100f;
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        won = false;
        maxX = 16;
        maxY = 25;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxX, maxX), 
                                         Mathf.Clamp(transform.position.y, -maxY, maxY), 
                                         transform.position.z);

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = input * movement;

        if(power < 100)
        {
            power += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(PlayLaserSounds());
            PlayLaserSound();
            for (int i = 0; i < gun.Length; i++)
            {
                Instantiate(bullet, gun[i].transform.position, Quaternion.identity);
            }
        }

        if (power > 25 && !shield.isActive){
            if (Input.GetMouseButtonDown(1))
            {
                shield.gameObject.SetActive(true);
                shield.isActive = true;
                power -= 25;
            }
        }

        if(lives <= 0 && !isDead)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            isDead = true;
        }

        PowerBar();        
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyBullet" || 
           col.gameObject.tag == "Asteroid" ||
           col.gameObject.tag == "Enemy")
        {
            lives--;
            StartCoroutine(GotHitCheck());
            source.clip = hitSound;
            source.Play();
        }
    }

    void PowerBar()
    {
        powerBar.fillAmount = power / 100;

        if(power < 100 && power > 50) 
        {
            powerBar.color = Color.blue;
        }
        else if (power <  50 && power > 25)
        {
            powerBar.color = Color.yellow;
        }
        else if (power < 25 && power > 0)
        {
            powerBar.color = Color.red;
        }
    }

    public IEnumerator GotHitCheck()
    {
        gotHit = true;
        yield return new WaitForSeconds(0.2f);
        gotHit = false;
    }

    public void PlayLaserSound()
    {
        sound = Random.Range(0, laserSounds.Count);
        source.clip = laserSounds[sound];
        source.Play();
    }
}
