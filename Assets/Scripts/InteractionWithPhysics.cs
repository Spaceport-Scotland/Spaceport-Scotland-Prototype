using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionWithPhysics : MonoBehaviour
{
    //checks if you are dragging an object
    private bool dragging;

    //distance from the camera the object is when dragging
    private float distance;

    //target position for the object
    private Vector3 targetPosition;

    //speed the object moves towards the target
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //checks if the left mouse button was pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            //if the raycast hits object with script attached, start dragging
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    dragging = true;
                    distance = hit.distance;
                    rb.useGravity = false;
                }
            }
        }

        //if the left mouse button is pressed while dragging
        if (Mouse.current.leftButton.isPressed && dragging)
        {
            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            //sets the mouse position as the target
            targetPosition = ray.GetPoint(distance);

            //increases distance when scrolling up
            if (Mouse.current.scroll.ReadValue().y > 0)
            {
                distance += 0.2f;
            }

            //reduces distance when scrolling down
            if (Mouse.current.scroll.ReadValue().y < 0)
            {
                distance -= 0.2f;
            }
        }

        //sets dragging to false when left mouse is released
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
            rb.useGravity = true;
        }


    }

    void FixedUpdate()
    {
        //if dragging, move towards the target
        if (dragging)
        {
            Vector3 direction = targetPosition - rb.position;

            rb.linearVelocity = direction * moveSpeed;
        }
    }
}