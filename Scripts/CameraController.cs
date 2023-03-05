using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Code source: https://gamedevacademy.org/unity-city-building-game-tutorial/
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
    public Transform playerTransform;
    private Animator animator;
    private Vector3 idle;
    private Vector3 targetForward;
    private Vector3 targetRight;
    
    public float turnSpeed;
    public float smoothTime = 0.1f;
    private Vector3 smoothVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = -15;

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

        float moveXMouse = 0;
        float moveZMouse = 0;

    void LateUpdate()
    {
        // Get player's forward and right vectors, ignoring y-axis
        Vector3 playerForward = playerTransform.forward;
        playerForward.y = 0.0f;
        playerForward.Normalize();
        Vector3 playerRight = playerTransform.right;
        playerRight.y = 0.0f;
        playerRight.Normalize();

        // Smoothly interpolate camera's forward and right vectors to match player's
        Vector3 targetForward = playerForward;
        Vector3 targetRight = playerRight;
        transform.forward = Vector3.SmoothDamp(transform.forward, targetForward, ref smoothVelocity, smoothTime);
        transform.right = Vector3.SmoothDamp(transform.right, targetRight, ref smoothVelocity, smoothTime);

        // Move camera along the player's forward and right vectors
        float moveXKeyboard = Input.GetAxisRaw("Horizontal");
        float moveZKeyboard = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = playerForward * moveZKeyboard + playerRight * moveXKeyboard;
        transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;

        // Rotate camera around player
        // if (Input.GetMouseButton(1))
        // {
        //     float mouseX = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        //     transform.RotateAround(playerTransform.position, Vector3.up, mouseX);
        // }
    }
    }
}
