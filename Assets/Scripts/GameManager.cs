using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private int _timeScale = 1;
    
    void Start()
    {
    }
    
    void Update()
    {
        _timeScale = (playerController.gameOver) ? 0 : 1;
        
        // Time.timeScale = _timeScale;
        
    }
}
