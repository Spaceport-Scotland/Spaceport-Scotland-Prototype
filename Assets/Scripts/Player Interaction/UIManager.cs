using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    //variables
    public Text requestText;

    public void UpdateRequest(string request)
    {
        requestText.text = request;
    }

    public void ClearRequest()
    {
        requestText.text = "";
    }

}//end of class
