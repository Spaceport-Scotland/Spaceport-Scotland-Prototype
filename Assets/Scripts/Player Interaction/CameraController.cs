using UnityEngine;
public class CameraController : MonoBehaviour
{

    private int cameraPosition;

    // rotationSpeed is degrees per second for the camera to rotate
    public float rotationSpeed = 180f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CameraRotateLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            CameraRotateRight();
        }

        //sets the targetRotation on the y axis to cameraPostion * 90 degrees 
        Quaternion targetRotation = Quaternion.Euler(0, cameraPosition * 90, 0);

        // gradually rotate toward the target at a fixed degrees/sec speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    //function for rotate left/right if we include buttons
    void CameraRotateLeft()
    {
        cameraPosition--;
    }

    void CameraRotateRight()
    {
        cameraPosition++;
    }
}
