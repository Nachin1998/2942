using UnityEngine;

public class BossBullet : Bullet
{
    public Vector3 target;
    Vector3 currentPos;
    void Start()
    {
        GetComponents();
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);

        if(transform.position == target)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }
}
