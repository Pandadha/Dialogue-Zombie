using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject energy;
    public Transform playerTran;
    public int zombieCount;
    private int energyInt;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieCount >= 2)
        {
            if(energyInt<=0)
            {
                Instantiate(energy, playerTran.position + new Vector3(5, 0, 0), Quaternion.identity);
                energyInt++;
            }
           
        }
    }
    public void UpdateZombieCount()
    {
        zombieCount++;
    }
}
