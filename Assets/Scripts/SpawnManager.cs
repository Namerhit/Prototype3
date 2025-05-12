using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);

    private float _statDelay = 0f;
    private float _repeatTime = 2.5f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", _statDelay, _repeatTime);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
    
    void Update()
    {
        
    }
}
