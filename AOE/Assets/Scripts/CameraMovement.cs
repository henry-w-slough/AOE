using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //camera handles camera, obviously. This class is used for movement around the world (board). Rotation is handled in seperate class.
    [Header("Rotation")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float zoomSpeed;



    private Rigidbody rb;
    private Transform orientation;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        orientation = GameObject.Find("Orientation").transform;
    }






    // Update is called once per frame
    void Update()
    {
        //setting orientation rotation so it faces in the same direction as the camera and allows the camera to be angled down without affecting movement
        orientation.rotation = new Quaternion(0f, transform.rotation.y, 0f, 1);


        //input from mouse for movement around the World
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Movement();
        }
        else
        {
            //releasing cursor
            Cursor.lockState = CursorLockMode.None;
        }




        //getting input for zooming in and out
        if (Input.GetKey(KeyCode.Q))
        {
            Zoom("forward");
        }

        if (Input.GetKey(KeyCode.E))
        {
            Zoom("backward");
        }

    }





    void Movement()
    {
        float mouseVertical = Input.GetAxisRaw("Mouse Y");
        float mouseHorizontal = Input.GetAxisRaw("Mouse X");

        //getting move direction based on facing direction and input direction
        Vector3 moveDirection = orientation.forward * mouseVertical + orientation.right * mouseHorizontal;

        rb.AddForce(moveDirection * movementSpeed * 100f * Time.deltaTime, ForceMode.Force);
    }





    void Zoom(string direction)
    {
        if (direction == "forward")
        {
            Vector3 moveDirection = transform.forward;
            rb.AddForce(moveDirection * zoomSpeed * 100f * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (direction == "backward")
        {
            Vector3 moveDirection = transform.forward;
            rb.AddForce(moveDirection * -zoomSpeed * 100f * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
     

}
