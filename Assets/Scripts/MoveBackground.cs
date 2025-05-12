using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _startPosition;
    private float _repeatWidth;

    private PlayerController _playerController;
    
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        _startPosition = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    
    void Update()
    {
        transform.position = (transform.position.x < _startPosition.x - _repeatWidth) ? _startPosition : transform.position;
        
        if (!_playerController.gameOver)
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));    
        }
    }
}
