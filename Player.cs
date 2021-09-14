using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 120;
    public int curentHealth;
    public GameObject damageEff;
    public GameObject gameoverPanel;
    public HealthBar healthBarScp;
    public float timecouter;
    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;
        healthBarScp.SetMaxHealth(maxHealth);
        InvokeRepeating("UseingEnergy", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(curentHealth <= 0)
        {
            gameoverPanel.SetActive(true);
        }


    }

    public void TakeDaMage(int damage)
    {
        curentHealth -= damage;
        //GameObject damageEff_ =  Instantiate(damageEff, transform.position, Quaternion.Euler(-90, 0, 0));
        //Destroy(damageEff_,3f);
        healthBarScp.SetHealth(curentHealth);
    }
    public void UseingEnergy()
    {
        TakeDaMage(1);
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "zombie")
    //    {
    //        TakeDaMage(1);
    //    }
    //}
}
