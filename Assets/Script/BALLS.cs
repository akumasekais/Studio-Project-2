using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALLS : MonoBehaviour
{
    private Rigidbody rbody;

    [SerializeField] private Vector3 ballVelocity;
    [SerializeField] public float ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<Rigidbody>(out rbody))
        {
            Debug.LogError("No rigidbody");

        }
        else
        {
            rbody.velocity = ballVelocity * ballSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = ballVelocity * ballSpeed;
          
        
    }
    public void SetVelocity(float dirX, float dirZ, float spinVal)
    {
        //takes in a variable for x axis & apply to 
        float newX = ballVelocity.x * dirX;
        float newZ = ballVelocity.z * dirZ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if a collision is a paddle...
        if(collision.gameObject.TryGetComponent<Paddle>(out Paddle pdl))
        {
            //flip the x velcity of the ball by multiplying by -1
            SetVelocity(-1, 1, 0);
        }
        //check if object hits wall, if its not a paddle
        else if(collision.gameObject.tag == "topbottom")
        {
            SetVelocity(1, -1, 0);
        }
        else if (collision.gameObject.tag == "leftwall")
        {
            Debug.LogError("Right Paddle Scored");
            SetVelocity(-1, 1, 0);
        }
        else if (collision.gameObject.tag == "rightwall")
        {
            Debug.LogError("Left Paddle Scored");
            SetVelocity(-1, 1, 0);
        }
}
}
