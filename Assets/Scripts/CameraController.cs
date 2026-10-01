using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    int cameraPosition;
  
    float rotationSpeed = 5f;

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            CameraRotateLeft();
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
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