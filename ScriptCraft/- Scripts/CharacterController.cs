using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    // private bool _isWalking;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * moveSpeed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * moveSpeed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * moveSpeed, ForceMode.Impulse);
        
        // if (Input.GetKeyDown(KeyCode.A || KeyCode.S || KeyCode.W || KeyCode.D))
        //     _isWalking = true;
    }

    // void FixedUpdate() {
    //     if (_isWalking) {

    //     }
    // }
}
