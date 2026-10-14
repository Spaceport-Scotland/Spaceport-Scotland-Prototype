using UnityEngine;
public class CameraController : MonoBehaviour
{

    private int cameraPosition;
  
    public float rotationSpeed = 5f;

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

        //gradually rotates the camera towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime);
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