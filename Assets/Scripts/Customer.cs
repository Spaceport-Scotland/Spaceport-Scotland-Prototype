using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour //KA
{
    //Variables



    [Header("CustomerRequests")]
    public string[] possibleRequests; //List of all items that customer could ask for
    public string itemRequested;
    public string[] possibleAtributes;//List of all atributes that could be asked for
    public string itemAtributes;


    //edit it in unity
    [Header("CustomerEnglishDialogue")]
    public Text requestText;
    public string greetingReaction = " ";
    public string correctReaction = " ";
    public string wrongReaction = " ";

    [Header("CustomerAlienDialogue")]
    public Text requestAlienText;
    public string greetingAlienReaction = " ";
    public string correctAlienReaction = " ";
    public string wrongAlienReaction = " ";



    void Start()
    {
        itemRequested = possibleRequests[Random.Range(0, possibleRequests.Length)]; //randomises customer request from list of items
        requestText.text = greetingReaction + itemRequested;
        requestAlienText.text = greetingReaction + itemRequested;

    }//end of start

    public void ReactToItem(string itemID)
    {
        if (itemID == itemRequested)
        {
            Debug.Log(correctReaction);
            //need to add to this 
        }
        else
        {
            Debug.Log(wrongReaction);
            //need to add to this
        }
    }//End of react




}//End of class
