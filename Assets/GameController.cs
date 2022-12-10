using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameObject c1;
    GameObject c2;
    GameObject c3;
    GameObject c4;

    GameObject enemy;

    bool pTurn = true;

    void Start(){
        c1 = GameObject.Find("C1 menu");
        enemy = GameObject.Find("Enemy");
    }


    void FixedUpdate(){
        if (pTurn){
            c1.GetComponent<character>().startTurn();
        }
        else{
             c1.GetComponent<character>().endTurn();
             enemy.GetComponent<enemyController>().attack(c1);
             pTurn = true;
        }
    }
    
    public void pAttack(){
        c1.GetComponent<character>().attack(enemy);
        pTurn = false;
    }
}
