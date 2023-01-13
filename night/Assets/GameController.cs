using static System.Random;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // variables
    int enumb;
    int currentTurn = 1;
    int wait = 10;

    string action = "";

    bool created;
    bool pTurn = true;
    bool selected = false;
    bool battle = false;
    bool mf = false, mb = false, ml = false, mr = false;


    // game objects 
    public GameObject upper;
    GameObject c1;
    GameObject c2;
    GameObject c3;
    GameObject c4;

    GameObject iMenu;
    GameObject lowerhud;
    GameObject pmove;

    GameObject eselect;
    GameObject pselect;

    GameObject current;
    GameObject currentEnemy;
    GameObject currentPlayer;
    GameObject targ;


    // other
    public Texture invalid;
    Texture normal;

    public Text itemL1;
    public Text itemL2;

    Camera above;
    Camera norm;

    Vector3 mforward=new Vector3(0, 0, 0), mback=new Vector3(0, 0, 0), mleft=new Vector3(0, 0, 0), mright=new Vector3(0, 0, 0);


    // lists
    GameObject[] enemies = new GameObject[4];
    GameObject[] healthbs = new GameObject[4];

    IDictionary<string, int> items = new Dictionary<string, int>();
    IDictionary<Vector3, bool> cleared = new Dictionary<Vector3, bool>(21);


    void Start(){
        // other
        enumb = Random.Range(2, 4);
        normal = eselect.GetComponent<RawImage>().texture;

        // camera
        lowerhud = GameObject.Find("HUD lower");
        norm = GameObject.Find("Main Camera").GetComponent<Camera>();
        above = GameObject.Find("Camera").GetComponent<Camera>();
        above.enabled = false;

        // game objects
        c1 = GameObject.Find("C1 menu");
        c2 = GameObject.Find("C2 menu");
        c3 = GameObject.Find("C3 menu");
        c4 = GameObject.Find("C4 menu");
        iMenu = GameObject.Find("ItemMenu");
        eselect = GameObject.Find("Enemy select");
        pselect = GameObject.Find("Player select");
        current = c1;

        // items
        items.Add("Potions", 3);
        items.Add("Elixer", 2);

        // Filling cleared 
        cleared.Add(new Vector3(10, 4.5f, 0), false); cleared.Add(new Vector3(-10, 4.5f, 0), false); cleared.Add(new Vector3(-30, 4.5f, 0), false); cleared.Add(new Vector3(-50, 4.5f, 0), false);
        cleared.Add(new Vector3(-10, 4.5f, -20), false); cleared.Add(new Vector3(-30, 4.5f, -20), false); cleared.Add(new Vector3(-50, 4.5f, -20), false); cleared.Add(new Vector3(-70, 4.5f, -20), false);
        cleared.Add(new Vector3(-10, 4.5f, -40), false); cleared.Add(new Vector3(-30, 4.5f, -40), false); cleared.Add(new Vector3(-50, 4.5f, -40), false); cleared.Add(new Vector3(-70, 4.5f, -40), false); cleared.Add(new Vector3(-90, 4.5f, -40), false);
        cleared.Add(new Vector3(-30, 4.5f, -60), false); cleared.Add(new Vector3(-50, 4.5f, -60), false); cleared.Add(new Vector3(-70, 4.5f, -60), false); cleared.Add(new Vector3(-90, 4.5f, -60), false);
        cleared.Add(new Vector3(-50, 4.5f, -80), false); cleared.Add(new Vector3(-70, 4.5f, -80), false); cleared.Add(new Vector3(-90, 4.5f, -80), false);
        cleared.Add(new Vector3(-70, 4.5f, -100), false);        
    }

    void FixedUpdate(){

        // starts battle
        if (created == false){
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
                enemies[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(2, 3.5f, 0);
            }

            if (enumb == 2){
                healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-580, -950);
                healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[0].transform.localScale = new Vector2(0.8f, 2);
                enemies[0].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, -2.3f);

                healthbs[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-120, -950);
                healthbs[1].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[1].transform.localScale = new Vector2(0.8f, 2);
                enemies[1].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, 2.3f);
            }

            if (enumb == 3){
                healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-540, -950);
                healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[0].transform.localScale = new Vector2(0.5f, 2);
                enemies[0].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, -3.6f);

                healthbs[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-220, -950);
                healthbs[1].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[1].transform.localScale = new Vector2(0.5f, 2);
                enemies[1].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, 0);

                healthbs[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -950);
                healthbs[2].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[2].transform.localScale = new Vector2(0.5f, 2);
                enemies[2].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, 3.6f);
            }

            if (enumb == 4){
                healthbs[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-520, -950);
                healthbs[0].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[0].transform.localScale = new Vector2(0.4f, 2);
                enemies[0].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, -3.8f);

                healthbs[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -950);
                healthbs[1].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[1].transform.localScale = new Vector2(0.4f, 2);
                enemies[1].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, -1.2f);

                healthbs[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-80, -950);
                healthbs[2].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[2].transform.localScale = new Vector2(0.4f, 2);
                enemies[2].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, 1.2f);

                healthbs[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(140, -950);
                healthbs[3].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 25f);
                healthbs[3].transform.localScale = new Vector2(0.4f, 2);
                enemies[3].GetComponent<RectTransform>().position = new Vector3(2, 3.5f, 3.8f);            
            }
            created = true;
            battle = true;
        }

        wait++;
        back();


        // handles player actions 
        if (battle){
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


            // enemy turn
            else{
                targ = c1;
                for (int i = 0; i < enemies.Length; i++){
                        var target = Random.Range(1, 4);
                        if (target == 1){targ = c1;}
                        if (target == 2){targ = c2;}
                        if (target == 3){targ = c3;}
                        if (target == 4){targ = c4;}
                        if (targ.GetComponent<character>().health > 0 && enemies[i].GetComponent<enemyController>().health > 0){
                            enemies[i].GetComponent<enemyController>().attack(targ);
                            pTurn = true;
                        }
                }
            }
        }
        else{
            mforward = norm.GetComponent<RectTransform>().position + new Vector3(-20, 0, 0);
            mback = norm.GetComponent<RectTransform>().position + new Vector3(20, 0, 0);
            mleft = norm.GetComponent<RectTransform>().position + new Vector3(-20, 0, 0);
            mright = norm.GetComponent<RectTransform>().position + new Vector3(-20, 0, 0);
            for (int i = 0; i < cleared.Count; i++){
                if (cleared.keys.ElementAt(i).key == mforward){ mf = true;}
                if (cleared.keys.ElementAt(i).key == mback){ mb = true;}
                if (cleared.keys.ElementAt(i).key == mright){ mr = true;}
                if (cleared.keys.ElementAt(i).key == mleft){ ml = true;}
            }
        }
    }
    

    // player action functions 
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


    // selecting enemies 
    public void e1(){
        if (enemies[0].GetComponent<enemyController>().health > 0){
            currentEnemy = enemies[0];
            selected = true;
            control();
        }
        else{wait = 0;}
    }
    public void e2(){
        if (enumb > 1 && enemies[1].GetComponent<enemyController>().health > 0){
            currentEnemy = enemies[1];
            selected = true;
            control();
        }
        else{wait = 0;}
    }
    public void e3(){
        if (enumb > 2 && enemies[2].GetComponent<enemyController>().health > 0){
            currentEnemy = enemies[2];
            selected = true;
            control();
        }
        else{wait = 0;}
    }
    public void e4(){
        if (enumb == 4 && enemies[3].GetComponent<enemyController>().health > 0){
            currentEnemy = enemies[3];
            selected = true;
            control();
        }
        else{wait = 0;}
    }
    void selectEnemy(){
        if (enumb > 1){
            eselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 109);
            selected = false;
        }
        else{
            currentEnemy = enemies[0];
            selected = true;
            control();
        }
    }


    // selecting players 
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


    // general functions 
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
            pselect.GetComponent<RectTransform>().anchoredPosition = new Vector2(1.5f, 109);
            iMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1400, 50);
            currentTurn += 1;
        }
    }

    void back(){
        if (wait < 10){eselect.GetComponent<RawImage>().texture = invalid;}
        else{eselect.GetComponent<RawImage>().texture = normal;}
    }

    public void switchCamera(){
        if (norm.enabled == true){
            norm.enabled = false;
            above.enabled = true;
            lowerhud.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -900);
        }
        else if (above.enabled == true){
            norm.enabled = true;
            above.enabled = false;
            lowerhud.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -432);
        }
    }


    // player move
    void movemenu(){
        pmove.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        //if (mf){

        //}
    }
}