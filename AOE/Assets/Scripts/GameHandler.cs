using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [SerializeField] public int BOARD_WIDTH;
    [SerializeField] public int TILE_WIDTH;

    [SerializeField] private GameObject grassTileTEMP;



    private void Start()
    {
        for (int x = 0; x < BOARD_WIDTH; x++)
        {
            for (int y = 0; y < BOARD_WIDTH; y++)
            {
                GameObject newTile = Instantiate(grassTileTEMP, new Vector3(x * TILE_WIDTH, 0f, y * TILE_WIDTH), Quaternion.identity);

                newTile.transform.localScale = new Vector3(TILE_WIDTH, TILE_WIDTH, TILE_WIDTH);
            }
        }
    }

}
