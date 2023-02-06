using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] bool isLeftPaddle;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.LogError("There is no rigidbody attached to this paddle");
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftPaddle)
        {
            //check if the player is pressing W
            if (Input.GetAxisRaw("VerticalLeft") > 0)
            {
                //move paddle north if thy are pressing W
                rb.AddForce(0, 0, speed);
            }
            //check if the player is holding S
            else if (Input.GetAxisRaw("VerticalLeft") < 0)
            {
                //move paddle south if they are holding S
                rb.AddForce(0, 0, -speed);
            }
            else
            {
                rb.velocity = Vector3.zero;

            }
        }

        else
        {

            if (Input.GetAxisRaw("VerticalRight") > 0)
            {

                rb.AddForce(0, 0, speed);
            }

            else if (Input.GetAxisRaw("VerticalRight") < 0)
            {
                rb.AddForce(0, 0, -speed);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
    


            
           
