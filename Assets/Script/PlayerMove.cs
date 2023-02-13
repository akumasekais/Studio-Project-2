using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    // [SerializeField] private float turnSpeed = 5;
    [SerializeField] private float jumpforce = 10f;
    Rigidbody rbody;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        grounded = true;
    }

    // Update is called once per frame

    void Update()
    {
        //check if player is pressing w
        if (Input.GetKey("w"))
        {
            //move in the direction the player is facing
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey("s"))
        {
            //move in the opposite direction the player is facing
            transform.position += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            //move in the direction the player is facing
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            //move in the opposite direction the player is facing
            transform.position += -transform.right * speed * Time.deltaTime;
            //check if player is pressing q (left) or e (right)
            /*
             if (Input.GetKey("q"))
             {
                 transform.Rotate(-transform.up * turnSpeed * Time.deltaTime);
             }
             else if (Input.GetKey("e"))
             {
                 transform.Rotate(transform.up * turnSpeed * Time.deltaTime);
             }
             */
            if (Input.GetKeyDown("space"))
            {
                if (grounded == true)
                    rbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                grounded = false;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
}
    


