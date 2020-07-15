using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 1f;
    Vector2 scroll;
    MeshRenderer mr;
    
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        scroll = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        scroll.y += speed * Time.deltaTime;
        mr.sharedMaterial.SetTextureOffset("_MainTex", scroll);
    }

}
