using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 100;
    public GameObject head;
    public Explosion explosion;

    public bool isDead;
    void Start()
    {
        isDead = false;        
    }

    void Update()
    {
        if(health <= 0 && !isDead)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            isDead = true;
            Destroy(head);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerBullet")
        {
            health--;
        }
    }
}
