using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Classe ceh gestice letteralmente la mia scacchiera 
/// </summary>
public class Grid : MonoBehaviour
{

    [SerializeField] private int size = 25;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile [] tiles;
    [SerializeField] private GameObject [] prefabsTiles;
    public float waterLevel = 0.4f;
    Cell[,] grid;
    float[,]noiseMap;

    public float scale = 0.1f;
    void Start()
    {

        noiseMap = new float[size,size];
        float xOffset = Random.Range(-10000f,10000f);
        float yOffset = Random.Range(-10000f,10000f);
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset ,y * scale + yOffset);
                noiseMap[x,y] = noiseValue;
            }
        }

        grid = new Cell[size,size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Cell cell = new Cell();
                cell.isWater = true;
                grid[x,y] = cell;
            }
        }
    
        float[,] fallOffMap = new float [size,size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
        
        
            }
        }        
    }



    private void OnDrawGizmos()
    {
        if(!Application.isPlaying) return;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Cell cell = grid[x,y];
                float noiseValue = noiseMap[x,y];
                cell.isWater =  noiseValue < waterLevel;
                tilemap.SetTile(new Vector3Int(x,y,0),tiles[0]);
            }
        }
    }
    public class Cell 
    {   
        public bool isWater;
        public bool isCoast;
        
    }
}
