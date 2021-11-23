using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilesPrefabs;

    public float zSpawn = 0;
    public float tileLenght = 30;
    public int numberOfTilesTime = 6;
    public Transform player;
    private List<GameObject> activeTiles = new List<GameObject>();
    private int nbTile;
    private bool end ;

    private void Start()
    {
        end = false;
        nbTile = 0;
        Time.timeScale = 1;// when we restart the level
         GenerateTile();
    }

    private void Update()
    {
        ManageTile();
    }


    //management of tile generation
    private void ManageTile()
    {
        if (player.position.z - 35 > zSpawn - (numberOfTilesTime * tileLenght) && end == false)
        {
            if (nbTile == 19)
            {
                end = true;
                SpawnTile(7);
                SpawnTile(0);
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, 7));
                DeleteTile();
                ;
            }
        }
    }


    //delete tile 
    //list and obj
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }


    //spawn tile when the game start
    private void GenerateTile()
    {
        for (int i = 0; i < numberOfTilesTime; i++)
        {
            if (i == 0 || i == 1 )
            {
                SpawnTile(0); // generate the first tile 
            }
            else
            {
                SpawnTile(Random.Range(1, 6));
            }
        }
    }

    //instantiate tile
    public void SpawnTile(int index)
    {
        GameObject tileInstantiate = Instantiate(tilesPrefabs[index], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tileInstantiate);
        nbTile++;
        zSpawn += tileLenght;
    }

}
