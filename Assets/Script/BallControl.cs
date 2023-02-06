using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour

{
    private Rigidbody rb;
    [SerializeField] private float speed = 10.0f;
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(20, -15, speed);
        }
        else
        {
            rb.AddForce(20, -15, -speed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("GoBall", 2);
    }
    void ResetBall()
    {
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }


    void OnCollisionEnter(Collision collision)
        {
             if (collision.collider.CompareTag("Player"))
              {
                    Vector2 vel;
                    vel.x = rb.velocity.x;
                    vel.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
                    rb.velocity = vel;
              }
    }
}
