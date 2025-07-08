using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RoadManager : MonoBehaviour
{
    public static RoadManager Instance;

    public GameObject carObstacleManager;

   public GameObject roadprefab;
    public float roadLength;
    public float roadPosition;
    public float roadRepeatRate;
    public float accessoryPositionX;
    public float accessoryPositionY;
    public List <GameObject> accessoryPrebList;
    public GameObject airoplanePrefab;


    public List < GameObject> obstaclePrefabs;
    public float obstacelPositionY;
    public float obstacelPositionXRange;
    public float obstacelSpeed;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        InvokeRepeating("RoadSpawn", 0.4f, roadRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RoadSpawn()
    {
        roadPosition += roadLength;
        
       GameObject road = Instantiate(roadprefab,new Vector3(0,0,roadPosition),Quaternion.identity,transform);
        SpawnAccessory(road);

        int obRange = Random.Range(0, 4);
        if(obRange > 1)
        {
            ObstacleSpawn(road);
        }
        
    }

    void SpawnAccessory(GameObject road)
    {
        Vector3 position = road.transform.position;
        position.x = accessoryPositionX;
        position.y = accessoryPositionY;

        int accessoryIndex = Random.Range(0, accessoryPrebList.Count);
        Instantiate(accessoryPrebList[accessoryIndex], position, Quaternion.identity,road.transform);


        position.x = -accessoryPositionX;

        int accessoryIndex1 = Random.Range(0, accessoryPrebList.Count);
        Instantiate(accessoryPrebList[accessoryIndex1], position, Quaternion.identity,road.transform);

       
        

    }

    void ObstacleSpawn(GameObject road)
    {
        Vector3 position = road.transform.position;
        position.y = obstacelPositionY;
        position.x = Random.Range(-obstacelPositionXRange, obstacelPositionXRange);

        int obstacleIndex = Random.Range(0, obstaclePrefabs.Count);

        Quaternion Quat = Quaternion.identity;
        Quat.eulerAngles = new Vector3(0, 180, 0);
        if(position.x > 1.2)
        {
            GameObject carObstacle = Instantiate(obstaclePrefabs[obstacleIndex], position, Quat, carObstacleManager.transform);
        }
        else if(position.x < -1.2
            ) 
        {
            GameObject carObstacle = Instantiate(obstaclePrefabs[obstacleIndex], position, Quaternion.identity, carObstacleManager.transform);
        }
      

      


    }

    public void StartGame()
    {
        SceneManager.LoadScene("CarRace");
    }

   
}
