using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{ 
    //references 

    public float speed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Launch() //launch method
    {
        //set x and y equal to negative 1 or 1
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        //set the velocity to that times the speed
        rb.velocity = new Vector2 (speed * x, speed * y);
    }
}