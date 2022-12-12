using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public int health = 30;

    Slider hBar;
    Text hlt;

    bool created = false;

    void Start()
    {
    }

    void Update()
    {
        if (created){
            string hlts = health.ToString();
            hlt.text = hlts + "/30";

            hBar.value = health;
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