using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class d1s3 : MonoBehaviour
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
        currenttext = "You: One coffee please, just the usual."; //String type
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
                        currenttext = "Cashier: Coming right up.";
                        dialoguecall(currenttext);
                        break;
                    case 3:
                        currenttext = "It's become some sort of daily ritual where I get a coffee from here everyday. The owner, Michael, has become a good friend of mine.";
                        dialoguecall(currenttext);
                        break;
                    case 4:
                        currenttext = "Cashier: Here you go. Have a nice day!";
                        dialoguecall(currenttext);
                        break;
                    case 5:
                        background.SendMessage("ChangeBackground", 1);
                        isrunning = true;
                        StartCoroutine("SceneChangeWait", 2.0f);
                        break;
                    case 6:
                        currenttext = "Smoker: Hey can I borrow a lighter Sid?";
                        dialoguecall(currenttext);
                        break;
                    case 7:
                        currenttext = "You: Hey, what are you doing?";
                        dialoguecall(currenttext);
                        break;
                    case 8:
                        currenttext = "Smoker: We are having a cigarette or two. Would you like to join us?";
                        dialoguecall(currenttext);
                        break;
                    case 9:
                        currenttext = "(What will you do?)";
                        dialoguecall(currenttext);
                        break;
                    case 10:
                        string[] choices = new string[2];
                        choices[0] = "Take one out and light up";
                        choices[1] = "Ask them politely to not smoke so close to others";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 11: //Path 1
                        currenttext = "You: Sure. Thanks, can I borrow a lighter too?";
                        dialoguecall(currenttext);
                        break;
                    case 12:
                        currenttext = "Smoker: Yeah, here. So what are you doing?";
                        dialoguecall(currenttext);
                        break;
                    case 13:
                        currenttext = "You: On my way to work.";
                        dialoguecall(currenttext);
                        break;
                    case 14:
                        currenttext = "Smoker: Ah, that sounds boring.";
                        dialoguecall(currenttext);
                        break;
                    case 15:
                        currenttext = "You: Can be, but is necessary. Anyway, thanks.";
                        dialoguecounter = 28;
                        dialoguecall(currenttext);
                        break;
                    case 16://Path 2
                        currenttext = "You: No thank you, but I was wondering if you could maybe not smoke so close to the sidewalk and other people?";
                        dialoguecall(currenttext);
                        break;
                    case 17:
                        currenttext = "Smoker: Well actually, this is a free country and we can smoke where we want to, so why don’t you move away from us?";
                        dialoguecall(currenttext);
                        break;
                    case 18:
                        choices = new string[2];
                        choices[0] = "I wasn’t trying to be rude. I was just asking for you to be polite";
                        choices[1] = "Excuse you!";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 19://Path 1
                        currenttext = "You: I wasn’t trying to be rude. I was just asking for you to be polite";
                        dialoguecounter = 28;
                        dialoguecall(currenttext);
                        break;
                    case 20://Path2
                        currenttext = "You: Excuse you!";
                        dialoguecall(currenttext);
                        break;
                    case 21:
                        currenttext = "You: Everyone else has a right to not be around your smoke.";
                        dialoguecall(currenttext);
                        break;
                    case 22:
                        currenttext = "Smokers: Well, we don’t really care about that.";
                        dialoguecall(currenttext);
                        break;
                    case 23:
                        choices = new string[2];
                        choices[0] = "Why don’t I explain to you the risks of secondhand smoke?";
                        choices[1] = "You really need to move";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 24://Path1
                        currenttext = "You: Why don’t I explain to you the risks of secondhand smoke?";
                        dialoguecall(currenttext);
                        break;
                    case 25:
                        currenttext = "You: You see, when you are smoking in public like this, not only is it unpleasant for other people, it can also trigger asthma attacks or cause asthma in children and infants. And there is a chance that it can cause cancer in others as well. Why don’t you come to my clinic and I can tell you more?";
                        dialoguecall(currenttext);
                        break;
                    case 26:
                        currenttext = "They agree to follow you to your clinic.";
                        dialoguecounter = 28;
                        flag1 = true;
                        dialoguecall(currenttext);
                        break;
                    case 27://Path2
                        currenttext = "You: You really need to move.";
                        dialoguecall(currenttext);
                        break;
                    case 28:
                        currenttext = "You: Don’t subject other people to your smoke.";
                        dialoguecall(currenttext);
                        break;
                    case 29://End
                        currenttext = "You head to work.";
                        dialoguecall(currenttext);
                        break;
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
        if(flag1)
            UIController.SendMessage("NextScene",6);
        else
            UIController.SendMessage("NextScene", 7);
    }
    void ButtonOne()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        if(tree==1)
            dialoguecounter = 10;
        if (tree == 2)
            dialoguecounter = 18;
        if (tree == 3)
            dialoguecounter = 23;
        currenttext = "...";
        tree++;
        dialoguecall(currenttext);
    }
    void ButtonTwo()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        if (tree == 1)
            dialoguecounter = 15;
        if (tree == 2)
            dialoguecounter = 19;
        if (tree == 3)
            dialoguecounter = 26;
        currenttext = "...";
        tree++;
        dialoguecall(currenttext);
    }
}
