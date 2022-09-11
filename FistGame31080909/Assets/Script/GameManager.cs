using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Se la direzione del personaggio è verso destra è vera, altrimenti falsa
    /// tutto in funzione dello sprite
    /// </summary>
    public bool playerDirection = true;
    //=Oggetti dai quali estrapolo i vari script
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject coastTilemap;
    [SerializeField]private GameObject spawnEnemyTilemap;
    [SerializeField]private GameObject enemySlime;


    //= script o valori estrapolati dagli oggetti
    SpriteRenderer playerSprite;
    AmbientController coastController;
    Tilemap enemySpawn;
    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        coastController = coastTilemap.GetComponent<AmbientController>();
        enemySpawn = spawnEnemyTilemap.GetComponent<Tilemap>();
        SpawnEnemyOnMap();
    
    }
    private void FixedUpdate() 
    {
        if(playerSprite.flipX == false)
        {
            coastController.playerDirection = true;
            playerDirection = true;
        }
        else
        {
            coastController.playerDirection = false;
            playerDirection = false;

        }
        ///Se la vita del personaggio è diminuita togli un cuore dalla UI



    }

    /// <summary>
    /// Spawn i nemici all'interno della mappa
    /// </summary>
    private void SpawnEnemyOnMap()
    {
        BoundsInt bounds = enemySpawn.cellBounds;
        TileBase[] allTiles = enemySpawn.GetTilesBlock(bounds);    
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                        Instantiate(enemySlime,new Vector3(x + 0.5f,y + 0.5f,0),Quaternion.identity);

                }
            }
        }    
    }

}
