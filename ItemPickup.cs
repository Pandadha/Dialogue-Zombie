using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool pickupAllowed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupAllowed == true && Input.GetKeyDown(KeyCode.P))
        {
            PickItemUP();
        }
    }

    public void PickupItem()
    {
        if(pickupAllowed == true )// &&button press
        {
            PickItemUP();
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupAllowed = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
   
            pickupAllowed = false;
       

    }

    private void PickItemUP()
    {
        Destroy(transform.parent.gameObject);
    }

}
