using UnityEngine;

//this script detects what item is on/inside of the itemselector tray and is used to compare the item to what the customer wants
public class ItemSelector : MonoBehaviour
{
    public int selectedItemID = -1; // ID of the item currently in the tray, default to -1 (no item)

    public Item selectedItem;

    public Customer currentCustomer;
    public CustomerSpawner customerSpawner;

    private void OnTriggerEnter(Collider other)
    {
        // Find the Item script on the object that entered the tray
        Item item = other.GetComponentInParent<Item>();


        Debug.Log("Something entered tray");


        if (item == null)//chceks
        {
            Debug.LogError("Item is NULL");
            return;
        }

        if (customerSpawner == null)//checks
        {
            Debug.Log("CustomerSpawner is NULL");
            return;
        }

        Customer currentCustomer = customerSpawner.GetCurrentCustomer();

        if (currentCustomer == null)//checks
        {
            Debug.Log("Customer is NULL");
            return;
        }

        //selectedItem = item;
        //selectedItemID = item.ItemID;

        currentCustomer.ReactToItem(item.ItemID);//link to customer script

    }

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
