using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public Animator pp1Ani;
    public GameObject gameOverPanel;
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
            pp1Ani.SetBool("istalking",true);
            converScrp.Convo3();
        }
        else if(other.tag == "baseballbat")
        {
            converScrp.Convo4();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            pp1Ani.SetBool("istalking", false);
        }
       
    }
}
