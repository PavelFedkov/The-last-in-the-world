using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    
    private int _health = 1;
    void Start()
    {
        _health = 1;
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Player health: " +  _health);

        if (_health == 0) 
        {
            transform.Rotate(0, 0, 90);
            
        }
    }

 
}
