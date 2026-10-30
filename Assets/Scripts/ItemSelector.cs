using UnityEngine;

//this script detects what item is on/inside of the itemselector tray and is used to compare the item to what the customer wants
public class ItemSelector : MonoBehaviour
{
    public int selectedItemID = -1; // ID of the item currently in the tray, default to -1 (no item)

    public Item selectedItem;

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Find the Item script on the object that entered the tray
    //    Item item = other.GetComponentInParent<Item>();

    //    if (item != null && currentCustomer != null)
    //    {
    //        currentCustomer.ReactToItem(item); // link to character script

    //        Destory(other.gameObject);// should destory item
    //        currentCustomer = null;// states there is no longer a customer being served

    //       // selectedItem = item;
    //       // selectedItemID = item.ItemID;
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        // Find the Item script on the object that left the tray
        Item item = other.GetComponentInParent<Item>();

        if (item == selectedItem)
        {
            selectedItem = null;
            selectedItemID = -1;
        }
    }
}
