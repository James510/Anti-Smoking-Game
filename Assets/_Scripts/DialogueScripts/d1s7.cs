using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class d1s7 : MonoBehaviour
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
        currenttext = "Nurse: You have a new patient Doctor. They are waiting to see you."; //String type
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
                        currenttext = "You: Thank you.";
                        dialoguecall(currenttext);
                        break;
                    case 3:
                        background.SendMessage("ChangeBackground", 1);
                        isrunning = true;
                        StartCoroutine("SceneChangeNext", 2.0f);
                        break;
                    case 4:
                        currenttext = "You: Hello Ma’am, what can I do for you?";
                        dialoguecall(currenttext);
                        break;
                    case 5:
                        currenttext = "Woman: Well, my son has been coughing pretty badly, his pediatrician told me to come see you at this hospital. I don’t see why but here I am.";
                        dialoguecall(currenttext);
                        break;
                    case 6:
                        currenttext = "You: I see, well let me take a look.";
                        dialoguecall(currenttext);
                        break;
                    case 7:
                        currenttext = "Placing your stethoscope on his chest, you listen intently.";
                        dialoguecall(currenttext);
                        break;
                    case 8:
                        currenttext = "You: Well, it sounds like your son has some build up in his lungs. Do you perhaps smoke?";
                        dialoguecall(currenttext);
                        break;
                    case 9:
                        currenttext = "Woman: Yeah, me and my husband do.";
                        dialoguecall(currenttext);
                        break;
                    case 10:
                        currenttext = "You: Well, do you smoke in an isolated area or around your son?";
                        dialoguecall(currenttext);
                        break;
                    case 11:
                        currenttext = "Woman: Oh, we smoke where ever. It isn’t that bad you know. Everyone tries to scare you into quitting.";
                        dialoguecall(currenttext);
                        break;
                    case 12:
                        currenttext = "You: Well, it actually is bad, for you and your son both. Even though he isn’t the one smoking, he is still inhaling the smoke, and it is building up in his young underdeveloped lungs.";
                        dialoguecall(currenttext);
                        break;
                    case 13:
                        currenttext = "Woman: Are you trying to get me to quit? Wasn’t it bad enough I had to take a 9 month break when I was pregnant? That was torturous.";
                        dialoguecall(currenttext);
                        break;
                    case 14:
                        currenttext = "You: I am saying it might be a good idea for both you and your son if you quit. If you may, I would like to listen to your lungs?";
                        dialoguecall(currenttext);
                        break;
                    case 15:
                        currenttext = "Woman: Fine, whatever, sure.";
                        dialoguecall(currenttext);
                        break;
                    case 16:
                        currenttext = "You place your stethoscope on her chest and listen.";
                        dialoguecall(currenttext);
                        break;
                    case 17:
                        currenttext = "It sounds pretty bad.";
                        dialoguecall(currenttext);
                        break;
                    case 18:
                        currenttext = "You: Ma’am, I think you may have a form of lung cancer actually.";
                        dialoguecall(currenttext);
                        break;
                    case 19:
                        currenttext = "Woman: That is a lie. Smoking doesn’t really cause cancer Doctor.";
                        dialoguecall(currenttext);
                        break;
                    case 20:
                        currenttext = "You: Actually it does. I would like to run some more tests on you to be certain, but you are at risk ma’am.";
                        dialoguecall(currenttext);
                        break;
                    case 21:
                        currenttext = "Woman: Hmph. Whatever you say. Insurance better cover all of this.";
                        dialoguecall(currenttext);
                        break;
                    case 22:
                        currenttext = "She and her son leave the room, and you follow";
                        dialoguecall(currenttext);
                        break;
                    case 23:
                        background.SendMessage("ChangeBackground", 2);
                        isrunning = true;
                        StartCoroutine("SceneChangeNext", 2.0f);
                        break;
                    case 24:
                        currenttext = "Halfway down the hall, you bump into Clarice";
                        dialoguecall(currenttext);
                        break;
                    case 25:
                        currenttext = "You: Hey Clarice, how is it going?";
                        dialoguecall(currenttext);
                        break;
                    case 26:
                        currenttext = "Clarice: I’m doing alright Doc, feeling good so I am walking around a little.";
                        dialoguecall(currenttext);
                        break;
                    case 27:
                        currenttext = "You: That’s good. That’s good.";
                        dialoguecall(currenttext);
                        break;
                    case 28:
                        currenttext = "Clarice: You know, it’s funny, the past few days, all I have been thinking about is the things I never got to do. I told myself a few years ago I was gunna run a marathon. And go skiing. Haha.";
                        dialoguecall(currenttext);
                        break;
                    case 29:
                        currenttext = "You: . . .";
                        dialoguecall(currenttext);
                        break;
                    case 30:
                        currenttext = "Clarice: Oh well right? C’est la vie I suppose. Well, I’ll see you around Doc.";
                        dialoguecall(currenttext);
                        break;
                    case 31:
                        currenttext = "Continuing down the hall, your phone suddenly rings";
                        dialoguecall(currenttext);
                        break;
                    case 32:
                        currenttext = "It's your wife calling";
                        dialoguecall(currenttext);
                        break;
                    case 33:
                        currenttext = "You: Hey honey, what is it?";
                        dialoguecall(currenttext);
                        break;
                    case 34:
                        currenttext = "Wife: I was wondering if you could stop on the way home and pick up a few packs of cigarettes, we’re almost out.";
                        dialoguecall(currenttext);
                        break;
                    case 35:
                        string[] choices = new string[2];
                        choices[0] = "Yes dear, sure thing.";
                        choices[1] = "I’m not so sure that is a good idea anymore…";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 36://Path 1
                        currenttext = "Yeah, I can do that. It shouldn’t be a problem.";
                        dialoguecall(currenttext);
                        break;
                    case 37:
                        currenttext = "You hang up and head to the roof.";
                        dialoguecounter = 51;
                        dialoguecall(currenttext);
                        break;
                    case 38://Path 2
                        currenttext = "You: I’ve been thinking... Maybe we should try to cut down on cigarettes.";
                        dialoguecall(currenttext);
                        break;
                    case 39:
                        currenttext = "Wife: I really don’t need this right now. Just bring home the cigarettes okay?";
                        dialoguecall(currenttext);
                        break;
                    case 40:
                        choices = new string[2];
                        choices[0] = "Yes dear. I understand.";
                        choices[1] = "I really think we need to quit, hun.";
                        UIController.SendMessage("Decision", choices);
                        isrunning = true;
                        canGo = false;
                        break;
                    case 41://Path 1
                        currenttext = "You: Alright. I will do as you asked. I’m sorry.";
                        dialoguecall(currenttext);
                        break;
                    case 42:
                        currenttext = "Wife: Thank you. I will see you tonight.";
                        dialoguecall(currenttext);
                        break;
                    case 43:
                        currenttext = "She hangs up.";
                        dialoguecall(currenttext);
                        break;
                    case 44:
                        currenttext = "You head to the roof.";
                        dialoguecounter = 51;
                        dialoguecall(currenttext);
                        break;
                    case 45://Path 2
                        currenttext = "You: I really think it would be good for ourselves and the kids if we quit. Please?";
                        dialoguecall(currenttext);
                        break;
                    case 46:
                        currenttext = "Wife: . . .";
                        dialoguecall(currenttext);
                        break;
                    case 47:
                        currenttext = "Wife: If you say so. We can try it.";
                        dialoguecall(currenttext);
                        break;
                    case 48:
                        currenttext = "You: Thank you. I love you. I will see you tonight.";
                        dialoguecall(currenttext);
                        break;
                    case 49:
                        currenttext = "Wife: Yeah, yeah. See you tonight.";
                        dialoguecall(currenttext);
                        break;
                    case 50:
                        currenttext = "She hangs up.";
                        dialoguecall(currenttext);
                        break;
                    case 51:
                        currenttext = "You head to the roof.";
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
            dialoguecounter = 35;
        else if (tree == 2)
            dialoguecounter = 40;
        tree++;
        dialoguecall(currenttext);
    }
    void ButtonTwo()
    {
        canGo = true;
        UIController.SendMessage("Decided");
        currenttext = "...";
        if (tree == 1)
            dialoguecounter = 37;
        else if (tree == 2)
            dialoguecounter = 44;
        tree++;
        dialoguecall(currenttext);
    }
}
