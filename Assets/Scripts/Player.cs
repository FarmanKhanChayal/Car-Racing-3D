using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float force = 500f;
    public float speed = 7.0f;
    void Start()
    {
       
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        }

    }

    void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, force*Time.deltaTime);
    }
}
