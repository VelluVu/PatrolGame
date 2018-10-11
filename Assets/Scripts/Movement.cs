using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    float moveSpeed;
    float rotationSpeed;
    float jumpForce;

    bool onGround;
    Rigidbody rb;

	void Start () {
        jumpForce = 300f * Time.deltaTime;
        moveSpeed = 5f * Time.deltaTime;
        rotationSpeed = 50f * Time.deltaTime;
        rb = gameObject.GetComponent<Rigidbody>();
	}

    private void Update()
    {
        PlayerMove();
        Jump();
    }

    private void PlayerMove()
    {
        //Tallennetaan muuttujiin x ja z axis liike
        float xMovement = Input.GetAxis("Horizontal") * moveSpeed;
        //transform.Rotate(0, rotationSpeed * Input.GetAxis("Horizontal"), 0);
        float zMovement = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(xMovement, 0, zMovement);

        //Tallennetaan muuttujaan hiiren X-liike
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookHere = new Vector3(0, mouseInput * rotationSpeed, 0);
        transform.Rotate(lookHere);
        /*if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }*/
        /*if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.E) && Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Q) && Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * moveSpeed);
        }*/


        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed);
        }
        
        else if (Input.GetButton("Mouse X"))
        {
            transform.Rotate(Vector3.up * rotationSpeed);
        }*/
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
        }
    }


}
