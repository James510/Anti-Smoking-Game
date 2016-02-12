using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class d1s4a : MonoBehaviour
{
    public Text textfield;
    public GameObject background;
    public GameObject UIController;
    string currenttext = "";
    bool canGo = true;
    bool isrunning = false;
    bool isforcedcomplete = false;
    bool flag1 = false;
    int tree = 1;
    int dialoguecounter = 1;
    void printchar(char c)
    {
        textfield.text = textfield.text + c;
    }
    void dialoguecall(string passstring)
    {
        isrunning = true;
        StartCoroutine(stringcall(passstring));
    }
    IEnumerator stringcall(string dialogue)
    {
        textfield.text = "";
        char[] chardialogue;
        chardialogue = dialogue.ToCharArray();
        for (int x = 0; x < dialogue.Length; x++)
        {
            yield return new WaitForSeconds(.025f);
            printchar(chardialogue[x]);
            if (x == dialogue.Length - 1)
            {
                isrunning = false;
            }
            if (isforcedcomplete == true)
            {
                textfield.text = dialogue;
                isforcedcomplete = false;
                isrunning = false;
                break;

            }
        }
    }
    // Use this for initialization
    void Start()
    {
        //First dialogue display
        currenttext = "You: Alright, here are some informational pamphlets about the danger of smoking and smoking around others. It is really important that you understand how dangerous it is. I hope you guys will consider quitting."; //String type
        dialoguecall(currenttext);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tree);
        //Input Triggers
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
        {
            if (isrunning == false)
            {
                dialoguecounter++;
                switch (dialoguecounter)
                {
                    case 2://Second dialogue to display
                        currenttext = "Smokers: . . .";
                        dialoguecall(currenttext);
                        break;
                    case 3:
                        currenttext = "Smokers: Yeah, alright, this does sound pretty bad. Thanks";
                        dialoguecall(currenttext);
                        break;
                    case 4:
                        currenttext = "Nurse: Your first patient is ready for you Doctor.";
                        dialoguecall(currenttext);
                        break;
                    case 5:
                        currenttext = "You walk to the patient's room";
                        dialoguecall(currenttext);
                        break;
                    case 6:
                    default:
                        background.SendMessage("ChangeBackground", 1);
                        isrunning = true;
                        StartCoroutine("SceneChangeNext", 2.0f);
                        break;
                }
            }
            else
            {
                if(canGo)
                    isforcedcomplete = true;
            }
        }
    }
    IEnumerator SceneChangeWait(float f)
    {
        yield return new WaitForSeconds(f);
        currenttext = "...";
        dialoguecall(currenttext);
        isrunning = false;
    }
    IEnumerator SceneChangeNext(float f)
    {
        yield return new WaitForSeconds(f);
        UIController.SendMessage("NextScene", 8);
    }
    void ButtonOne()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        currenttext = "...";
        tree++;
        dialoguecall(currenttext);
    }
    void ButtonTwo()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        currenttext = "...";
        tree++;
        dialoguecall(currenttext);
    }
}
