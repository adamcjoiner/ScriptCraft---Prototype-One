using System;
using UnityEngine;
using System.Collections;
// using UnityEditor;
// using UnityEngine.EventSystems;

// public class InteractableObject : MonoBehaviour, ISelectHandler, IDeselectHandler
// {
//     public GameObject objectCursor;
    
//     public void OnSelect(BaseEventData eventData)
//     {
//         if (objectCursor != null) {
//             objectCursor.SetActive(true);
//         }
//     }

//     public void OnDeselect(BaseEventData eventData)
//     {
//         if (objectCursor != null) {
//             objectCursor.SetActive(false);
//         }
//     }
// }

public class InteractableObject : MonoBehaviour
{
    public GameObject objectCursor;
   [SerializeField] private bool selected;

    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       DetectObjectWithRaycast();
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // If Left Click + SHIFT
            if (Input.GetKey(KeyCode.LeftShift)) {
                // Do multiple select
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log($"{hit.collider.name} Left Click + SHIFT detected.",
                        hit.collider.gameObject);
                }

            // If Only Left Click
            } else {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log($"{hit.collider.name} Left Click detected.",
                        hit.collider.gameObject);
                    
                    if (selected == false) {
                        objectCursor.SetActive(true);
                        selected = true;
                    } else if (selected == true) {
                        objectCursor.SetActive(false);
                        selected = false;
                    }
                }
            }
        }
    }

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0)) {
    //         Debug.Log("Pressed primary button.");

    //         // If deselected...
    //         if (selected == false) {
    //             objectCursor.SetActive(true);
    //             selected = true;
    //         } else if (selected == true) {
    //             objectCursor.SetActive(false);
    //             selected = false;
    //         }    
    //     }             

    //     if (Input.GetMouseButtonDown(1)) {
    //         Debug.Log("Pressed secondary button.");
    //     }

    //     if (Input.GetMouseButtonDown(2)) {
    //         Debug.Log("Pressed middle click.");
    //     }
    // }

    // private void OnMouseDown() {
    //     Debug.Log("Pressed primary button.");

    //     // If deselected...
    //     if (selected == false) {
    //         objectCursor.SetActive(true);
    //         selected = true;
    //     } else if (selected == true) {
    //         objectCursor.SetActive(false);
    //         selected = false;
    //     } 
    // }
}