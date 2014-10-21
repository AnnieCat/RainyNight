using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

    public bool waterBoiled = false;
    public bool holdingTea = false;
    public bool catWet = false;
    public bool openQuestion = false;

    void Start()
    {
        Screen.showCursor = false;
    }
}
