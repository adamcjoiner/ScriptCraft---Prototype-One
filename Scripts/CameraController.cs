using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Code source: https://gamedevacademy.org/unity-city-building-game-tutorial/
    public bool orthographic;
    public float moveSpeed;

    public float minXRot = -85;
    public float maxXRot = -2;
    public float minCamXRot = 75;
    public float maxCamXRot = 90;


    public float minZoom = 9;
    public float maxZoom = 50;
    public float minOrthoSize = 4;
    public float maxOrthoSize = 20;

    public float zoomSpeed = 20;
    public float rotateSpeed = 3;

    private float curXRot;
    private float curCamXRot = 90;
    private float curZoom = 30;
    private float curOrthoSize = 14;

    private Camera cam;

    private float moveEdgeBorder; // Pixels. The width border at the edge in which the movement work
    private Vector3 moveRightDirection; // Direction the camera should move when on the right edge
    public GameObject player;
    public Transform playerTransform;
    private Animator animator;
    private Vector3 idle;
    private Vector3 targetForward;
    private Vector3 targetRight;
    
    public float turnSpeed = 3;
    public float smoothTime = 0.1f;
    private Vector3 smoothVelocity = Vector3.zero;

    private void setOrthographic() {
        cam.orthographic = true;
        cam.orthographicSize = curOrthoSize;
        minXRot = -50;
        minCamXRot = 87.2f;
        maxCamXRot = 90;
        cam.transform.localEulerAngles = new Vector3(minCamXRot, 0.0f, 0.0f);
        cam.transform.localPosition = Vector3.up * 30; // reset perspective zoom
        cam.orthographicSize = curOrthoSize; // set orthographic zoom
    }

    private void setPerspective() {
        cam.orthographic = false;
        minXRot = -85;
        minCamXRot = 75;
        maxCamXRot = 90;
        cam.transform.localPosition = Vector3.up * curZoom; // set perspective zoom
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        // Set Camera to initial view parameters
            if (orthographic) {
                setOrthographic();
                curXRot = -25;
            } else {
                setPerspective();
                curXRot = -5;
            }

            transform.eulerAngles = new Vector3(curXRot, 0.0f, 0.0f);

        moveEdgeBorder = 10; // Width of the border at screen edge in pixels
        moveRightDirection = transform.right;

        // Get a reference to the Animator component
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Camera zoom (scroll wheel)
        
            // if orthographic
            if (orthographic) {
                setOrthographic();
                curOrthoSize += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
                curOrthoSize = Mathf.Clamp(curOrthoSize, minOrthoSize, maxOrthoSize);

                cam.orthographicSize = curOrthoSize;

            // if perspective
            } else {
                setPerspective();
                curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
                curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

                cam.transform.localPosition = Vector3.up * curZoom;
            }
        

        // Camera rotation (right mouse button)
        if(Input.GetMouseButton(1)) {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            
            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

            transform.eulerAngles = new Vector3(curXRot, transform.eulerAngles.y + (x * rotateSpeed), 0.0f);

            // Calculate X rotation for Main Camera based on current zoom level
            float zoomPercent = Mathf.InverseLerp(maxZoom, minZoom, curZoom);
            float mainCameraX = Mathf.Lerp(minCamXRot, maxCamXRot, Mathf.InverseLerp(minXRot, maxXRot, curXRot * zoomPercent));
            cam.transform.localEulerAngles = new Vector3(mainCameraX, 0.0f, 0.0f);
        } else {
            // Calculate X rotation for Main Camera based on current zoom level and Camera Pivot X rotation
            float zoomPercent = Mathf.InverseLerp(maxZoom, minZoom, curZoom);
            float mainCameraX = Mathf.Lerp(minCamXRot, maxCamXRot, Mathf.InverseLerp(minXRot, maxXRot, curXRot * zoomPercent));
            cam.transform.localEulerAngles = new Vector3(mainCameraX, 0.0f, 0.0f);
        }
    }
}
