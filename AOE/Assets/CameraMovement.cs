using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    //Used to rotate the parent of the camera which is placed in the middle of the game area. 
    //This allows for the camera to rotate relative to it's parent, giving the illusion it's rotating around the game area.

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;





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
        Rotation();


        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            MouseMovement();
        }

        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        

    }




    void MouseMovement()
    {
        float mouseVertical = Input.GetAxis("Mouse Y");
        float mouseHorizontal = Input.GetAxis("Mouse X");

        //getting move direction based on facing direction and input direction
        Vector3 moveDirection = orientation.forward * mouseVertical + orientation.right * mouseHorizontal;

        rb.AddForce(moveDirection * movementSpeed * 100f * Time.deltaTime, ForceMode.Force);
    }


    void Rotation()
    {
        float keyHorizontal = Input.GetAxisRaw("Horizontal");

        transform.Rotate(0f, keyHorizontal * rotationSpeed * Time.deltaTime, 0f);
    }
     



}
