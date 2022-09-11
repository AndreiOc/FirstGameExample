using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class PlayerUIManager : MonoBehaviour
{


    [SerializeField]private Image animatedImage;
    [SerializeField]private GameObject player;
    public TextMeshProUGUI killsScore;
    private DamageableCharacter damageablePlayer;
    private float currentHealth;
    public int health = 5;
    int score = 0;
    /// <summary>
    /// 0 = full hearthSprites
    /// 1 = empty hearthSprites
    /// </summary>
    [SerializeField]private Sprite [] hearthSprites;
    [SerializeField] private Image [] heartImage;
    public float offset;
    public float startX;
    public float startY;
    // Start is called before the first frame update
    private void Awake()
    {
        animatedImage.GetComponent<UISpriteAnimation>().Func_PlayUIAnim();    

    }
    private void Start()
    {
        damageablePlayer = player.GetComponent<DamageableCharacter>();
        currentHealth = damageablePlayer.health;
        float x = startX;
        for (int i = 0; i < health; i++)
        {
            heartImage[i].rectTransform.anchoredPosition = new Vector2(x,startY);
            x = x + offset; 
        }

    }
    private void FixedUpdate()
    {
        if(currentHealth!= damageablePlayer.health)
        {
            HealthDown(); 
            currentHealth = damageablePlayer.health;
        }   
    }

    public void HealthDown()
    {
        health = health -1 ;
        heartImage[health].sprite = hearthSprites[1];
    }

    public void IncreaseScore()
    {
        score = score + 1;
        killsScore.text = "Slime : " + score;
        if(score == 4)
            WinGame();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(3);
    }
    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }
}
