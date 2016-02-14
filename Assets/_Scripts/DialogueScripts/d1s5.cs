using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class d1s5 : MonoBehaviour
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
        currenttext = "You: Hey Clarice, how are you holding up? Your chart is looking good. You feeling alright?"; //String type
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
                        currenttext = "Clarice: Yeah, I am feeling better. The chest pain has subsided. Do you think I can go home soon? I want to spend some time with my dogs.";
                        dialoguecall(currenttext);
                        break;
                    case 3:
                        currenttext = "You: Yeah you should be ready for release in a few days. We just want to make sure you’ve recovered from the chemo and radiation enough to go on.";
                        dialoguecall(currenttext);
                        break;
                    case 4:
                        currenttext = "Clarice: Thanks. It means a lot that you are letting me go spend some time with my dogs and family to tie things up.";
                        dialoguecall(currenttext);
                        break;
                    case 5:
                        currenttext = "You: I know it does. I wouldn’t have it any other way. If you need anything, let me know";
                        dialoguecall(currenttext);
                        break;
                    case 6:
                        currenttext = "You head back to your office.";
                        dialoguecall(currenttext);
                        break;
                    case 7:
                        background.SendMessage("ChangeBackground", 1);
                        isrunning = true;
                        StartCoroutine("SceneChangeWait", 2.0f);
                        break;
                    case 8:
                        currenttext = "Clarice is one of your regulars, she's currently being treated for cancer at your clinic.";
                        dialoguecall(currenttext);
                        break;
                    case 9:
                        currenttext = "However, her health has taken a turn for the worse.";
                        dialoguecall(currenttext);
                        break;
                    case 10:
                        currenttext = "She may not have much time left.";
                        dialoguecall(currenttext);
                        break;
                    case 11:
                        currenttext = "Your assistant nurse enters the room.";
                        dialoguecall(currenttext);
                        break;
                    case 12:
                        currenttext = "Nurse: Your next patient is here now Doctor.";
                        dialoguecall(currenttext);
                        break;
                    case 13:
                        currenttext = "You: Ah, yes thank you. I will be right there.";
                        dialoguecall(currenttext);
                        break;
                    case 14:
                        background.SendMessage("ChangeBackground", 3);
                        isrunning = true;
                        StartCoroutine("SceneChangeWait", 2.0f);
                        break;
                    case 15:
                        currenttext = "You: Hello, What can I help you with today?";
                        dialoguecall(currenttext);
                        break;
                    case 16:
                        currenttext = "Mother: Hello, we were hoping you could examine Jimmy. We caught him smoking the other day";
                        dialoguecall(currenttext);
                        break;
                    case 17:
                        currenttext = "Jimmy: I told you Mom. I wasn’t smoking. I was vaping. There’s a difference. I wasn’t smoking.";
                        dialoguecall(currenttext);
                        break;
                    case 18:
                        currenttext = "Mother: There was smoke coming out of the thing in your mouth, Jimmy.";
                        dialoguecall(currenttext);
                        break;
                    case 19:
                        currenttext = "Jimmy: It is water vapor Mom, perfectly safe and fine.";
                        dialoguecall(currenttext);
                        break;
                    case 20:
                        currenttext = "You: Actually, Jimmy, vaping isn’t as safe and healthy as everyone thinks it is. Even though vaping is mainly water vapor, there are still chemicals in it. They aren’t as harmful as the ones you find in cigarettes, but they are still not natural and your lungs are not meant to process them in that concentration. Not to mention, vaping is still inhaling nicotine, which is the addictive chemical found in other tobacco products.";
                        dialoguecall(currenttext);
                        break;
                    case 21:
                        currenttext = "Mother: See, I told you Jimmy, you were smoking. I don’t know why you don’t listen to me.";
                        dialoguecall(currenttext);
                        break;
                    case 22:
                        currenttext = "Jimmy: Aw, alright. I’m sorry mom. I won’t do it anymore. I didn’t know it was bad. It’s just that all the cool kids at school do it. I wanted to fit in and for them to like me.";
                        dialoguecall(currenttext);
                        break;
                    case 23:
                        currenttext = "You: Here, take these pamphlets and give them to the kids at your school. Maybe you can help them, then maybe they will want to be your friend.";
                        dialoguecall(currenttext);
                        break;
                    case 24:
                        currenttext = "Father: Thank you Doctor. I am glad we brought him in.";
                        dialoguecall(currenttext);
                        break;
                    case 25:
                        currenttext = "You: No problem.";
                        dialoguecall(currenttext);
                        break;
                    case 26:
                        currenttext = "The family leaves after you hand them the pamphlets";
                        dialoguecall(currenttext);
                        break;
                    case 27:
                        currenttext = "You head back to the office";
                        dialoguecall(currenttext);
                        break;
                    case 28:
                        background.SendMessage("ChangeBackground", 2);
                        isrunning = true;
                        StartCoroutine("SceneChangeWait", 2.0f);
                        break;
                    case 29:
                        currenttext = "You get a guilty feeling after dealing with smokers. How can you tell people to quit when you haven't done it yourself?";
                        dialoguecall(currenttext);
                        break;
                    case 30:
                        currenttext = "Nurse: There is a walk in to see you Doctor.";
                        dialoguecall(currenttext);
                        break;
                    case 31:
                        currenttext = "You: Alright, thank you. I will be right there.";
                        dialoguecall(currenttext);
                        break;
                    case 32:
                        background.SendMessage("ChangeBackground", 3);
                        isrunning = true;
                        StartCoroutine("SceneChangeWait", 2.0f);
                        break;
                    case 33:
                        currenttext = "There is an old man waiting for you in the next room over";
                        dialoguecall(currenttext);
                        break;
                    case 34:
                        currenttext = "You: Hello. What brings you in today?";
                        dialoguecall(currenttext);
                        break;
                    case 35:
                        currenttext = "Old Man: Well, my daughter is going to have a son soon, and I want to make sure I am in tip top shape for him. I know I can’t erase the mistakes I have already made, but I would like to know that I am not further damaging myself, and that my little grandson won’t be at risk from getting anything from me. So I was wondering if you knew a quick and easy way to quit smoking?";
                        dialoguecall(currenttext);
                        break;
                    case 36:
                        currenttext = "You: Well, there is no way to quit that is quick and easy. There are prescriptions that can help, but when it comes down to it, it really takes determination. You have to want to quit more than you want to smoke, which can be very hard for some people. It isn’t just an emotional thing, it is a chemical thing too. Your body craves the chemicals, so you have to fight it. If you are really sure about this, I can prescribe you something that can help curb the side effects of quitting, but it will ultimately be up to you.";
                        dialoguecall(currenttext);
                        break;
                    case 37:
                        currenttext = "Old Man: . . .";
                        dialoguecall(currenttext);
                        break;
                    case 38:
                        currenttext = "Old Man: I need to do this. For him. If it will be tough, then I just have to be tougher.";
                        dialoguecall(currenttext);
                        break;  
                    case 39:
                        currenttext = "You hand him a pamphlet and he leaves.";
                        dialoguecall(currenttext);
                        break;
                    case 40:
                        currenttext = "Looking at your watch, you realize it's lunchtime already, and head out to the food stands.";
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
