using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            Debug.Log("This nigga dead");
        }
    }
}
