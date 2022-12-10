using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    RectTransform rect;
    Vector2 pos;

    public int health = 50;
    public Slider hBar;

    void Start(){
        rect = GetComponent<RectTransform>();
        pos = rect.position;
    }

    void Update(){
        rect.anchoredPosition = pos;
        hBar.value = health;
    }

    public void attack(GameObject enemy){
        enemy.GetComponent<enemyController>().health -= 10;
    }

    public void startTurn(){
        pos = new Vector2(-350, -95);
    }
    public void endTurn(){
        pos = new Vector2(-350, -295);
    }

}
