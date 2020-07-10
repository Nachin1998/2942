using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < gun.Length; i++)
            {
                Instantiate(bullet, gun[i].transform.position, Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
