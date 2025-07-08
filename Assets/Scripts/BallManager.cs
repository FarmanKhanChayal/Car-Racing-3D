using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    public static BallManager instance;

   public GameObject Ball;
    public float positionXRange;
    public float positionY;
    public float positionZRange;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void BallSpawn()
    {
        float x = Random.Range(-positionXRange,positionXRange);
        float z = Random.Range(-positionZRange,positionZRange);

        Instantiate(Ball,new Vector3(x,positionY,z),Quaternion.identity);
    }
}
