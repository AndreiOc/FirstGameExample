using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ArenaManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List <ArenaBlock> arenaBlocks;

    [SerializeField] private GameObject arenaBlockPrefab;
    [SerializeField] private float arenaBlockWidth = 100;
    [SerializeField] private GameObject playerReference;
    private int playerArenaBlockPosition;

    private int PlayerArenaBlockPositionFunction
    {
        get{return playerArenaBlockPosition;}
        set
        {   if(playerArenaBlockPosition != value){
                playerArenaBlockPosition = value;
                UpdateArenaModel();
            }
        
        }
    }
    private void Awake()
    {
        arenaBlocks = new List<ArenaBlock>(new ArenaBlock[9]);
        InitArena();
        playerReference = GameObject.FindGameObjectWithTag("Player");
        PlayerArenaBlockPositionFunction = arenaBlocks[4].position;//posizione centrale   
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerReference == null)
            playerReference = GameObject.FindGameObjectWithTag("Player");

        PlayerArenaBlockPositionFunction = GetArenaPositionClosestToPlayer();
    }
    private void UpdateArenaModel()
    {
        switch(PlayerArenaBlockPositionFunction)
        {
            case 0://=NORTH WEST
                PlaceArenaBlock(arenaBlocks[2], 0, 1);
                PlaceArenaBlock(arenaBlocks[6], 0, 1);
                PlaceArenaBlock(arenaBlocks[5], 0, 2);
                PlaceArenaBlock(arenaBlocks[7], 0, 2);
                PlaceArenaBlock(arenaBlocks[8], 0, 3);          

                //%Update arenaBlockPosition
                arenaBlocks[8].position = 0;
                arenaBlocks[5].position = 1;
                arenaBlocks[7].position = 3;
                arenaBlocks[0].position = 4;
                arenaBlocks[1].position = 5;
                arenaBlocks[3].position = 7;
                arenaBlocks[4].position = 8;



            break;
            case 1://=NORTH 
                PlaceArenaBlock(arenaBlocks[6], 1, 3);
                PlaceArenaBlock(arenaBlocks[7], 1, 3);
                PlaceArenaBlock(arenaBlocks[8], 1, 3);
         
                //%Update arenaBlockPosition
                arenaBlocks[6].position = 0;
                arenaBlocks[7].position = 1;
                arenaBlocks[8].position = 2;                
                arenaBlocks[0].position = 3;
                arenaBlocks[1].position = 4;
                arenaBlocks[2].position = 5;
                arenaBlocks[3].position = 6; 
                arenaBlocks[4].position = 7;
                arenaBlocks[5].position = 8;




            break;
            case 2://=NORTH EAST
                PlaceArenaBlock(arenaBlocks[0], 2, 1);
                PlaceArenaBlock(arenaBlocks[8], 2, 1);
                PlaceArenaBlock(arenaBlocks[3], 2, 2);
                PlaceArenaBlock(arenaBlocks[7], 2, 2);
                PlaceArenaBlock(arenaBlocks[6], 2, 3);
                  
                //%Update arenaBlockPosition
                //arenaBlocks[0].position = 0;
                arenaBlocks[3].position = 1;
                arenaBlocks[6].position = 2;                
                arenaBlocks[1].position = 3;
                arenaBlocks[2].position = 4;
                arenaBlocks[7].position = 5;
                arenaBlocks[4].position = 6; 
                arenaBlocks[5].position = 7;
                //arenaBlocks[5].position = 8;


                
            break;
            case 3://=WEST
                PlaceArenaBlock(arenaBlocks[2], 3, 3);
                PlaceArenaBlock(arenaBlocks[5], 3, 3);
                PlaceArenaBlock(arenaBlocks[8], 3, 3);

                  
                //%Update arenaBlockPosition
                arenaBlocks[2].position = 0;
                arenaBlocks[0].position = 1;
                arenaBlocks[1].position = 2;                
                arenaBlocks[5].position = 3;
                arenaBlocks[3].position = 4;
                arenaBlocks[4].position = 5;
                arenaBlocks[8].position = 6; 
                arenaBlocks[6].position = 7;
                arenaBlocks[7].position = 8;


            break;
            case 4:
                Debug.Log("Ciaone");
            break;
            case 5://=EAST
                PlaceArenaBlock(arenaBlocks[0], 5, 3);
                PlaceArenaBlock(arenaBlocks[3], 5, 3);
                PlaceArenaBlock(arenaBlocks[6], 5, 3);

                  
                //%Update arenaBlockPosition
                arenaBlocks[1].position = 0;
                arenaBlocks[2].position = 1;
                arenaBlocks[0].position = 2;                
                arenaBlocks[4].position = 3;
                arenaBlocks[5].position = 4;
                arenaBlocks[3].position = 5;
                arenaBlocks[7].position = 6; 
                arenaBlocks[8].position = 7;
                arenaBlocks[6].position = 8;

             
            break;
            case 6://= SOUTH WEST
                PlaceArenaBlock(arenaBlocks[0], 6, 1);
                PlaceArenaBlock(arenaBlocks[8], 6, 1);
                PlaceArenaBlock(arenaBlocks[1], 6, 2);
                PlaceArenaBlock(arenaBlocks[5], 6, 2);
                PlaceArenaBlock(arenaBlocks[2], 6, 3);

                  
                //%Update arenaBlockPosition
                //arenaBlocks[1].position = 0;
                arenaBlocks[3].position = 1;
                arenaBlocks[4].position = 2;                
                arenaBlocks[1].position = 3;
                arenaBlocks[6].position = 4;
                arenaBlocks[7].position = 5;
                arenaBlocks[2].position = 6; 
                arenaBlocks[5].position = 7;
                //arenaBlocks[6].position = 8;

                //%Update sorting layerPlaces

            break;            
            case 7://= SOUTH 
                PlaceArenaBlock(arenaBlocks[0], 7, 3);
                PlaceArenaBlock(arenaBlocks[1], 7, 3);
                PlaceArenaBlock(arenaBlocks[2], 7, 3);
                  
                //%Update arenaBlockPosition
                arenaBlocks[3].position = 0;
                arenaBlocks[4].position = 1;
                arenaBlocks[5].position = 2;                
                arenaBlocks[6].position = 3;
                arenaBlocks[7].position = 4;
                arenaBlocks[8].position = 5;
                arenaBlocks[0].position = 6; 
                arenaBlocks[1].position = 7;
                arenaBlocks[2].position = 8;

            
            break;  
            case 8://= SOUTH EAST
                PlaceArenaBlock(arenaBlocks[2], 8, 1);
                PlaceArenaBlock(arenaBlocks[6], 8, 1);
                PlaceArenaBlock(arenaBlocks[1], 8, 2);
                PlaceArenaBlock(arenaBlocks[3], 8, 2);
                PlaceArenaBlock(arenaBlocks[0], 8, 3);
                  
                //%Update arenaBlockPosition
                arenaBlocks[4].position = 0;
                arenaBlocks[5].position = 1;
                //arenaBlocks[5].position = 2;                
                arenaBlocks[7].position = 3;
                arenaBlocks[8].position = 4;
                arenaBlocks[1].position = 5;
                //arenaBlocks[0].position = 6; 
                arenaBlocks[3].position = 7;
                arenaBlocks[0].position = 8;



            break;  
            default:
            break;
        }        
        //!Sort
        arenaBlocks.Sort((x,y) => x.position.CompareTo(y.position));

    }
    private void InitArena(){
        for (int x = 0; x < 9; x++)
        {
            //instante gameobject
            GameObject gameObject = Instantiate(arenaBlockPrefab);
            gameObject.name = "blocco numero " + x;
            //estrapolo la tilemap dal mio oggetto

            //create arenablock  and rappresent it
            ArenaBlock arenaBlock = new ArenaBlock(){
                position = x,
                theObject = gameObject
            };
            
            //add to the list of arena block
            arenaBlocks[x] = arenaBlock;
            //then place in the wordl
            PlaceArenaBlock(arenaBlock,x);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private int GetArenaPositionClosestToPlayer()
    {
        float distant = Mathf.Infinity;
        int champPosition = -1;
        for (int i = 0; i < 9; i++)
        {
            //calculate distance
            ArenaBlock temp = arenaBlocks[i];
            float tmpDistance = Vector3.Distance(temp.theObject.transform.position,playerReference.transform.position);
            
            
            //check and update and champ
            if(tmpDistance < distant)
            {
                distant = tmpDistance;
                champPosition = temp.position;
            }
        }


        return champPosition;
    }


    /// <summary>
    /// Funzione che inserisce i valori all'interno del mondo
    /// !NB sposto anche l'oggetto che ho come valore
    /// </summary>
    /// <param name="arenaBlock">Blocco da posizionare all'interno del mio mondo</param>
    /// <param name="position">Posizion all'interno della matrice in cui mettero</param>
    /// <param name="steps"></param>
    private void PlaceArenaBlock(ArenaBlock arenaBlock, int position, int steps = 1)
    {
        Vector3 direction = GetDirectionFromPos(position) * steps;
        Vector3 currentPosition = arenaBlock.theObject.transform.position;

        Vector3 newPosition = currentPosition + new Vector3
            (
                (arenaBlockWidth) * direction.x,
                (arenaBlockWidth) * direction.y,
                0
            );
        arenaBlock.theObject.transform.position = newPosition;           
    }

    /// <summary>
    /// Ritorna il vettore da utilizzare per inserire nel nostro codice
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private Vector3 GetDirectionFromPos(int position)
    {
        switch (position)
        {
            case 0:   
                return new Vector3(-1,1,0);

            case 1:   
                return new Vector3(0,1,0);

            case 2:   
                return new Vector3(1,1,0);
            
            case 3:   
                return new Vector3(-1,0,0);
            
            case 4:   
                return new Vector3(0,0,0);
            
            case 5:   
                return new Vector3(1,0,0);
            
            case 6:   
                return new Vector3(-1,-1,0);
            
            case 7:   
                return new Vector3(0,-1,0);
            case 8:   
                return new Vector3(1,-1,0);
            default:
                return new Vector3(0,0,0);                
               
        }
    }
    public class ArenaBlock
    {
        public int position;
        public GameObject theObject;
    }
}
