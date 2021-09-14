using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    public GameObject zombieBlood;
    private Animator zombieAni;
    private float dist;
    public CapsuleCollider zombiColli;
    NavMeshAgent navAgent;
    private IEnumerator coFOVRoutine;
    private Player playerScp;
    private GameManager gM;
  
    //public GameObject target;

    // Field of view
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canseePlayer;

    // Start is called before the first frame update
    void Start()
    {
        zombieAni = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        playerScp = GameObject.Find("Player_h").transform.GetChild(0).GetComponent<Player>();
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
     
        coFOVRoutine = FOVRoutine();
        StartCoroutine(coFOVRoutine);
    }

    // Update is called once per frame
    void Update()
    {
     
        //if(target != null)
        //{
        //  this.transform.LookAt(target.transform);
        //  navAgent.SetDestination(target.transform.position);

        // //float playerDistance = Vector3.Distance(this.transform.position, target.transform.position);

           
        //}
       
    
    }

    IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if(rangeChecks.Length !=0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distaceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distaceToTarget, obstructionMask)) //might need to adjust transform.position to be higher this is the start of raycast should be eyes sight
                {
                    canseePlayer = true;
                    if(playerRef != null)
                    {
                        this.transform.LookAt(playerRef.transform);
                    }
                 
                }
                else
                {
                    canseePlayer = false;
                    this.transform.LookAt(null);
                } 
            }
            else
            {
                canseePlayer = false;
               this.transform.LookAt(null);
            }  
        }
        else if(canseePlayer)
        {
            canseePlayer = false;
           this.transform.LookAt(null);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "baseballbat")
        {

            StopCoroutine(coFOVRoutine);
            zombiColli.enabled = false;
   
           GameObject _zombieBlood = Instantiate(zombieBlood, transform.position + new Vector3(0,3,0), Quaternion.identity);
            Destroy(_zombieBlood, 2f);
            this.zombieAni.SetTrigger("deathTri");
            Destroy(this.gameObject, 1.5f);
            gM.UpdateZombieCount();
     
           
        }

        if (other.tag == "Player")
        {
            //target = other.gameObject;

            Debug.Log("detect player");
            dist = Vector3.Distance(playerRef.transform.position, transform.position);

            if (dist <= 3.5f)
            {
                playerScp.TakeDaMage(10);
            }

        }


    }



}
