using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> audios = new List<AudioClip>();
    [HideInInspector] public int sound;
    float timer = 0;
    void Start()
    {
        sound = Random.Range(0, audios.Count);
        source.clip = audios[sound];
        source.Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            Destroy(gameObject);
        }        
    }
}
