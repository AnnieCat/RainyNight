using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

    public bool walkGo = false;
    public bool useGo = false;

	void Start () {

	}

	void Update () {

	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();
            if (gameObject.name == "x")
                ExitButtonEngage();
            if (gameObject.name == "walk")
                StartCoroutine(SetTrigger("walk"));
            if (gameObject.name == "use")
                StartCoroutine(SetTrigger("use"));
        }
    }

    void ExitButtonEngage()
    {
        Application.Quit();
    }

    IEnumerator SetTrigger (string myButton)
    {
        if(myButton=="walk")
        {
            walkGo = true;
            yield return new WaitForEndOfFrame();
            walkGo = false;
        }
        if(myButton=="use")
        {
            useGo = true;
            yield return new WaitForEndOfFrame();
            useGo = false;
        }
    }
}
