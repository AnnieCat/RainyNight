using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

    public enum Quadrant { q1_1, q1_2, q1_3, q2_1, q2_2, q2_3, q3_1, q3_2, q3_3 };
    public Quadrant activeQuadrant;

    private Animator myCat;
    private Animator myCups;
    private Animator myDog;
    private Animator myDogTail;
    private Animator myFoyerDoor;
    private Animator myGirl;
    private Animator myGirlHead;
    private Animator myLightning;
    private Animator myKettle;
    
    private GlobalVariables myGlobals;

    private Buttons myUse;
    private Buttons myWalk;

	void Start () {

        myCat = GameObject.Find("cat").GetComponent<Animator>();
        myCups = GameObject.Find("cups").GetComponent<Animator>();
        myDog = GameObject.Find("dog").GetComponent<Animator>();
        myDogTail = GameObject.Find("dogTail").GetComponent<Animator>();
        myFoyerDoor = GameObject.Find("foyerDoor").GetComponent<Animator>();
        myGirl = GameObject.Find("girlBody").GetComponent<Animator>();
        myGirlHead = GameObject.Find("girlHead").GetComponent<Animator>();
        myLightning = GameObject.Find("outside").GetComponent<Animator>();
        myKettle = GameObject.Find("teaKettle").GetComponent<Animator>();

        myGlobals = GameObject.Find("user").GetComponent<GlobalVariables>();

        myUse = GameObject.Find("use").GetComponent<Buttons>();
        myWalk = GameObject.Find("walk").GetComponent<Buttons>();
        
	}


    void Update()
    {
        if (activeQuadrant == Quadrant.q1_1)
        {
            myDog.SetBool("looking", false);
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            if (!myGlobals.waterBoiled)
                myKettle.SetBool("boil", false);
            myGirlHead.SetInteger("quad", 1);

            if (Input.GetKey(KeyCode.G) || myWalk.walkGo)
            {
                myGirl.SetTrigger("leaveLR");
            }

            myLightning.SetBool("looking", false);
        }

        if (activeQuadrant == Quadrant.q1_2)
        {
            myDog.SetBool("looking", false);
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            myGirlHead.SetInteger("quad", 2);

            if (Input.GetKey(KeyCode.G) || myWalk.walkGo)
            {
                myGirl.SetTrigger("leaveFoyer");
            }

            myLightning.SetBool("looking", false);
        }

        if (activeQuadrant == Quadrant.q1_3)
        {
            myDog.SetBool("looking", false);
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            if (!myGlobals.waterBoiled)
                myKettle.SetBool("boil", false);
            myGirlHead.SetInteger("quad", 3);

            myLightning.SetBool("looking", true);
        }

        if (activeQuadrant == Quadrant.q2_1) 
        {
            if (myGlobals.waterBoiled)
                if (Input.GetKey(KeyCode.Space) || myUse.useGo)
                {
                    myGirl.SetTrigger("getCups");
                }

            myDog.SetBool("looking", false);
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            myGirlHead.SetInteger("quad", 4);

            if (Input.GetKey(KeyCode.G) || myWalk.walkGo)
            {
                myGirl.SetTrigger("leaveLR");
            }

            myLightning.SetBool("looking", false);
        }
        

        if (activeQuadrant == Quadrant.q2_2)
        {
            myDog.SetBool("looking", false);
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            if (!myGlobals.waterBoiled && myGirlHead.renderer.enabled)
                myKettle.SetBool("boil", true);
            if (!myGirlHead.renderer.enabled)
                myKettle.SetBool("boil", false);

            myGirlHead.SetInteger("quad", 5);

            if (Input.GetKey(KeyCode.G) || myWalk.walkGo)
            {
                myGirl.SetTrigger("leaveFoyer");
            }

            myLightning.SetBool("looking", false);
        }

        if (activeQuadrant == Quadrant.q2_3)
        {
            if (myGlobals.openQuestion)
                if (Input.GetKey(KeyCode.Space) || myUse.useGo)
                {
                    myGirl.SetTrigger("getCat");
                    myCat.SetTrigger("getCat");
                    myDog.SetTrigger("getCat");
                }

            myDog.SetBool("looking", false);
            if (!myGlobals.waterBoiled)
                myKettle.SetBool("boil", false);

            if(!myGlobals.holdingTea)
                myCat.SetBool("watching", true);
            myGirlHead.SetInteger("quad", 6);

            myLightning.SetBool("looking", false);
        }

        if (activeQuadrant == Quadrant.q3_1)
        {
            myDog.SetBool("looking", false);
            if(!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            if (!myGlobals.waterBoiled)
                myKettle.SetBool("boil", false);
            myGirlHead.SetInteger("quad", 7);

            if (Input.GetKey(KeyCode.G) || myWalk.walkGo)
            {
                myGirl.SetTrigger("leaveLR");
            }

            myLightning.SetBool("looking", false);
        }

        if (activeQuadrant == Quadrant.q3_2)
        {
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            if (!myGlobals.waterBoiled)
                myKettle.SetBool("boil", false);
            myDog.SetBool("looking", true);
            myGirlHead.SetInteger("quad", 8);

            myLightning.SetBool("looking", false);
        }

        if (activeQuadrant == Quadrant.q3_3)
        {
            myDog.SetBool("looking", false);
            if (!myGlobals.holdingTea)
                myCat.SetBool("watching", false);
            if (!myGlobals.waterBoiled)
                myKettle.SetBool("boil", false);
            myGirlHead.SetInteger("quad", 9);

            myLightning.SetBool("looking", false);
        }
    }
}
