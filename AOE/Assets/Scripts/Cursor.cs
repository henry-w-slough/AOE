using UnityEngine;

public class Cursor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameHandler gameHandler;
    private Camera cam;




    [Header("Values")]
    [SerializeField] private float cursorLerpTime;






    void Start()
    {
        cam = Camera.main;

        transform.localScale = new Vector3(gameHandler.TILE_WIDTH, 1f, gameHandler.TILE_WIDTH);
    }





    void Update()
    {
        //defining the ray that is based on where the mouse is on the screen
        Ray mouseWorldRay = cam.ScreenPointToRay(Input.mousePosition);
        //sending the ray and checking for hits
        if (Physics.Raycast(mouseWorldRay, out RaycastHit mouseWorldHit))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(mouseWorldHit.transform.position.x, mouseWorldHit.transform.position.y + gameHandler.TILE_WIDTH, mouseWorldHit.transform.position.z), cursorLerpTime);
        }

        


    }
}
