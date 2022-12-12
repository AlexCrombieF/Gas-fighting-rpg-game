using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    // ATK, DEF, CHR, SPD
    int[,] partyStats = { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };

    //Sprites
    public Sprite houseMeetupBackgroundSprite1, houseMeetupBackgroundSprite2, houseMeetupBackgroundSprite3, parkMeetupBackgroundSprite;

    //Backgrounds
    Sprite meetupBackgroundSprite, statsChangeBackgroundSprite;
    Animator meetupBackgroundAnimator, statsChangeBackgroundAnimator;

    //Buttons
    GameObject houseButton, parkButton;

    //houseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Now works.";

    // Start is called before the first frame update
    void Start()
    {
        GameObject meetupBackground = GameObject.Find("MeetupBackground");
        GameObject statsChangeBackground = GameObject.Find("StatsChangeBackground");

        //Sprites
        meetupBackgroundSprite = meetupBackground.GetComponent<Image>().sprite;
        statsChangeBackgroundSprite = statsChangeBackground.GetComponent<Image>().sprite;

        //Animators
        meetupBackgroundAnimator = meetupBackground.GetComponent<Animator>();
        statsChangeBackgroundAnimator = statsChangeBackground.GetComponent<Animator>();

        //Buttons
        houseButton = GameObject.Find("HouseButton"); //Needed? Or just get specific component?
        parkButton = GameObject.Find("ParkButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // **********
    //  Buttons
    // **********

    //Locations
    public void HouseOnClick()
    {
        meetupBackgroundSprite = houseMeetupBackgroundSprite1;
        meetupBackgroundAnimator.SetTrigger("MoveIn");
    }
    public void ParkOnClick()
    {

    }

    //Dialogue
    public void DialogueChoice1OnClick()
    {
        meetupBackgroundSprite = houseMeetupBackgroundSprite2;
        statsChangeBackgroundAnimator.SetTrigger("MoveIn");
    }
    public void DialogueChoice2OnClick()
    {
        meetupBackgroundSprite = houseMeetupBackgroundSprite3;
        statsChangeBackgroundAnimator.SetTrigger("MoveIn");
    }

    //Stats Change
    public void StatsChangeConfirmationOnClick()
    {

    }
}
