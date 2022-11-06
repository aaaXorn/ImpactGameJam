using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header ("Movement")]
    public float movSpeed;

    [Header ("Ground Check")]
    public float pheight;
    public float groundDrag;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform orientation;

    float hInput;
    float vInput;

    Vector3 movDir;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput(){
        hInput=Input.GetAxisRaw("Horizontal");
        vInput=Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        movDir = (orientation.forward * vInput) + (orientation.right * hInput);

        rb.AddForce(movDir.normalized*movSpeed*10f, ForceMode.Force);
    }

    private void SpeedControl(){
        Vector3 vel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


        if(vel.magnitude > movSpeed){
            Vector3 limitVel= vel.normalized * movSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void FixedUpdate(){
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = true;//Physics.Raycast(transform.position, Vector3.down, pheight *0.5f + 0.2f, groundMask);
        MyInput();
        SpeedControl();

        if(isGrounded){
            rb.drag = groundDrag;
        }else{
            rb.drag = 0;
        }
    }
}
