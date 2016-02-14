using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class d1s6 : MonoBehaviour
{
    public Text textfield;
    public GameObject background;
    public GameObject UIController;
    public int nextScene;
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
        currenttext = "What should you eat for lunch?"; //String type
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
                    case 2:
                        string[] choices = new string[2];
                        choices[0] = "Hot Dog";
                        choices[1] = "Pizza";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 3://Path 1
                        currenttext = "You: One hot dog please.";
                        dialoguecall(currenttext);
                        break;
                    case 4:
                        currenttext = "The vendor hands you a hot dog.";
                        dialoguecall(currenttext);
                        dialoguecounter = 6;
                        break;
                    case 5://path2
                        currenttext = "You: One pizza please.";
                        dialoguecall(currenttext);
                        break;
                    case 6:
                        currenttext = "The vendor hands you a pizza.";
                        dialoguecall(currenttext);
                        break;
                    case 7:
                        currenttext = "You: Thanks. Have a nice day.";
                        dialoguecall(currenttext);
                        break;
                    case 8:
                        currenttext = "After eating, you get the urge to smoke";
                        dialoguecall(currenttext);
                        break;
                    case 9:
                        background.SendMessage("ChangeBackground", 1);
                        isrunning = true;
                        StartCoroutine("SceneChangeWait", 2.0f);
                        break;
                    case 10:
                        currenttext = "Making your way to an alley, you pull out a pack of cigarettes.";
                        dialoguecall(currenttext);
                        break;
                    case 11:
                        currenttext = "You feel guilty about it, but you also feel less stressed out.";
                        dialoguecall(currenttext);
                        break;
                    case 12:
                        currenttext = "You: I hope no one from work sees me.";
                        dialoguecall(currenttext);
                        break;
                    case 13:
                        currenttext = "You walk briskly back to work.";
                        dialoguecall(currenttext);
                        break;
                    default:
                        background.SendMessage("ChangeBackground", 2);
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
        UIController.SendMessage("NextScene", nextScene);
    }
    void ButtonOne()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        currenttext = "...";
        dialoguecounter = 2;
        tree++;
        dialoguecall(currenttext);
    }
    void ButtonTwo()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        currenttext = "...";
        dialoguecounter = 4;
        tree++;
        dialoguecall(currenttext);
    }
}
