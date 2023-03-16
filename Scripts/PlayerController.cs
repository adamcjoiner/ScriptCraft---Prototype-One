using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed = 5f;
    public float followSpeed = 2f;
    public GameObject player;
    private Animator animator;
    private Camera cam;
    public GameObject cameraPivot;
    private bool _isWalking;
    private bool _runMode;
    public Rigidbody rb;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _runMode = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _runMode = false;
        }
    }

    void FixedUpdate()
    {
        // Player movement (WASD keys)
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0.0f;
        camForward.Normalize();
        Vector3 camRight = cam.transform.right.normalized;

        float keyboardDirX = Input.GetAxisRaw("Horizontal");
        float keyboardDirZ = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = camForward * keyboardDirZ + camRight * keyboardDirX;

        // Rotate the player
        if (movementDirection.magnitude >= 0.1f)
        {
            movementDirection.Normalize();
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // rotate
            _isWalking = true;
        } else {
            _isWalking = false;
        }

        // Move the player
        if (_runMode) {
            float runSpeed = moveSpeed * 2.5f;
            transform.position += movementDirection * runSpeed * Time.deltaTime; // move fast
        } else {
            transform.position += movementDirection * moveSpeed * Time.deltaTime; // move normal
        }

        // Animate the player
        if (_isWalking && _runMode) {
            // animate player running
            animator.SetFloat("ForwardSpeed", 1f);
        } else if (_isWalking)  {
            // animate player walking
            animator.SetFloat("ForwardSpeed", 0.5f);
        } else {
            // animate player idling
            animator.SetFloat("ForwardSpeed", 0.0f);
        }
    }

    void LateUpdate()
    {
        // Camera follow
        float t = Time.deltaTime * followSpeed;
        cameraPivot.transform.position = Vector3.Lerp(cameraPivot.transform.position, player.transform.position, t);
    }
}
