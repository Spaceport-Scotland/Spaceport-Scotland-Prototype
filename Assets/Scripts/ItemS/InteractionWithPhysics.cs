using UnityEngine;
// using the old Input system (Input.mousePosition / GetMouseButton)

public class InteractionWithPhysics : MonoBehaviour
{
    //checks if you are dragging an object
    public bool dragging;

    //distance from the camera the object is when dragging
    private float distance;

    //distance from the camera to the inspection marker
    public float inspectionDistance;

    //target position for the object
    private Vector3 targetPosition;

    //speed the object moves towards the target
    public float moveSpeed = 3f;
    public float rotationSpeed = 100f;

    private Vector3 startingPosition;

    private Rigidbody rb;

    void Start()
    {
        //store the starting position of the object
        startingPosition = transform.position;

        rb = GetComponent<Rigidbody>();

        //find the inspection marker in the scene
        GameObject inspectionMarker = GameObject.FindGameObjectWithTag("InspectionDistance");

        //calculate the distance from the camera to the inspection marker
        if (inspectionMarker != null)
        {
            inspectionDistance = Vector3.Distance(Camera.main.transform.position, inspectionMarker.transform.position);
        }
        else
        {
            Debug.LogError("InspectionDistance marker was not found.");
        }
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
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
            }

            //shoots a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //increases distance when scrolling up
            if (Input.mouseScrollDelta.y > 0)
            {
                distance += 1f;
            }

            //reduces distance when scrolling down
            if (Input.mouseScrollDelta.y < 0)
            {
                distance -= 1f;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                distance = inspectionDistance;
            }

            // Prevent the distance from going below the inspection distance or into the camera
            if (distance < inspectionDistance)
            {
                distance = inspectionDistance;
            }

            //sets the mouse position as the target
            targetPosition = ray.GetPoint(distance);
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


   public void ResetObject()
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