using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemweapon : MonoBehaviour
{

    public GameObject batObj;
    public GameObject hitButton;
    public Animator textpop;
    public Text text1;
    private Tester converScrp;
    // Start is called before the first frame update
    void Start()
    {
        converScrp = GameObject.Find("Conversation Manager").GetComponent<Tester>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            textpop.SetTrigger("textpopTri");
            converScrp.Convo2();
            hitButton.SetActive(true);
            batObj.SetActive(true);
            Destroy(gameObject);
        }


    }
}
