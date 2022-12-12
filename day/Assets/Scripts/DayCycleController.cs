using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    public Button houseButton;
    public Button treeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HouseOnClick()
    {
        GameObject one = GameObject.Find("HouseButton");
        Debug.Log(one);

        for (int i = 0; i < one.GetComponents<Component>().Length; i++)
        {

        }

        TextMesh two = one.GetComponentInChildren<TextMesh>();
        Debug.Log(two);
        string three = two.text;
        Debug.Log(three);
        //GameObject.FindGameObjectWithTag("Button").GetComponentInChildren<Text>().text = "Still doesn't work.";
        //houseButton.GetComponentInChildren<Text>().text = "Doesn't work";
    }

    public void TreeOnClick()
    {

    }
}
