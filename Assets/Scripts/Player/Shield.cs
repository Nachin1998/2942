using UnityEngine;

public class Shield : MonoBehaviour
{
    public float rotationSpeed;
    public bool isActive;
    public float timeUntilDeactive;
    Vector3 rotation;
    float activatioTimer;
    void Start()
    {
        isActive = false;
        rotation = new Vector3(0, 0, rotationSpeed);
        activatioTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            activatioTimer += Time.deltaTime;
            transform.position = transform.parent.gameObject.transform.position;
            transform.Rotate(rotation * Time.deltaTime);

            if (activatioTimer > timeUntilDeactive)
            {
                isActive = false;
                activatioTimer = 0;
            }
        }
        else
        {
            gameObject.SetActive(false);          
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyBullet" ||
            col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
