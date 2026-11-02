using UnityEngine;

public class TourPopup : MonoBehaviour
{
    
    [SerializeField] private GameObject popupPanel;
    
    private NPCRequest Currentnpc;

    public void SetNPC(NPCRequest npc) => Currentnpc = npc;

    public void Open()  //this makes it so you cant open the tours when no npc at counter
    {
        if (Currentnpc != null)
            popupPanel.SetActive(true);
    }

    public void Choose(string tour)
    {
        Currentnpc.CheckAnswer(tour);  //sends answer to npc
        popupPanel.SetActive(false);

    }
}
