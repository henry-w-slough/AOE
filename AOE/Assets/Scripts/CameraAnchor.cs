using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    //anchor handles camera rotation around Board for nice and smooth movement


    [Header("References")]
    [SerializeField] GameObject groundPrefab;
    [SerializeField] private GameHandler gameHandler;
    private Vector3 cameraRotationPoint;



    [Header("Values")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationTime;


    private Vector3 currentVelocity = new Vector3(0, 0, 0);






    void Start()
    {
        cameraRotationPoint = new Vector3(gameHandler.BOARD_WIDTH / 2 * gameHandler.TILE_WIDTH, 0f, gameHandler.BOARD_WIDTH / 2 * gameHandler.TILE_WIDTH);

        GameObject midPoint = Instantiate(groundPrefab, cameraRotationPoint, Quaternion.identity);
        midPoint.transform.localScale = new Vector3(2, 10, 2);
    }





    void Update()
    {  
        //camera rotation
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(cameraRotationPoint, Vector3.up, rotationSpeed * -horizontalInput);
    }
    


}
