using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public int health;
    int mHealth;
    public int atk;
    public int defence;
    public int speed;

    Slider hBar;
    Text hlt;

    bool created = false;

    void Start()
    {
        mHealth = health;
    }

    void Update()
    {
        if (created){
            string hlts = health.ToString();
            string mhlts = mHealth.ToString();
            hlt.text = hlts + "/" + mhlts;

            hBar.value = health;
            hBar.maxValue = mHealth;
        }
    }
    
    public void attack(GameObject enemy){
        enemy.GetComponent<character>().health -= 5;
    }

    public void setHealthBar(GameObject healthbar){
        hBar = healthbar.GetComponentInChildren(typeof(Slider)) as Slider;
        hlt = healthbar.GetComponentInChildren(typeof(Text)) as Text;
        created = true;
    }
}