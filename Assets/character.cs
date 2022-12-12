using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    RectTransform rect;
    Vector2 pos;

    public int health = 50;
    int special = 20;

    public Slider hBar;
    public Slider sBar;
    public Text hlt;
    public Text sp;

    public GameObject outline;
    public Texture selected;
    Texture nSelected;

    void Start(){
        rect = GetComponent<RectTransform>();
        pos = new Vector2(0, -250);
        nSelected = outline.GetComponent<RawImage>().texture;
    }

    void Update(){
        rect.anchoredPosition = pos;

        hBar.value = health;
        sBar.value = special;
        string healths = health.ToString();
        hlt.text = healths + "/50";
        string specials = special.ToString();
        sp.text = specials + "/20";
    }


    public void attack(GameObject enemy){
        var damage = Random.Range(2, 8);
        enemy.GetComponent<enemyController>().health -= damage;

        if (special < 19){
            special += 2;
        }
        else{
            special = 20;
        }
    }
    public void specialAttack(GameObject enemy){
        var damage = Random.Range(4, 16);
        enemy.GetComponent<enemyController>().health -= damage;
        special -= 5;
    }


    public void startTurn(){
        pos = new Vector2(pos.x, -250);
        outline.GetComponent<RawImage>().texture = selected;
    }
    public void endTurn(){
        pos = new Vector2(pos.x, -575);
        outline.GetComponent<RawImage>().texture = nSelected;
    }
}