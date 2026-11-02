using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    public enum CustomerState //states
    {
        Entering,
        Waiting,
        Served,
        Leaving
    }
    //variables
    [Header("State")]
    public CustomerState currentState;

    [Header("Movement")]
    public float moveSpeed = 2f;

    private Transform targetPoint;

    [Header("Requests")]
    public Item[] possibleRequests;

    public Item itemRequested;

    [Header("Dialogue")]
    public string greetingReaction = "I would like a ";
    public string correctReaction = "Thank you!";
    public string wrongReaction = "That isn't what I requested.";

    [HideInInspector]
    public CustomerSpawner spawner;

    public ItemSelector itemSelector;


    [HideInInspector]
    public UIManager uiManager;

    private void Start()
    {
        itemSelector = GameObject.FindGameObjectWithTag("ItemSelector").GetComponent<ItemSelector>();
        GenerateRequest();

    }

    private void Update()
    {
        MoveCustomer();
    }

    public void GenerateRequest()//how it randomises requests for a list + displays it
    {
        if (possibleRequests.Length == 0)
        {
            Debug.LogError("No possible requests assigned!");
            return;
        }

        itemRequested = possibleRequests[Random.Range(0, possibleRequests.Length)];

        if (uiManager != null)
        {
            uiManager.UpdateRequest(greetingReaction + itemRequested.ItemName);
        }

        Debug.Log("Requested: " + itemRequested.ItemName);
    }

    public void MoveTo(Transform destination)
    {
        targetPoint = destination;
    }

    private void MoveCustomer()//moving customers to points
    {
        if (targetPoint == null)
            return;

        transform.position = Vector3.MoveTowards( transform.position,targetPoint.position,moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position,targetPoint.position) < 0.1f)
        {
            ReachedDestinations();//refs
        }
    }

    private void ReachedDestinations()//changes state once customer is at different points
    {
        if (currentState == CustomerState.Entering)
        {
            currentState = CustomerState.Waiting;
            targetPoint = null;

            Debug.Log("Customer waiting.");
        }

        else if (currentState == CustomerState.Leaving)
        {
            //makes sure once reached point and in leaving state it destroys object
            Destroy(gameObject);
        }
    }

    public void ReactToItem(int itemID)
    {
        if (itemRequested == null)
        {
            Debug.LogError("Requested Item is NULL");
            return;
        }

        if (itemID == itemRequested.ItemID)
        {
            uiManager.UpdateRequest(correctReaction);//changes text if correct
            Debug.Log(correctReaction);
            //sets correct item to true used for reseting item in the tray.
            itemSelector.correctItem = true;
            currentState = CustomerState.Served;
           
            
            

            if (spawner != null)
            {
                spawner.CustomerDespawn();
            }
        }
        else
        {
            uiManager.UpdateRequest(wrongReaction);//changes text if wrong
            Debug.Log(wrongReaction);
        }
    }


}