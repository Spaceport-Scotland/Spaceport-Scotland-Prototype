using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //Variables

    public GameObject[] customerPrefabs; // chooses a random customerprefabn to spawn
    public Transform spawnPoint;
    public Transform servePoint;
    public Transform despawnPoint;
    //public DropZone dropzone;



    private Customer currentCustomer; // To know if there is a current customer as to not have more than 1


    public void SpawnCustomer()
    {
        int index = Random.Range(0, customerPrefabs.Length);

        GameObject obj = Instantiate(customerPrefabs[index], spawnPoint.position, Quaternion.identity);

        currentCustomer = obj.GetComponent<Customer>();

        //need a move to animation from spawn point to serve point

    }//end of spawn


    public void DespawnCustomer()
    {
        Debug.Log("Customer Despawns");

        currentCustomer = null;
        //need to add to this

    }//end of despawn 


}//end of class
