using UnityEngine;

public class LeverController : MonoBehaviour
{
    public float activationRange = 10f;       // The range within which the lever can activate doors
    private DoorController nearestDoor;      // The nearest door to this lever
    private bool isActivated = false;        // Whether the lever is currently activated

    private void Update()
    {
        FindNearestDoor();  // Continuously find the nearest door

        if (isActivated && nearestDoor != null)
        {
            nearestDoor.ToggleDoor();  // Activate the nearest door
            isActivated = false;  // Reset activation state to prevent immediate toggle
        }
    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Player") && nearestDoor != null)
        {
            // Activate the door when the player enters the lever's trigger area
            isActivated = true;
            print("LEVER LEVER LEVER");
        }

    }

    private void OnTriggerExit(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the lever when the player exits the trigger
            isActivated = false;
        }
    }

    private void FindNearestDoor()
    {
        // Find all doors in the scene (this assumes you have doors tagged as "Door")
        DoorController[] allDoors = FindObjectsByType<DoorController>(FindObjectsSortMode.None);
        float closestDistance = Mathf.Infinity;
        DoorController closestDoor = null;

        foreach (var door in allDoors)
        {
            float distanceToDoor = Vector3.Distance(transform.position, door.transform.position);
            if (distanceToDoor < closestDistance && distanceToDoor <= activationRange)
            {
                closestDistance = distanceToDoor;
                closestDoor = door;
            }
        }

        nearestDoor = closestDoor;  // Set the nearest door
    }
}

/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * FindNearestDoor(): This method finds the nearest door within a specified range (activationRange). It checks all DoorController objects in the scene and selects the closest one.
OnTriggerEnter and OnTriggerExit: The lever detects when the player enters or exits its trigger zone and activates the nearest door when the player is close enough.
isActivated: This boolean prevents the lever from activating the door continuously if the player is holding the button or constantly near the lever.
 * 
*/

