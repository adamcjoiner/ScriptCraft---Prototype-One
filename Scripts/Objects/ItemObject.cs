using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour//, IInteractable
{
    public ItemPreset item;
    public GameObject cursor;

    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    public void OnInteract()
    {
        Destroy(gameObject);
    }

    private void OnMouseEnter() {
        // Do hover interactions
            cursor.SetActive(true);

            // Display the appropriate message in the console based on the item type
            string message = "";
            switch (item.type) {
                case ItemType.Resource:
                    message = "Harvest " + item.displayName;
                    break;
                case ItemType.Material:
                    message = "Pickup " + item.displayName;
                    break;
                case ItemType.Machine:
                    message = "Interact with " + item.displayName;
                    break;
            }
            Debug.Log(message);
    }

    private void OnMouseExit() {
            cursor.SetActive(false);
    }

    void Update()
    {
    // Do click interactions
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && hitInfo.collider.gameObject == gameObject) {
                // Handle left mouse click on this GameObject
                Debug.Log(string.Format("Clicked an interactable object. Player's distance from object: {0}.", Vector3.Distance(transform.position, PlayerController.instance.transform.position)));

                // Check if the player is close enough to the item to interact with it
                if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= item.interactionRange) {
                    // Perform the appropriate action based on the item type
                    switch (item.type) {
                        case ItemType.Resource:
                            // Harvest the resource
                            Debug.Log("Harvested resource object.");
                            break;
                        case ItemType.Material:
                            // Pickup the item
                            break;
                        case ItemType.Machine:
                            // Open the machine's interface dialog
                            break;
                    }
                }
            }
        }
    }
}
