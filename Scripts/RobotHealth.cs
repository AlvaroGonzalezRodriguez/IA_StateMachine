using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
    float health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth()
    {
        health -= 10;
    }

    public void AddHealth()
    {
        health += 20;
    }

    public float GetHealth()
    {
        return health;
    }
}
