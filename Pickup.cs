using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inv;
    public GameObject itemButton;
    private void Start()
    {
      inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i =0; i < inv.slots.Length; i++)
            {
                if(inv.isFull[i] == false)
                {
                    inv.isFull[i] = true;
                    Instantiate(itemButton, inv.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
