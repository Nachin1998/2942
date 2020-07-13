using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    [Space] public GameObject gameOverMenu;
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            gameOverMenu.SetActive(true);
        }
    }
}
