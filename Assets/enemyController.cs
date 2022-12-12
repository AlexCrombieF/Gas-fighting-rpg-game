using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public int health = 30;
    string name = "Enemy";

    public Slider hBar;
    //public Text title;
    public Text hlt;

    void Start()
    {
    }

    void Update()
    {
        string hlts = health.ToString();
        hlt.text = hlts + "/30";

        //title.text = name;
        hBar.value = health;
    }
    
    public void attack(GameObject enemy){
        enemy.GetComponent<character>().health -= 5;
    }
}