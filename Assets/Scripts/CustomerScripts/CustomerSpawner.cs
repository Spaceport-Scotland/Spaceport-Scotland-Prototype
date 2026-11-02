using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //variables
    public GameObject[] customerPrefabs;//list of prefabs

    public Transform spawnPoint;
    public Transform servePoint;
    public Transform despawnPoint;

    public UIManager uiManager;

    private Customer currentCustomer;

    private void Start()
    {
        SpawnCustomer();
    }

    public void SpawnCustomer()//randomises through prefab list
    {
        int randomIndex = Random.Range(0, customerPrefabs.Length);

        GameObject customerObject =Instantiate(customerPrefabs[randomIndex],spawnPoint.position,Quaternion.identity);//spawn position at waypoint game obejct

        currentCustomer = customerObject.GetComponent<Customer>();

        currentCustomer.spawner = this;
        currentCustomer.uiManager = uiManager;

        currentCustomer.currentState =Customer.CustomerState.Entering;

        currentCustomer.MoveTo(servePoint);//direct to points when spawned in

        Debug.Log("Customer Spawned");
    }

    public void CustomerDespawn()
    {
        if (currentCustomer == null)
            return;

        currentCustomer.currentState =
            Customer.CustomerState.Leaving;

        currentCustomer.MoveTo(despawnPoint);//direct to points when spawned in

        StartCoroutine(SpawnNextCustomer());//starts a timer for next customer after one despawns
    }

    IEnumerator SpawnNextCustomer()
    {
        yield return new WaitForSeconds(4f);//wait time

        if (currentCustomer != null)
        {
            Destroy(currentCustomer.gameObject);
            currentCustomer = null;
        }

        uiManager.ClearRequest();

        SpawnCustomer();
    }

    public Customer GetCurrentCustomer()//checks for current customer
    {
        return currentCustomer;
    }
}