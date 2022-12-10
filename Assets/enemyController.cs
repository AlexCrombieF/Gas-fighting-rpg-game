using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public int health = 30;

    GameObject c1;

    public Slider hBar;

    void Start()
    {
        
    }

    void Update()
    {
        hBar.value = health;
    }
    
    public void attack(GameObject enemy){
        enemy.GetComponent<character>().health -= 5;
    }
}
