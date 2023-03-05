using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to the parent object of the Main Camera called "Camera Pivot"
// Code source: https://gamedevacademy.org/unity-city-building-game-tutorial/

public class RTSCameraController : MonoBehaviour
{
    public float moveSpeed;

    public float minXRot;
    public float maxXRot;

    private float curXRot;

    public float minZoom;
    public float maxZoom;

    public float zoomSpeed;
    public float rotateSpeed;

    private float curZoom;
    private Camera cam;

    private float moveEdgeBorder; // Pixels. The width border at the edge in which the movement work
    private Vector3 moveRightDirection; // Direction the camera should move when on the right edge

    public GameObject player;
    private Animator animator;
    private Vector3 idle;

    // public Transform playerTransform;
    // public float smoothSpeed = 0.125f;
    // public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = -50;

        moveEdgeBorder = 10; // Width of the border at screen edge in pixels
        moveRightDirection = transform.right;

        // Get a reference to the Animator component
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Camera zoom (scroll wheel)
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

        cam.transform.localPosition = Vector3.up * curZoom;

        // Camera rotation (right mouse button)
        if(Input.GetMouseButton(1)) {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            
            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

            transform.eulerAngles = new Vector3(curXRot, transform.eulerAngles.y + (x * rotateSpeed), 0.0f);
        }

        // // Camera movement (WASD keys)
        Vector3 forward = cam.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = cam.transform.right.normalized;

        float moveXKeyboard = Input.GetAxisRaw("Horizontal");
        float moveZKeyboard = Input.GetAxisRaw("Vertical");

        Vector3 dirKeyboard = forward * moveZKeyboard + right * moveXKeyboard;
        dirKeyboard.Normalize();

        dirKeyboard *= moveSpeed * Time.deltaTime;

        transform.position += dirKeyboard;

        // Vector3 idle = dirKeyboard;

        // if(transform.position != dirKeyboard) {
        //     animator.SetFloat("ForwardSpeed", 0.5f);
        // } else if (transform.position == dirKeyboard) {
        //     animator.SetFloat("ForwardSpeed", 0f);
        // } else if (dirKeyboard.Equals(Vector3.zero)) {
        //     Debug.Log("No keys being pressed.");
        // }

        // Debug.Log(dirKeyboard);

        // Camera movement (mouse to screen edge)
        float moveXMouse = 0;
        float moveZMouse = 0;

        // Check if on the right edge
        // if (Input.mousePosition.x >= Screen.width - moveEdgeBorder) {
        //     moveXMouse = 1;
        // }
        // else if (Input.mousePosition.x >= 0 + moveEdgeBorder) {
        //     moveXMouse = -1;
        // }
        // else if (Input.mousePosition.y >= 0 + moveEdgeBorder) {
        //     moveZMouse = -1;
        // }
        // else if (Input.mousePosition.y >= Screen.height - moveEdgeBorder) {
        //     moveZMouse = -1;
        // }

        // Vector3 dirMouse = forward * moveZMouse + right * moveXMouse;
        // dirMouse.Normalize();

        // dirMouse *= moveSpeed * Time.deltaTime;
        // // Move the camera
        // transform.position += dirMouse * Time.deltaTime * moveSpeed;
    }
}
