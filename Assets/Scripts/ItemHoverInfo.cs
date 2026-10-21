using UnityEngine;
using TMPro;

// Handles displaying item information when hovering over an item.

public class ItemHoverInfo : MonoBehaviour
{
    public GameObject itemInfoPanel;
    public TextMeshProUGUI itemInfoText;
    public Vector2 offset = new Vector2(10f, -10f);

    void Start()
    {

        if (itemInfoPanel != null) itemInfoPanel.SetActive(false);
    }

    void Update()
    {
        if (Camera.main == null)
        {
            return;
        }

        // don't show item info while the left mouse button is held (likely dragging)
        if (Input.GetMouseButton(0))
        {
            if (itemInfoPanel != null)
            {
                itemInfoPanel.SetActive(false);
            }

            return;
        }

        // Cast a ray from the mouse into the scene
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            // try to get an Item component from the object we hit
            Item item = hit.collider.GetComponentInParent<Item>();

            // if there is an Item, show the item info
            if (item != null)
            {
                if (itemInfoText != null)
                {
                    // set the item info text to the item's info
                    itemInfoText.text = item.GetTooltip();
                }

                if (itemInfoPanel != null)
                {
                    // show the panel and move it to the mouse position
                    itemInfoPanel.SetActive(true);
                    itemInfoPanel.transform.position = mousePos + (Vector3)offset;
                }

                // found an item and handled the item info, stop here
                return;
            }
        }

        if (itemInfoPanel != null) itemInfoPanel.SetActive(false);
    }
}
