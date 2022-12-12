using static System.Random;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enumb = 1;

    public GameObject upper;

    GameObject[] enemies;
    GameObject[] healthbs;

    GameObject c1;
    GameObject c2;
    GameObject c3;
    GameObject c4;

    GameObject enemy1;
    GameObject enemy2;
    GameObject enemy3;
    GameObject enemy4;

    GameObject current;
    GameObject currentEnemy;
    GameObject targ;

    bool pTurn = true;
    int currentTurn = 1;

    void Start(){
        for (int i = 0; i <= enumb; i++){
            enemies[i] = Instantiate(Resources.Load("Enemy")) as GameObject;
            healthbs[i] = Instantiate(Resources.Load("enemy healthbar")) as GameObject;
            healthbs[i].transform.SetParent(upper.transform);
        }
        if (enumb == 1){
            enemies[0].GetComponent<enemyController>().setHealthBar(healthbs[0]);
        }
        currentEnemy = enemies[0];

        c1 = GameObject.Find("C1 menu");
        c2 = GameObject.Find("C2 menu");
        c3 = GameObject.Find("C3 menu");
        c4 = GameObject.Find("C4 menu");
        current = c1;
    }


    void FixedUpdate(){
        if (pTurn){
            if (currentTurn == 1){
                c1.GetComponent<character>().startTurn();
                current = c1;
            }
            if (currentTurn == 2){
                c1.GetComponent<character>().endTurn();
                c2.GetComponent<character>().startTurn();
                current = c2;
            }
            if (currentTurn == 3){
                c2.GetComponent<character>().endTurn();
                c3.GetComponent<character>().startTurn();
                current = c3;
            }
            if (currentTurn == 4){
                c3.GetComponent<character>().endTurn();
                c4.GetComponent<character>().startTurn();
                current = c4;
            }
            if (currentTurn == 5){
                c4.GetComponent<character>().endTurn();
                currentTurn = 1;
                pTurn = false;
            }
        }
        else{
            var target = Random.Range(1, 4);
            if (target == 1){targ = c1;}
            if (target == 2){targ = c2;}
            if (target == 3){targ = c3;}
            if (target == 4){targ = c4;}
            enemy1.GetComponent<enemyController>().attack(targ);
            pTurn = true;
        }
    }
    
    public void pAttack(){
        current.GetComponent<character>().attack(enemy1);
        currentTurn += 1;
    }

    public void pSpecial(){
        current.GetComponent<character>().specialAttack(enemy1);
        currentTurn += 1;
    }
}
