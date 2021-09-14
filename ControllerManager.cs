using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    //component
    private CharacterController _charContrller;
    private Animator _playerAnimator;
    private ManagerJoyStick _managerJoyStick;

    //
    private Transform meshPlayer;

    //move
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private float moveSpeed;

    public BoxCollider colliderWeapon;
    public GameObject objWeapon;

    void Start()
    {
        moveSpeed = 0.25f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        _charContrller = tempPlayer.GetComponent<CharacterController>();
        _playerAnimator = meshPlayer.GetComponent<Animator>();
        _managerJoyStick = GameObject.Find("ImageJoyBg").GetComponent<ManagerJoyStick>();

        colliderWeapon.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        //inputX = Input.GetAxis("Horizontal");
        //inputZ = Input.GetAxis("Vertical");
        inputX = _managerJoyStick.inputHorizontal();
        inputZ = _managerJoyStick.inputVertical();
        if(inputX == 0 && inputZ == 0)
        {
            _playerAnimator.SetBool("isWalk", false);
        }
        else
        {
            _playerAnimator.SetBool("isWalk", true);
        }

        
    }
    private void FixedUpdate()
    {
        //movement
        v_movement = new Vector3(inputX * moveSpeed, 0, inputZ * moveSpeed);
        _charContrller.Move(v_movement);

        // mesh rotate
        if(inputX != 0 || inputZ != 0)
        {
            Vector3 lookDir = new Vector3(v_movement.x, 0, v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
        
    }
    public void Acttack()
    {
        _playerAnimator.SetTrigger("hitTir");

    }



    //public void AttackStart()
    //{

    //    colliderWeapon.enabled = true;
    //}
    //public void AttackEnd()
    //{

    //    colliderWeapon.enabled = false;
    //}

}
