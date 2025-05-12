using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _leftBound = -15f;

    private PlayerController _playerController;
    void Start()
    {
        _playerController =GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    void Update()
    {
        if (!_playerController.gameOver)
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));    
        }
        
        if (transform.position.x < _leftBound)
        {
            Destroy(gameObject);
        }
    }
}
