using UnityEngine;

public class NPCRequest : MonoBehaviour
{
    [SerializeField] private string[] tours = { "PlaceHolder1", "Placeholder2", "Placeholder3" };

    private TourPopup popup;

    public string WantedTour {  get; private set; }  //for anyone not well versed, this just makes it so that it can be read by other scripts but can only be edited here, expect changes

    private void Start() => StartRequest();  //Temp here for call
    
       
   

    private void Awake()
    {
        popup = FindObjectOfType<TourPopup>();
    }

    public void StartRequest()
    {
        WantedTour = tours[Random.Range(0, tours.Length)];
        Debug.Log("NPC wants: " + WantedTour);
        popup.SetNPC(this);
    }

    public bool CheckAnswer(string chosen)
    {
        Debug.Log("Chosen: [" + chosen + "] Wanted: [" + WantedTour + "]");
        bool correct = chosen == WantedTour;
        Debug.Log(correct ? "Correct!" : "Wrong Answer");
        return correct;
    }












    /* public void Start() => PickNewTour();          //temp that checks for tour when launched
    
    public void PickNewTour()
    {
        WantedTour = tours[Random.Range(0, tours.Length)];
        Debug.Log("Npc Wants: " + WantedTour);
    } */
}