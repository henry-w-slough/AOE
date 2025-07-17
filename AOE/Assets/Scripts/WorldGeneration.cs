using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    [Header("Prefabs")]
    [SerializeField] GameObject groundPrefab;



    [Header("Tile Generation")]
    [SerializeField] int minTileHeight;
    [SerializeField] int maxTileHeight;
    [SerializeField] int tileSeperation;



    [Header("Global Script")]
    [SerializeField] private GameHandler gameHandler;





    void Start()
    {
        GenerateTiles();
    }






    void GenerateTiles()
    {
        for (int x = 0; x < gameHandler.BOARD_WIDTH; x++)
        {
            for (int y = 0; y < gameHandler.BOARD_WIDTH; y++)
            {
                GameObject newTile = Instantiate(groundPrefab, new Vector3(x * gameHandler.TILE_WIDTH, Random.Range(minTileHeight * gameHandler.TILE_WIDTH, maxTileHeight * gameHandler.TILE_WIDTH), y * gameHandler.TILE_WIDTH), Quaternion.identity);
                
                newTile.transform.localScale = new Vector3(gameHandler.TILE_WIDTH, gameHandler.TILE_WIDTH, gameHandler.TILE_WIDTH);
            }
        }
    }
}
