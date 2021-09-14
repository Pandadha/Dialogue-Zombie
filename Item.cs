using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public HealthBar hbScp;
    public Player playerScp;
    public GameObject tentitem;
    public GameObject baseballbatobj;
    public Text tentText;
    private int countTentitem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("mushroom") && other.tag == "Player")
        {

            hbScp.SetHealth(playerScp.maxHealth);
            playerScp.curentHealth = playerScp.maxHealth;
            Destroy(gameObject);
        }
        else if(this.gameObject.CompareTag("tent") && other.tag == "Player")
        {
            if(countTentitem <3)
            {
                tentitem.SetActive(true);
                countTentitem++;
            }
            else if(countTentitem == 3)
            {
                tentText.text = "Ok fine, There is a baseball bat in there";
                tentitem.SetActive(true);
                baseballbatobj.SetActive(true);
                countTentitem++;
            }
           
        }
    }


}
