using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{
    //checks if you are dragging an object
    bool dragging;
    //distance from the camera the object is when dragging
    float distance;

    void Update()
    {
        //checks if the left mouse button was pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // If the raycast hits object with script attached, start dragging and save the distance
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    dragging = true;
                    distance = hit.distance;
                }
            }
        }
        

        //if the left mouse button is pressed while dragging 
        if (Mouse.current.leftButton.isPressed && dragging)
        {
            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            //moves the object to that postition and keeps the distance
            transform.position = ray.GetPoint(distance);
        }

        //sets dragging to false when left mouse is released drops the object
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
        }
    }
}