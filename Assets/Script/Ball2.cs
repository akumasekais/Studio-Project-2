using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    public float speed = 200.0f;
    private Rigidbody _rigidbody;
    private void Awake ()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        AddStartingForce();
    }
    private void AddStartingForce()
    {
        //coinflip logic. set random value between 0 and 1 and say if 
        //its greater than half consider one direction
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        // range provides set min and max value, up is negative. 
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range (0.5f, 1.0f);
        //set vectorr direction
        Vector2 direction = new Vector2 (x, y);
        _rigidbody.AddForce(direction * this.speed);
    }
}
