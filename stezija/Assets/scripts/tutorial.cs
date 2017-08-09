using System.Collections;
using UnityEngine;
using Firebase.Analytics;

public class tutorial : MonoBehaviour
{

    GameManager gm;
 
    public int count;
    public int left;

    public Transform forward;
    public Transform reply;
    public Transform rep;

    public GameObject seeFwd;
    public GameObject seeRep;
    public GameObject text;

    public TextMesh message;

    bool instantReply;
    bool instantForward;

    int counter;

    
    //cr is the bool for the look of camera at tutorials menu

    Ray ray;
    RaycastHit hit;

    string start = "Press the RED to learn some more, or a BLUE to go and score. ";
    string next1 = "Play the songs that SQUARES have sung, spare the air of your young lung.";
    string next2 = "Green button one, knows how to cheat, the other knows what means repeat.";
    string next3 = "";
    string next4 = "What bars here do you must know to, or time you play will be overdue.";
    string next5 = "ROUNDS you'll win and counted they are, count down the length and you'll be a star.";
    string next6 = "50th's rounds the save place will be, 100s are safer and achivements you'll see.";
    string next7 = "Millenium round, here I will wait, if you join me there it would be great.";
    string next8 = "Let's have some fun, the RED one will do, at this time around the BLUE will do to. ";
    string blank = "";

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        message.text = start;
        counter = 10;
        instantForward = false;
        instantReply = false;
    }


    void Update()
    {
        if (gm.cr == true)
        {

            if (Input.touchCount == 1)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "credit")
                    {
                        GameObject text1 = (GameObject)(Instantiate(text, text.transform.position, text.transform.rotation));
                        message = text1.GetComponent<TextMesh>();
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "2")
                    {
                        count = count + 1;
                        counter = counter - 1;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "1")
                    {
                        count = 10;
                    }
                }

            }
            //messages from trings up there
            if (count == 1)
            {
                message.text = next1;
                //StartCoroutine(wait(next1));                
            }
            else if (count == 2)
            {
                message.text = next2;
            }
            else if (count == 3)
            {
                message.text = next3;
                transform.LookAt(forward);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40, 0.1f);

                if (count == 3 && instantForward == false)
                {
                    GameObject fw = (GameObject)Instantiate(seeFwd, seeFwd.transform.position, seeFwd.transform.rotation);
                    instantForward = true;
                    Destroy(fw, 5);
                }
            }
            //looking reply
            else if (count == 4)
            {
                transform.LookAt(reply);

                if (count == 4 && instantReply == false)
                {
                    GameObject re = (GameObject)Instantiate(seeRep, seeRep.transform.position, seeRep.transform.rotation);
                    instantReply = true;
                    Destroy(re, 5);
                }
            }
            else if (count == 5)
            {
                message.text = next4;
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, 0.1f);
            }
            else if (count == 6)
            {
                message.text = next5;
            }
            else if (count == 7)
            {
                message.text = next6;
            }
            else if (count == 8)
            {
                message.text = next7;
            }
            else if (count == 9)
            {
                message.text = next8;
            }
            else if (count == 10)
            {
                message.text = blank;
                gm.cr = false;
                count = 0;
                gm.result.Clear();

                //analytics for tutorial end
                double tutTimeEnd = Time.time;
                new Parameter(FirebaseAnalytics.EventTutorialBegin, tutTimeEnd);
                FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventTutorialComplete);
            }
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, 0.1f);
        }
    }

   /* IEnumerator wait(string str)
    {
 
        for (int i = 0; i < str.Length; i++)
        {
            message.text = message.text += str[i];
            yield return new WaitForSeconds(0.1f);
        }
    } *////doesn work as i want it
}

