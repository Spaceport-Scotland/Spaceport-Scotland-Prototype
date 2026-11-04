using System.Collections;
using UnityEngine;

//this script detects what item is on/inside of the itemselector tray and is used to compare the item to what the customer wants
public class ItemSelector : MonoBehaviour
{
    public int selectedItemID = -1; // ID of the item currently in the tray, default to -1 (no item)
    public Item selectedItem;
    public Customer currentCustomer;
    public CustomerSpawner customerSpawner;
    public float incorrectItemDelay = 1f;

    private bool isHandlingItem;

    private void OnTriggerEnter(Collider other)
    {
        // Prevent handling new items while already processing an item in the tray.
        if (isHandlingItem)
        {
            return;
        }

        Debug.Log("Something entered tray");

        // Find the Item script on the object that entered the tray
        Item item = other.GetComponentInParent<Item>();
        if (item == null)//checks that what has entered the tray is an item
        {
            Debug.LogError("Item is NULL");
            return;
        }

        if (customerSpawner == null)
        {
            Debug.Log("CustomerSpawner is NULL");
            return;
        }

        currentCustomer = customerSpawner.GetCurrentCustomer();
        if (currentCustomer == null)//checks
        {
            Debug.Log("Customer is NULL");
            return;
        }

        if (currentCustomer.itemRequested == null)
        {
            Debug.LogError("Requested Item is NULL");
            return;
        }

        selectedItem = item;
        selectedItemID = item.ItemID;

        if (selectedItemID == currentCustomer.itemRequested.ItemID)
        {
            CorrectItemSelected();
        }
        else
        {
            IncorrectItemSelected();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // Find the Item script on the object that left the tray
        Item item = other.GetComponentInParent<Item>();

        if (item == selectedItem && !isHandlingItem)
        {
            selectedItem = null;
            selectedItemID = -1;
        }
    }


    public void ResetTrayItem()
    {
        if (selectedItem == null)
        {
            Debug.LogError("There is no selected item to reset.");
            return;
        }

        InteractionWithPhysics itemInteraction = selectedItem.GetComponent<InteractionWithPhysics>();
        if (itemInteraction == null)
        {
            Debug.LogError("InteractionWithPhysics component is missing from the selected item.");
            return;
        }

        itemInteraction.ResetObject();
        selectedItem = null;
        selectedItemID = -1;
    }


    public void CorrectItemSelected()
    {
        if (currentCustomer == null)
        {
            Debug.LogError("Customer is NULL");
            return;
        }

        if (!isHandlingItem)
        {
            StartCoroutine(HandleCorrectItem());
        }
    }

    private IEnumerator HandleCorrectItem()
    {
        isHandlingItem = true;
        Customer customer = currentCustomer;

        customer.ReactToCorrectItem();
        yield return new WaitForSeconds(incorrectItemDelay);

        ResetTrayItem();
        if (customerSpawner != null)
        {
            customerSpawner.CustomerDespawn();
        }

        isHandlingItem = false;
    }


    public void IncorrectItemSelected()
    {
        if (currentCustomer == null)
        {
            Debug.LogError("Customer is NULL");
            return;
        }

        if (!isHandlingItem)
        {
            StartCoroutine(HandleIncorrectItem());
        }
    }

    private IEnumerator HandleIncorrectItem()
    {
        isHandlingItem = true;
        Customer customer = currentCustomer;

        customer.ReactToIncorrectItem();
        yield return new WaitForSeconds(incorrectItemDelay);

        ResetTrayItem();
        customer.RepeatRequest();
        isHandlingItem = false;
    }


}
