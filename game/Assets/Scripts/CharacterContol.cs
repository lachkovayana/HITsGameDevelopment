using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterContol : MonoBehaviour
{

    //скорость персонажа
    private float speed = 4.0f;
    //скорость прыжка персонажа
    private float jumpSpeed = 8.0f;
    //переменная гравитации персонажа
    private float gravity = 20.0f;
    //переменная движения персонажа
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is calle d once per frame
    void FixedUpdate()
    {
        if (controller.isGrounded){
            moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }

        if(Input.GetKey(KeyCode.Space) && controller.isGrounded){
            moveDir.y = jumpSpeed;
        }
        moveDir.y -= gravity * Time.deltaTime;

        controller.Move (moveDir*Time.deltaTime);
    }
}
