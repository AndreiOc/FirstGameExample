using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RefillTilemap : MonoBehaviour
{
    // Start is called before the first frame update
    private Tilemap tilemap;
    [SerializeField]private Tile[] tile;
    [SerializeField]private int size = 10;
    void Start()
    {
        GameObject grid = GameObject.FindWithTag("GridMap");
        transform.SetParent(grid.transform);
        tilemap = GetComponent<Tilemap>();   
        //center
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                // if(x==0 || x == size -1 || y ==0 || y == size -1 )
                //     tilemap.SetTile(new Vector3Int(x,y,0),tile[0]);
                // else
                //     tilemap.SetTile(new Vector3Int(x,y,0),tile[1]);

            }
        }  
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
