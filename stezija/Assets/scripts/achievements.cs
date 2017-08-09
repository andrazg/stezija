using UnityEngine;
using UnityEngine.SceneManagement;

public class achievements : MonoBehaviour
{

    public GameObject ach;
    public GameObject achtxt;
    public GameObject trophy;

    public Transform cam;
    public Transform lookach;
    public Transform trophyloc;

    public TextMesh roundreached;
    public TextMesh checkpoint;
    public TextMesh messagenoach;

    int progress;
    int round;
    int level;

    Vector3 won = new Vector3(-6.6f, 0.08f, -1f);
    Vector3 notWon = new Vector3(-14f, 0.08f, -1f);
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        trophyloc.position = notWon;
        roundreached.text = "Round reached: " + PlayerPrefs.GetInt("level");
        checkpoint.text = "Checkpoint: " + PlayerPrefs.GetInt("checkpoint");

        Vector3 move = new Vector3(0, 1, 0);
        Vector3 moreDown = new Vector3(0, 1, 0);
        round = PlayerPrefs.GetInt("level");
        level = PlayerPrefs.GetInt("checkpoint");
        progress = level / 100;


        if (round < 100)
        {
            messagenoach.text = "By the Gods that live and dwell,\nYou have early came to hell.";
        }
        else if (round > 100 && round < 200)
        {
            messagenoach.text = "Squares play cruel and righteous game,\nnone but you is here to blame.";
        }
        else if (round > 200 && round < 300)
        {
            messagenoach.text = "Colors sometimes aren't real,\nbut the sounds that play you feel.";
        }
        else if (round > 300 && round < 400)
        {
            messagenoach.text = "Great are those who never quit,\nspecially if game is squid.";
        }
        else if (round > 400 && round < 500)
        {
            messagenoach.text = "Roses are red violets are blue,\nthis is such classic that I must use to.";
        }
        else if (round > 500 && round < 600)
        {
            messagenoach.text = "Half way through and half to go,\nthere is more that you must show.";
        }
        else if (round > 600 && round < 700)
        {
            messagenoach.text = "Puzzleoid, you came from space,\nyou enjoy this mindfull race.";
        }
        else if (round > 700 && round < 800)
        {
            messagenoach.text = "Float like a butterfly sting like a bee,\nand click the right button hopefully";
        }
        else if (round > 800 && round < 900)
        {
            messagenoach.text = "Play the game and play it well,\nYou are allmost out of hell.";
        }
        else if (round > 1000 && round < 1010)
        {
            trophyloc.position = won;
            messagenoach.text = "No regret and no remourse, your end of live is near, \nlooking back on dusty road your weakness was Just fear.";
        }
        else if (round > 1010)
        {
            trophyloc.position = won;
            messagenoach.text = "Your road goes on, but we depart,\nmy life is where I found my heart.";
        }
        else
        {
            messagenoach.text = "This one here is wrong to see,\nplease contact or notify me!!!";
        }



        string[] levels = new string[] {"...THE DAY THAT YOU'LL BE FREE...",
                                        "...WHEN YOU'RE A MAN THAT NEVER FLEE...",
                                        "...IS NOT YOUR DREAM TO BE...",
                                        "...HUNCHED FIGURE AND SAD FACE...",
                                        "...IS WHAT THE MIRROR SEES...",
                                        "...THE LIFE YOU'LL NEVER BREATHE...",
                                        "...REGRET THE ROAD THAT YOU'VE TAKEN...",
                                        "...AND CRY UNTIL YOUR SOUL IS BROKEN, DON'T...",
                                        "...TRY THE ROAD THAT YOU'RE AFFRAID...",
                                        "...SOME OF YOUR DREAMS WILL SHURELY FADE...",
                                        };

        for (int i = 0; i < progress; i++)
        {
            GameObject ach1 = Instantiate(ach, ach.transform.position-move, ach.transform.rotation);
            GameObject achtxt1 = Instantiate(achtxt, achtxt.transform.position-move, achtxt.transform.rotation);
            achtxt1.GetComponent<TextMesh>().text = levels[i];
            move += moreDown;


        }

    }

    void Update()
    {
        Camera.main.transform.rotation = Quaternion.Slerp(cam.rotation, lookach.rotation, Time.deltaTime * 2.0f);

        if (Input.touchCount == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "play")
                {
                    SceneManager.LoadScene("loading");
                }
            }
        }
    }
}
