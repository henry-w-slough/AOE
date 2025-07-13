using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    [Header("Tile Generation")]
    [SerializeField] GameObject groundPrefab;
    [SerializeField] float groundDistance;
    [SerializeField] int groundTiles;



    private GameObject[] allTiles;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allTiles = new GameObject[groundTiles * groundTiles];

        GenerateTiles();
    }






    void GenerateTiles()
    {
        for (int x = 0; x < groundTiles; x++)
        {
            for (int y = 0; y < groundTiles; y++)
            {
                allTiles[y] = Instantiate(groundPrefab, new Vector3(x * groundDistance, Random.Range(1, 10), y * groundDistance), Quaternion.identity);
                
            }
        }
    }


    void addNoiseToTiles()
    {
        
    }
}
