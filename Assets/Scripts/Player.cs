using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Bullet bullet;
    public Shield shield;
    public GameObject[] gun;
    public float movement;

    Rigidbody2D rb;
    Vector2 input;
    Vector2 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = input * movement;

        Debug.Log(Input.GetAxisRaw("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < gun.Length; i++)
            {
                Instantiate(bullet, gun[i].transform.position, Quaternion.identity);
            }
        }

        if (!shield.isActive){
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(shield, transform.position, Quaternion.identity, transform);
            }
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
