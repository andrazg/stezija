using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;
using Firebase.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    hud hd;
    

    public Transform came;
    public Transform look;
    public Transform look2;
    public Transform look3;
    public Transform look4;
    public Transform kje;
 

    public GameObject die;
    public GameObject live;
    public GameObject letsgo;

    public Camera cam;

    public AudioSource buttonClick;
    public AudioSource level;
    public AudioClip levelReset;
    public AudioClip checkpoint;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;

    public Material blue;
    public Material red;
    public Material green;
    public Material yellow;

    Color blau = new Color();
    Color rot = new Color();
    Color grun = new Color();
    Color jello = new Color();
    Color mag = Color.magenta;
    Color gray = new Color32(193, 193, 193, 255);

    Ray ray;
    RaycastHit hit;

    public List<int> puzzle = new List<int>() {};
    public List<int> result = new List<int>() {};

    public bool startGame = false;
    public bool gameActive = false;
    public bool cr = false;
    public bool pause = false;
    public bool score = false;
    public bool perk = false;
    public bool perk2 = false;
    public bool oneUp = false;
    public bool primNum;

    public float wait;
    public float time;
    double tutTime;
    public int round;
    public int clickedPlay;
    int levelUp = 1;
    int rand;
    string facebookshare = "https://www.facebook.com/sharer/sharer.php?u=https://play.google.com/store/search?q=synesthesia%20grudwa&c=apps";
    string rateApp = "market://details?id=com.dado.stezija";

    void Start()
    {
        if (PlayerPrefs.GetInt("checkpoint") > 1)
            {
                round = PlayerPrefs.GetInt("checkpoint") + 1;
            }
        else
            {
                round = 1;
            }

        new Parameter(FirebaseAnalytics.EventTutorialBegin,tutTime);
        pause = false;
        blue.color = new Color32(45, 230, 253, 255);
        red.color = new Color32(255, 88, 199, 255);
        green.color = new Color32(80, 227, 105, 255);
        yellow.color = new Color32(240, 255, 98, 255);
        perk = false;
        perk2 = false;
        blau = blue.color;
        rot = red.color;
        grun = green.color;
        jello = yellow.color;
        wait = 2;
        time = 0.3f;
        puzzle = new List<int>() { };
        rand = Random.Range(1, 5);
        puzzle.Add(rand);
        
        hd = GameObject.FindGameObjectWithTag("perk").GetComponent<hud>();
    }
    /// levels at primer numbers will have to be listened carefully/// not so beautifully written 
    void prime(int round)
    {
        int i = 0;
        bool prime = false;
        for (i = 2; i <= round / 2; i++)
        {
            if ((i == round))
                i = i + 1;
            if ((round % i == 0))
            {
                prime = true;
                break;
            }
        }
        if ((prime == false))
        {
            primNum = true;
            
        }
        else
        {
            primNum = false;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////


    void game(int x)
    {
        result.Add(x);
    }
    ///////////////////////////////////////leveling  
    void gameUpdate()
    {
        oneUp = true;
        round = round + levelUp;
        prime(round);
        //every tenth level resets
        if (round % 10 == 0)
        {
            level.PlayOneShot(levelReset);
            result.Clear();
            puzzle.Clear();
            rand = Random.Range(1, 5);
            puzzle.Add(rand);
            pause = true;
            StartCoroutine(Godoja());
        }
        else if (primNum && round > 50)
        {
            rand = Random.Range(1, 5);
            puzzle.Add(rand);
            result = new List<int>() { };
            pause = true;
            StartCoroutine(Nocol());
        }
        else
        {
            rand = Random.Range(1, 5);
            Debug.Log(rand);
            puzzle.Add(rand);
            result = new List<int>() { };
            pause = true;
            StartCoroutine(Godoja());
        }

    }

    //////////////////////////////////// all the tiles wil color themselves same color
    IEnumerator Nocol()
    {
        pause = true;
        //this i added for the tutorial exit
        result.Clear();
        AudioSource av = GetComponent<AudioSource>();
        yield return new WaitForSeconds(wait);
        for (int i = 0; i < puzzle.Count; i++)
        {
            if (puzzle[i] == 1)
            {
                av.PlayOneShot(one);
                blue.color = gray;
                red.color = gray;
                yellow.color = gray;
                green.color = gray;
                yield return new WaitForSeconds(time);
                blue.color = blau;
                red.color = rot;
                yellow.color = jello;
                green.color = grun;
            }
            else if (puzzle[i] == 2)
            {
                av.PlayOneShot(two);
                blue.color = gray;
                red.color = gray;
                yellow.color = gray;
                green.color = gray;
                yield return new WaitForSeconds(time);
                blue.color = blau;
                red.color = rot;
                yellow.color = jello;
                green.color = grun;
            }
            else if (puzzle[i] == 3)
            {
                av.PlayOneShot(three);
                blue.color = gray;
                red.color = gray;
                yellow.color = gray;
                green.color = gray;
                yield return new WaitForSeconds(time);
                blue.color = blau;
                red.color = rot;
                yellow.color = jello;
                green.color = grun;
            }
            else if (puzzle[i] == 4)
            {
                av.PlayOneShot(four);
                blue.color = gray;
                red.color = gray;
                yellow.color = gray;
                green.color = gray;
                yield return new WaitForSeconds(time);
                blue.color = blau;
                red.color = rot;
                yellow.color = jello;
                green.color = grun;
            }
            yield return new WaitForSeconds(0.2f);


        }
        wait = 1f;
        pause = false;
    }

    IEnumerator Godoja()
    {
        pause = true;
        //this i added for the tutorial exit
        result.Clear();
        AudioSource av = GetComponent<AudioSource>();
        yield return new WaitForSeconds(wait);
        for (int i = 0; i < puzzle.Count; i++)
        {
            if (puzzle[i] == 1)
            {
                av.PlayOneShot(one);
                blue.color = mag;
                yield return new WaitForSeconds(time);
                blue.color = blau;
            }
            else if (puzzle[i] == 2)
            {
                av.PlayOneShot(two);
                red.color = mag;
                yield return new WaitForSeconds(time);
                red.color = rot;
            }
            else if (puzzle[i] == 3)
            {
                av.PlayOneShot(three);
                green.color = mag;
                yield return new WaitForSeconds(time);
                green.color = grun;
            }
            else if (puzzle[i] == 4)
            {
                av.PlayOneShot(four);
                yellow.color = mag;
                yield return new WaitForSeconds(time);
                yellow.color = jello;
            }
            yield return new WaitForSeconds(0.2f);
        }
        wait = 1;
        pause = false;
    }

    public void gameOver()
    {
        hd.countF = 3;
        hd.countR = 3;
        result = new List<int>() { };
        puzzle = new List<int>() {};
        gameActive = false;
        score = true;
        wait = 2;
        if (PlayerPrefs.GetInt("checkpoint") > 1)
        {
            round = PlayerPrefs.GetInt("checkpoint");
        }
        else
        {
            round = 1;
        }

    }



    void Update()
    {
       ////time za analytics
        tutTime = Time.time;

        if (startGame == true)
        {
            if (gameActive == true)
            {
                StartCoroutine(Godoja());
                startGame = false;
            }  
        }
        if (perk == true)
        {
            result = new List<int>() { };
            StartCoroutine(Godoja());
            perk = false;
        }
        if (perk2 == true)
        {
            gameUpdate();
            perk2 = false;
        }


        ////look at game
        if (gameActive == true)
        { 
            cam.transform.rotation = Quaternion.Slerp(came.rotation, look.rotation, Time.deltaTime * 1.0f);
        }
        /////look at start
        else if (gameActive == false && cr == false && score == false)
        {
            cam.transform.rotation = Quaternion.Slerp(came.rotation, look2.rotation, Time.deltaTime * 2.0f);
        }
        ////look at credits
        else if (cr == true)
        {
            cam.transform.rotation = Quaternion.Slerp(came.rotation, look3.rotation, Time.deltaTime * 2.0f);
        }
        ////look at score
        else if (score == true)
        {
            cam.transform.rotation = Quaternion.Slerp(came.rotation, look4.rotation, Time.deltaTime * 2.0f);
        }




        //keyboard input spagetti
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameActive = true;
            cr = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            DestroyObject(die);
            Instantiate(live, kje);
        }
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            gameActive = false;
            cr = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameActive = false;
            cr = true;
        }


        if (pause == false)
       {
            //touch input spagetti for the menu buttons
            if (Input.touchCount == 1)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "go")
                    {
                        buttonClick.Play();
                        startGame = true;
                        gameActive = true;
                        pause = true;
                        clickedPlay = PlayerPrefs.GetInt("times");
                        clickedPlay += 1;
                        PlayerPrefs.SetInt("times", clickedPlay);
                        
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "credit")
                    {
                        buttonClick.Play();
                        gameActive = false;
                        cr = true;
                        //analytics for tutorial begin
                        new Parameter(FirebaseAnalytics.EventTutorialBegin, tutTime);
                        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventTutorialBegin);
                        
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "backtut")
                    {
                        buttonClick.Play();
                        gameActive = false;
                        cr = false;
                        
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "die")
                    {
                        buttonClick.Play();
                        gameActive = false;
                        cr = false;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "backscore")
                    {
                        buttonClick.Play();
                        gameActive = false;
                        cr = false;
                        score = false;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "play")
                    {
                        buttonClick.Play();
                        gameActive = true;
                        cr = false;
                        score = false;
                        startGame = true;

                        clickedPlay = PlayerPrefs.GetInt("times");
                        clickedPlay += 1;
                        PlayerPrefs.SetInt("times", clickedPlay);
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "score")
                    {
                        buttonClick.Play();
                        score = true;
                        
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "enterach")
                    {
                        buttonClick.Play();
                        SceneManager.LoadScene("achievements");
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "facebook")
                    {
                        buttonClick.Play();
                        Application.OpenURL(facebookshare);
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "rate")
                    {
                        buttonClick.Play();
                        Application.OpenURL(rateApp);
                        /*
                        GameObject[] ratio = GameObject.FindGameObjectsWithTag("rate");
                        foreach (GameObject i in ratio)
                            GameObject.Destroy(i);*/
                    }
                }
            }
       }


        //puzzle validation
        if (gameActive == true && result.Count == puzzle.Count)
        {
            Debug.Log(result.SequenceEqual(puzzle));
                if (!result.SequenceEqual(puzzle))
                {
                    round = 1;
                    gameOver();
                }
                else
                {
                    gameUpdate();
                }
            }
        else
        {
        }



        //touch input for buttons and audio play call ing method game which adds the inset to result array
       if (pause == false)
       {
            if (Input.touchCount == 1)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "1")
                    {
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.clip = one;
                        audio.Play();
                        game(1);
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "2")
                    {
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.clip = two;
                        audio.Play();
                        game(2);
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "3")
                    {
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.clip = three;
                        audio.Play();
                        game(3);

                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "4")
                    {
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.clip = four;
                        audio.Play();
                        game(4);
                    }
                }
            }
        }
    }
}

