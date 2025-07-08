using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{

    public static BridgeManager instance;

    public GameObject bridgePrefab;
    public Vector3 bridgePosition;
    public float bridgeLength;
    public float repeatRate;


    public List<GameObject> obsticlePrefabList;
    public float obsticlePositionY;
    public float obsticlePositionXRange;

    private GameObject obstacle;

    public GameObject coinPrefab;
    public float coinPositionY;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating("SpawnBridge", 2, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBridge()
    {
        if(bridgePrefab != null)
        {
            bridgePosition.z += bridgeLength;
       GameObject bridge = Instantiate(bridgePrefab,bridgePosition,Quaternion.identity,transform);

        int random = Random.Range(0, 4);
        if (random > 1)
        {
            SpawnObsticle(bridge);
        } 

        

        CoinSpawn(bridge);
        }
        
    }

    public void SpawnObsticle(GameObject bridge)
    {
        Vector3 pos = bridge.transform.position;
        pos.y = obsticlePositionY;
        pos.x = Random.Range(-obsticlePositionXRange,obsticlePositionXRange);

        int obsticleIndex = Random.Range(0,obsticlePrefabList.Count);

        obstacle = Instantiate(obsticlePrefabList[obsticleIndex], pos, Quaternion.identity,bridge.transform);
         
    }

    void CoinSpawn(GameObject bridge)
    {

        Vector3 pos = bridge.transform.position;
        if(obstacle != null)
        {
            pos.x = obstacle.transform.position.x > 0 ? Random.Range(-2.0f, -1f) : Random.Range(1f, 4.0f);
        }
        else
        {
            pos.x = Random.Range(-2, 4);
        }
       
        pos.y = coinPositionY;

        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(90,0,0);

        Instantiate(coinPrefab, pos, rotation, bridge.transform);

    }


}
