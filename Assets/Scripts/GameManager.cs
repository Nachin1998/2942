using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Boss boss;
    
    [Space]

    public GameObject playerHealthGUI;
    public GameObject gameOverMenu;
    public TextMeshProUGUI gameOverTitle;
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


    void Update()
    {
        PlayerUpdate();

        if (boss)
        {
            BossUpdate();
        }        
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
            gameOverTitle.text = "You lost";
            StartCoroutine(EndGame());
        }
    }

    void BossUpdate()
    {
        if (boss.isDead)
        {
            gameOverTitle.text = "You Won";
            player.won = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        gameOverMenu.SetActive(true);
    }
}
