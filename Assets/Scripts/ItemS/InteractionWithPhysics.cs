using UnityEngine;
// using the old Input system (Input.mousePosition / GetMouseButton)

public class InteractionWithPhysics : MonoBehaviour
{
    //checks if you are dragging an object
    public bool dragging;

    //distance from the camera the object is when dragging
    private float distance;

    //target position for the object
    private Vector3 targetPosition;

    //speed the object moves towards the target
    public float moveSpeed = 5f;

    private Vector3 startingPosition;

    private Rigidbody rb;

    void Start()
    {
        startingPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //checks if the left mouse button was pressed
        if (Input.GetMouseButtonDown(0))
        {
            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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
        if (Input.GetMouseButton(0) && dragging)
        {
            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //sets the mouse position as the target
            targetPosition = ray.GetPoint(distance);

            //increases distance when scrolling up
            if (Input.mouseScrollDelta.y > 0)
            {
                distance += 0.2f;
            }

            //reduces distance when scrolling down
            if (Input.mouseScrollDelta.y < 0)
            {
                distance -= 0.2f;
            }
        }

        //sets dragging to false when left mouse is released
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            rb.useGravity = true;
        }


        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            ResetObject();
        }
    }


    void ResetObject()
    {
        // teleport back to start and clear any momentum
        transform.position = startingPosition;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
        }
        dragging = false;
        rb.useGravity = true;
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