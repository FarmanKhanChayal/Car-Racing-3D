using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car instance;


    public float runSpeed;
    public float moveSpeed;
    public float clampPositionX;
    public Camera mainCamera;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        CarRun();
        OnInputTouch();
        OnClamp();
    }

    void CarRun()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*runSpeed);
    }

    void OnInputTouch()
    {
        if(Input.touchCount > 0)
        {
            Vector2 position2d = Input.GetTouch(0).position;
            Vector3 position3d = mainCamera.ScreenToWorldPoint(new Vector3(position2d.x, position2d.y, 100));


            int direction = position3d.x > 0 ? 1 : -1;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * direction);

        }
    }

    void OnClamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -clampPositionX, clampPositionX);
        transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.tag == "Obstacle")
        {
       
            Time.timeScale = 0;
           
            CarRaceGameManager.instance.GameOver();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Reward")
        {
            CarRaceGameManager.instance.IncreaseScore();
        }
    }


}
