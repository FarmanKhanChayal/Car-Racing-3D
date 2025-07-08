using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleRun();
        if(Car.instance.transform.position.z-5 > transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    void ObstacleRun()
    {
        
        transform.Translate(Vector3.forward*Time.deltaTime*RoadManager.Instance.obstacelSpeed);
    }

   
}
