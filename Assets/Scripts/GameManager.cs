using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;

    [Space] public GameObject playerHealthGUI;
    [Space] public GameObject gameOverMenu;

    Image playerHealth;
    public Animator anim;
    Color orange;
    bool lastShake = false;
    void Start()
    {
        gameOverMenu.SetActive(false);
        playerHealth = playerHealthGUI.GetComponent<Image>();

        playerHealth.color = Color.clear;

        orange = new Color(1f, 0.45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUpdate();       
    }

    void PlayerUpdate()
    {        
        if (player.gotHit)
        {
            anim.Play("Shake");
            switch (player.lives)
            {
                case 5:
                case 4:
                    playerHealth.color = Color.green;
                    break;
                case 3:
                    playerHealth.color = Color.yellow;
                    break;
                case 2:
                    playerHealth.color = orange;
                    break;
                case 1:
                    playerHealth.color = Color.red;
                    break;
                case 0: 
                    playerHealth.color = Color.black;                    
                    break;
            }
        }
        else
        {
            playerHealth.color = Color.clear;
        }

       
        if (player.isDead)
        {
            if (!lastShake)
            {
                StartCoroutine(player.GotHitCheck());
                lastShake = true;
            }
            
            playerHealth.color = Color.black;
            gameOverMenu.SetActive(true);
        }
    }
}
