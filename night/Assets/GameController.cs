using static System.Random;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enumb = 1;
    int aliveEnemies;

    public GameObject upper;

    public Texture invalid;
    Texture normal;

    public Text itemL1;
    public Text itemL2;

    GameObject[] enemies = new GameObject[4];
    GameObject[] healthbs = new GameObject[4];

    IDictionary<string, int> items = new Dictionary<string, int>();

    GameObject c1;
    GameObject c2;
    GameObject c3;
    GameObject c4;

    GameObject iMenu;

    GameObject eselect;
    GameObject pselect;

    GameObject current;
    GameObject currentEnemy;
    GameObject currentPlayer;
    GameObject targ;

    bool pTurn = true;
    bool selected = false;
    int currentTurn = 1;

    string action = "";

    int wait = 10;

    void Start(){
        aliveEnemies = enumb;
        c1 = GameObject.Find("C1 menu");
        c2 = GameObject.Find("C2 menu");
        c3 = GameObject.Find("C3 menu");
        c4 = GameObject.Find("C4 menu");
        iMenu = GameObject.Find("ItemMenu");
        eselect = GameObject.Find("Enemy select");
        pselect = GameObject.Find("Player select");
        current = c1;

        items.Add("Potions", 3);
        items.Add("Elixer", 2);

        normal = eselect.GetComponent<RawImage>().texture;
        
        enemies = new GameObject[4];
        for (int i = 0; i < enumb; i++){
            enemies[i] = Instantiate(Resources.Load("Enemy")) as GameObject;
            healthbs[i] = Instantiate(Resources.Load("healthbar")) as GameObject;
            enemies[i].GetComponent<enemyController>().setHealthBar(healthbs[i]);
            healthbs[i].transform.SetParent(upper.transform);
        }
        currentEnemy = enemies[0];
        if (enumb == 1){
            healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-440, -950);
            healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100f);
            healthbs[0].transform.localScale = new Vector2(1, 2);
            enemies[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1);
        }

        if (enumb == 2){
            healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-580, -950);
            healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[0].transform.localScale = new Vector2(0.8f, 2);
            enemies[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-2f, 1);

            healthbs[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-120, -950);
            healthbs[1].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[1].transform.localScale = new Vector2(0.8f, 2);
            enemies[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 1);
        }

        if (enumb == 3){
            healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-540, -950);
            healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[0].transform.localScale = new Vector2(0.5f, 2);
            enemies[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-3, 1);

            healthbs[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-220, -950);
            healthbs[1].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[1].transform.localScale = new Vector2(0.5f, 2);
            enemies[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1);

            healthbs[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -950);
            healthbs[2].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[2].transform.localScale = new Vector2(0.5f, 2);
            enemies[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(3, 1);
        }

        if (enumb == 4){
            healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-520, -950);
            healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[0].transform.localScale = new Vector2(0.4f, 2);
            enemies[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-4, 1);

            healthbs[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -950);
            healthbs[1].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[1].transform.localScale = new Vector2(0.4f, 2);
            enemies[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1.5f, 1);

            healthbs[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-80, -950);
            healthbs[2].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[2].transform.localScale = new Vector2(0.4f, 2);
            enemies[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(1.5f, 1);

            healthbs[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(140, -950);
            healthbs[3].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
            healthbs[3].transform.localScale = new Vector2(0.4f, 2);
            enemies[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(4, 1);            
        }
    }

    void FixedUpdate(){
        wait++;
        back();
        aliveEnemies = 0;
        foreach (GameObject i in enemies){
            if(i != null){
                aliveEnemies++;
            }
        }

        if (selected){
            eselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -850);
        }
        if (pTurn){
            if (currentTurn == 1){
                if (c1.GetComponent<character>().health <= 0){ currentTurn++; }
                else{ c1.GetComponent<character>().startTurn(); current = c1; }
            }
            if (currentTurn == 2){
                if (c2.GetComponent<character>().health <= 0){ currentTurn++; }
                else{ c2.GetComponent<character>().startTurn(); current = c2; }
                c1.GetComponent<character>().endTurn();
            }
            if (currentTurn == 3){
                if (c3.GetComponent<character>().health <= 0){ currentTurn++; }
                else{ c3.GetComponent<character>().startTurn(); current = c3; }
                c2.GetComponent<character>().endTurn();
            }
            if (currentTurn == 4){
                if (c4.GetComponent<character>().health <= 0){ currentTurn++; }
                else{ c4.GetComponent<character>().startTurn(); current = c4; }
                c3.GetComponent<character>().endTurn();
            }
            if (currentTurn == 5){
                c4.GetComponent<character>().endTurn();
                currentTurn = 1;
                pTurn = false;
            }
        }
        else{
            targ = c1;
            for (int i = 0; i < aliveEnemies; i++){
                    var target = Random.Range(1, 4);
                    if (target == 1){targ = c1;}
                    if (target == 2){targ = c2;}
                    if (target == 3){targ = c3;}
                    if (target == 4){targ = c4;}
                    if (targ.GetComponent<character>().health > 0){
                        currentEnemy.GetComponent<enemyController>().attack(targ);
                        pTurn = true;
                    }
                    else{ aliveEnemies++; }
            }
        }
    }
    
    public void pAttack(){
        iMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-600, 1000);
        selectEnemy();
        action  ="attack";
    }

    public void pSpecial(){
        iMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-600, 1000);
        if (current.GetComponent<character>().special > 4){ selectEnemy(); }
        else{ current.GetComponent<character>().specialAttack(currentEnemy);  }
        action = "special";
    }

    public void pItems(){
        foreach(KeyValuePair<string, int> i in items){
            itemL1.text = "Potions: " + items["Potions"].ToString();
            itemL2.text = "Elixer: " + items["Elixer"].ToString();
            Debug.Log((i.Key, i.Value));
        }
        iMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-600, 50);
    }

    public void potion(){
        if (items["Potions"] > 0){
            action = "potion";
            pselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(3, -250);
            items["Potions"] -= 1;
        }
    }
    public void elixer(){
        if (items["Elixer"] > 0){
            action = "elixer";
            pselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(3, -250);
            items["Elixer"] -= 1;
        }
    }

    public void e1(){
        currentEnemy = enemies[0];
        selected = true;
        control();
    }
    public void e2(){
        if (enumb > 1){
            currentEnemy = enemies[1];
            selected = true;
            control();
        }
        else{wait = 0;}
    }
    public void e3(){
        if (enumb > 2){
            currentEnemy = enemies[2];
            selected = true;
            control();
        }
        else{wait = 0;}
    }
    public void e4(){
        if (enumb == 4){
            currentEnemy = enemies[3];
            selected = true;
            control();
        }
        else{wait = 0;}
    }

    public void p1(){
        if (action == "potion"){c1.GetComponent<character>().health += 20;}   
        if (action == "elixer"){c1.GetComponent<character>().special += 10;}   
        control();}
    public void p2(){
        if (action == "potion"){c2.GetComponent<character>().health += 20;}   
        if (action == "elixer"){c2.GetComponent<character>().special += 10;}   
        control();}
    public void p3(){
        if (action == "potion"){c3.GetComponent<character>().health += 20;}   
        if (action == "elixer"){c3.GetComponent<character>().special += 10;}   
        control();}
    public void p4(){
        if (action == "potion"){c4.GetComponent<character>().health += 20;}   
        if (action == "elixer"){c4.GetComponent<character>().special += 10;}   
        control();}

    void selectEnemy(){
        if (aliveEnemies > 1){
            eselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -250);
            selected = false;
        }
        else{
            currentEnemy = enemies[0];
            selected = true;
            control();
        }
    }

    void control(){
        if (action == "attack"){
            current.GetComponent<character>().attack(currentEnemy);
            currentTurn += 1;
        }
        if (action == "special"){
             if (current.GetComponent<character>().special > 4){
                currentTurn += 1;
            }
            current.GetComponent<character>().specialAttack(currentEnemy);
        }
        if (action == "potion" || action == "elixer"){
            pselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(3, -500);
            iMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1400, 50);
            currentTurn += 1;
        }
    }

    void back(){
        if (wait < 10){eselect.GetComponent<RawImage>().texture = invalid;}
        else{eselect.GetComponent<RawImage>().texture = normal;}
    }
}