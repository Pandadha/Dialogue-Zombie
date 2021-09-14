using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider colliderWeapon;
    public GameObject objWeapon;

    // Start is called before the first frame update
    void Start()
    {
        colliderWeapon = objWeapon.GetComponent<BoxCollider>();

        colliderWeapon.enabled = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "zombie")
    //    {
    //        zombieAni.SetTrigger("deathTri");
    //        Destroy(other.gameObject, 1.5f);
    //    }
    //}

    public void AttackStart()
    {

        colliderWeapon.enabled = true;
    }
    public void AttackEnd()
    {

        colliderWeapon.enabled = false;
    }
}
