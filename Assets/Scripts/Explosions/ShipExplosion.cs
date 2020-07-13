using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExplosion : Explosion
{
    // Start is called before the first frame update
    void Start()
    {
        SetSound();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterTime();
    }
}
