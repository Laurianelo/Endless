using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilesPrefabs;

    public float zSpawn = 0;
    public float tileLenght = 30;
    public int numberOfTiles = 5;
    public Transform player;
    private List<GameObject> activeTiles = new List<GameObject>();
    private void Start()
    {
        Time.timeScale = 1;// when we restart the level
        WhichTile();
    }

    private void Update()
    {
        if (player.position.z - 35 > zSpawn - (numberOfTiles * tileLenght))
        {
            SpawnTile(Random.Range(0, tilesPrefabs.Length));
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void WhichTile()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilesPrefabs.Length));
            }
        }
    }

    public void SpawnTile(int index)
    {
        GameObject tileInstantiate = Instantiate(tilesPrefabs[index], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tileInstantiate);
        zSpawn += tileLenght;
    }

}
