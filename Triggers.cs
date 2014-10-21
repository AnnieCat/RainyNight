using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour {

    [System.Serializable]
    public class AudioFiles
    {
        public string clipName;
        public AudioClip[] clipVariations;
    }
    public AudioFiles[] myAudioFiles;

    private GlobalVariables myGlobals;
    private Animator myAnim;


	void Start () {

        myGlobals = GameObject.Find("user").GetComponent<GlobalVariables>();
        myAnim = gameObject.GetComponent<Animator>();

        if(gameObject.name=="outside")
            StartCoroutine(RandomLightning());
	}

    //Generic

    void PlayAudio1()
    {
        int randClip = Random.Range(0, myAudioFiles[0].clipVariations.Length);
        audio.PlayOneShot(myAudioFiles[0].clipVariations[randClip]);
    }

    void PlayAudio2()
    {
        int randClip = Random.Range(0, myAudioFiles[0].clipVariations.Length);
        audio.PlayOneShot(myAudioFiles[1].clipVariations[randClip]);
    }

    void PlayAudio3()
    {
        int randClip = Random.Range(0, myAudioFiles[0].clipVariations.Length);
        audio.PlayOneShot(myAudioFiles[2].clipVariations[randClip]);
    }

    void AudioReset()
    {
        audio.Stop();
        AudioListener.volume = 1f;
    }

    void HideObject() {
        GameObject girlGlow = GameObject.Find("girlGlow");
        GameObject dogGlow = GameObject.Find("dogGlow");

        girlGlow.renderer.sortingLayerName = "foyerDoor";
        dogGlow.renderer.sortingLayerName = "foyerDoor";
        dogGlow.renderer.sortingOrder = 0;
        gameObject.renderer.sortingLayerName = "foyerDoor";
        gameObject.renderer.sortingOrder = 0;
    }

    //Tea Kettle

    void WaterBoiled() {
        myGlobals.waterBoiled = true;
        myAnim.SetTrigger("done");
    }

    //Girl

    void GetCups() {
        Animator myKettle = GameObject.Find("teaKettle").GetComponent<Animator>();
        Animator myCups = GameObject.Find("cups").GetComponent<Animator>();

        myKettle.SetTrigger("pourTea");
        myCups.SetTrigger("pourTea");
    }

    void HasCups() {
        Animator myGirl = GameObject.Find("girlBody").GetComponent<Animator>();

        myGlobals.holdingTea = true;
        myGirl.SetBool("holdingTea", true);
    }

    void HeadOff() {
        GameObject myHead = GameObject.Find("girlHead");
        Animator myKettle = GameObject.Find("teaKettle").GetComponent<Animator>();

        myHead.renderer.enabled = false;
        myKettle.SetBool("boil", false);
    }

    void DogFollowFoyer() {
        Animator myDog = GameObject.Find("dog").GetComponent<Animator>();
        Animator myDoor = GameObject.Find("foyerDoor").GetComponent<Animator>();

        myDog.SetTrigger("leaveFoyer");
        myDoor.SetTrigger("leaveFoyer");

        print("we're leaving!");
    }

    void DogFollowLR() {
        Animator myDog = GameObject.Find("dog").GetComponent<Animator>();

        myDog.SetTrigger("leaveLR");
    }

    void HeadOn()
    {
        GameObject myHead = GameObject.Find("girlHead");
        myHead.renderer.enabled = true;
    }

    void FootstepsOn(){
        GameObject myFootsteps = GameObject.Find("footsteps");
        myFootsteps.audio.volume = 0.3f;
    }

    void FootstepsOff() {
        GameObject myFootsteps = GameObject.Find("footsteps");
        myFootsteps.audio.volume = 0f;
    }

    //Cat

    void QuestionOpen() {
        myGlobals.openQuestion = true;
    }

    void QuestionClosed() {
        myGlobals.openQuestion = false;
    }

    void CatWet() {
        myGlobals.catWet = true;
    }

    //Dog

    void TailOff() {
        GameObject myTail = GameObject.Find("dogTail");

        myTail.renderer.enabled = false;
    }

    //Lightning

    void OutsideReset() {
        myAnim.ResetTrigger("smallLightning");
        myAnim.ResetTrigger("largeLightning");
        myAnim.ResetTrigger("release");
        myAnim.ResetTrigger("randomLightning");
    }
    
    IEnumerator LightningFlash() {
        int myRoll = Random.Range(0, 2);
        float waitTime = Random.Range(5f, 7f);
        yield return new WaitForSeconds(waitTime);
        myAnim.SetInteger("dieRoll", myRoll);
        myAnim.SetTrigger("smallLightning");
    }

    IEnumerator LightningLookAway() {
        int myRoll = Random.Range(0, 2);
        int yaoBuYao = Random.Range(0, 2);
        float waitTime = Random.Range(2f, 5f);
        yield return new WaitForSeconds(waitTime);
        if (yaoBuYao == 0)
            myAnim.SetBool("release", false);
        if (yaoBuYao > 0)
            myAnim.SetBool("release", true);
        myAnim.SetInteger("dieRoll", myRoll);
        myAnim.SetTrigger("largeLightning");
    }

    IEnumerator smallThunderAudio() {
        float waitTime = Random.Range(0.25f, 0.5f);
        yield return new WaitForSeconds(waitTime);
        int randClip = Random.Range(0, myAudioFiles[0].clipVariations.Length);
        audio.PlayOneShot(myAudioFiles[0].clipVariations[randClip]);
    }

    IEnumerator largeThunderAudio() {
        Animator myCamera = GameObject.Find("Main Camera").GetComponent<Animator>();

        float waitTime = Random.Range(0.05f, 0.15f);
        yield return new WaitForSeconds(waitTime);
        int randClip = Random.Range(0, myAudioFiles[1].clipVariations.Length);
        audio.PlayOneShot(myAudioFiles[1].clipVariations[randClip]);
        myCamera.SetTrigger("action");
    }

    IEnumerator RandomLightning() {
        int myRoll = Random.Range(0, 2);
        float waitTime = Random.Range(10f, 25f);
        yield return new WaitForSeconds(waitTime);
        myAnim.SetInteger("dieRoll", myRoll);
        myAnim.SetTrigger("randomLightning");
        StartCoroutine(RandomLightning());
    }

    void BrightRoomSmall() {
        GameObject bright = GameObject.Find("bkgd_kitchenSmallFlash");
        bright.renderer.enabled = true;
    }

    void BrightRoomLarge() {
        GameObject bright = GameObject.Find("bkgd_kitchenFlash");
        bright.renderer.enabled = true;
    }

    void DarkRoomSmall() {
        GameObject bright = GameObject.Find("bkgd_kitchenSmallFlash");
        bright.renderer.enabled = false;
    }

    void DarkRoomLarge() {
        GameObject bright = GameObject.Find("bkgd_kitchenFlash");
        bright.renderer.enabled = false;
    }
}
