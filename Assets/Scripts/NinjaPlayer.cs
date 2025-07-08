using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float moveSpeeed;
    public float jumpSpeed;

    public float clampPositionX;
    public CinemachineVirtualCamera virtualCamera;



    void Start()
    {
        
    }

    void Update()
    {
       
        Run();
        ClampPosotion();
        InputTouch();

        if(SceneManager.GetActiveScene().name == "MenuNinjaRunner")
        {
           Animator animation = GetComponent<Animator>();
            animation.Play("Ninja Idle");
        }
    }

    void InputTouch()
    {
        if (Input.touchCount > 0)
        {
            Vector2 inputPosition = Input.GetTouch(0).position;
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 110));
            float direction = position.x > 0 ? 1 : -1;
            transform.Translate(Vector3.right*direction * moveSpeeed * Time.deltaTime);



        }
    }



   

    void Run()
    {
        transform.Translate(0,0,force*Time.deltaTime);
    }

    void ClampPosotion()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -clampPositionX, clampPositionX);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            //Destroy(gameObject);
            GameManager.instance.GameOver();
           Animator animator = GetComponent<Animator>();
            animator.Play("Falling Back Death");
            moveSpeeed = 0;
            force = 0;

            
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Reward")
        {
            GameManager.instance.IncreaseScore();
            Destroy(other.gameObject);
        }
    }



    


}
