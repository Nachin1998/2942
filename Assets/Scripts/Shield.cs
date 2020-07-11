using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float rotationSpeed;
    Vector3 rotation;
    float activatioTimer;
    public bool isActive;
    void Start()
    {
        rotation = new Vector3(0, 0, rotationSpeed);
        activatioTimer = 0;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = true;
        activatioTimer += Time.deltaTime;

        transform.position = transform.parent.gameObject.transform.position;
        transform.Rotate(rotation * Time.deltaTime);

        if(activatioTimer > 5)
        {
            isActive = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
        }
    }
}
