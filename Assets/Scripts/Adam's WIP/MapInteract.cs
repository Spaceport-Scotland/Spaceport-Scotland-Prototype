using UnityEngine;

public class MapInteract : MonoBehaviour
{
    [SerializeField] private TourPopup popup;

    private void OnMouseDown() => popup.Open();
    
}
