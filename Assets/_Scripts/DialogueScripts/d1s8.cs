using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class d1s8 : MonoBehaviour
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
        currenttext = "You make it to the rooftop and stand still for a moment"; //String type
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
                        currenttext = "You pull out your pack of cigarettes.";
                        dialoguecall(currenttext);
                        break;
                    case 3:
                        currenttext = "What will you do?";
                        dialoguecall(currenttext);
                        break;
                    case 4:
                        string[] choices = new string[2];
                        choices[0] = "Light up.";
                        choices[1] = "Quit.";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 5://Path 1
                        currenttext = "You light a cigarette and inhale deeply.";
                        dialoguecall(currenttext);
                        break;
                    case 6:
                        currenttext = "You: Sigh";
                        dialoguecall(currenttext);
                        break;
                    case 7:
                        currenttext = "The door opens behind you.";
                        dialoguecall(currenttext);
                        break;
                    case 8:
                        currenttext = "Clarice: What are you doing up here, Doc?";
                        dialoguecall(currenttext);
                        break;
                    case 9:
                        currenttext = "You: . . .";
                        dialoguecall(currenttext);
                        break;
                    case 10:
                        currenttext = "You: I’m, uh, I’m smoking Clarice.";
                        dialoguecall(currenttext);
                        break;
                    case 11:
                        currenttext = "Clarice: I see. Well, it is your choice, your life. I figured though, you out of everyone would understand.";
                        dialoguecall(currenttext);
                        break;
                    case 12:
                        currenttext = "Clarice: Seeing what you see.";
                        dialoguecall(currenttext);
                        break;
                    case 13:
                        currenttext = "Clarice: I just hope you get to run your marathon, and ski your mountain.";
                        dialoguecall(currenttext);
                        break;
                    case 14:
                        currenttext = "You: . . . ";
                        dialoguecall(currenttext);
                        break;
                    case 15:
                        currenttext = "Clarice: Well, see you tomorrow, Doc.";
                        dialoguecall(currenttext);
                        break;
                    case 16:
                        currenttext = "She sighs and closes the door behind her.";
                        dialoguecall(currenttext);
                        break;
                    case 17://path 2
                        currenttext = "You: I have just made up my mind, Clarice. I am going to quit.";
                        dialoguecall(currenttext);
                        break;
                    case 18:
                        currenttext = "Clarice: Glad to hear it, Doc. You gunna get to run your marathon?";
                        dialoguecall(currenttext);
                        break;
                    case 19:
                        currenttext = "You: Yeah, I am going to get to run my marathon.";
                        dialoguecall(currenttext);
                        break;
                    case 20:
                        currenttext = "Clarice: Well, that’s good. I will leave you to the training then. It isn’t easy, but you can push through, I know you can.";
                        dialoguecall(currenttext);
                        break;
                    case 21:
                        currenttext = "You: Thanks Clarice. I will see you tomorrow, okay?";
                        dialoguecall(currenttext);
                        break;
                    case 22:
                        currenttext = "Clarice: Yep. See you then Doc.";
                        dialoguecall(currenttext);
                        break;
                    case 23:
                        currenttext = "She smiles and closes the door behind her.";
                        dialoguecall(currenttext);
                        break;
                    case 24:
                        currenttext = "You gather your things and head home";
                        dialoguecall(currenttext);
                        break;
                    case 25:
                        background.SendMessage("ChangeBackground", 1);
                        isrunning = true;
                        StartCoroutine("SceneChangeNext", 2.0f);
                        break;
                    case 26:
                        currenttext = "You pass a bar with two smokers outside.";
                        dialoguecall(currenttext);
                        break;
                    case 27:
                        currenttext = "It's the same two from earlier today.";
                        dialoguecall(currenttext);
                        break;
                    case 28:
                        currenttext = "Smoker: Hey, you, do you wanna have a smoke with us?";
                        dialoguecall(currenttext);
                        break;
                    case 29:
                        choices = new string[2];
                        choices[0] = "Sure thing.";
                        choices[1] = "No thanks.";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 30://path 1
                        currenttext = "Yeah, thanks for offering. I am all out actually.";
                        dialoguecall(currenttext);
                        break;
                    case 31://Path 2
                        currenttext = "Nah, thanks for the offer though. I have a marathon to train for. You guys should do the same.";
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
        if (tree == 1)
            dialoguecounter = 4;
        else if (tree == 2)
            dialoguecounter = 16;
        tree++;
        dialoguecall(currenttext);
    }
    void ButtonTwo()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        currenttext = "...";
        if (tree == 1)
            dialoguecounter = 29;
        else if (tree == 2)
            dialoguecounter = 30;
        tree++;
        dialoguecall(currenttext);
    }
}
