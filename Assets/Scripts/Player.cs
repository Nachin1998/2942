using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject[] gun;
    public float movement;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * movement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movement);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movement);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < gun.Length; i++)
            {
                if (i%2==0)
                {
                    Instantiate(bullet, gun[0].transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(bullet, gun[1].transform.position, Quaternion.identity);
                }
            }
        }
    }
}
