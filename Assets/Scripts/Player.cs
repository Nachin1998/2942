using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int lives;
    public float power;
    public float movement;

    [Space]

    public Bullet bullet;
    public Shield shield;
    public GameObject[] gun;

    [Space]

    public Image powerBar;

    int maxX;
    int maxY;
    Rigidbody2D rb;
    Vector2 input;
    Vector2 velocity;

    public bool isDead;

    private void Start()
    {
        lives = 3;
        power = 100f;
        rb = GetComponent<Rigidbody2D>();
        isDead = false;

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
            for (int i = 0; i < gun.Length; i++)
            {
                Instantiate(bullet, gun[i].transform.position, Quaternion.identity);
            }
        }

        if (power > 25){                                        //REVISAR SI EL ESCUDO YA EXISTE
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(shield, transform.position, Quaternion.identity, transform);
                power -= 25;
            }
        }

        if(lives <= 0)
        {
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
        if(col.gameObject.tag == "EnemyBullet")
        {
            lives--;
        }        
    }

    void PowerBar()
    {
        powerBar.fillAmount = power / 100;

        if(power < 100 && power > 50) {
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
}
