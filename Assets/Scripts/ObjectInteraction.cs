using UnityEngine;
// using the old Input system (Input.mousePosition / GetMouseButton)

public class ObjectInteraction : MonoBehaviour
{
    //checks if you are dragging an object
   private bool dragging;
    //distance from the camera the object is when dragging
   private float distance;

    void Update()
    {
        // check mouse down
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    dragging = true;
                    distance = hit.distance;
                }
            }
        }

        // while holding
        if (Input.GetMouseButton(0) && dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(distance);
        }

        // mouse up
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
}