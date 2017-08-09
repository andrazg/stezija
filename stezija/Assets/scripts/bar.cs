using System.Collections;
using UnityEngine;

public class bar : MonoBehaviour
{
    GameManager gm;
    hud huda;
    public AudioSource au;

    float initialZtime;
    float time;
    float timeZ;
    float counter;
    int randomPerk;


    public GameObject timer;
    public GameObject powerUp;
    public GameObject timesUpPrefab;

    

    public Material tme;
    public Material pwr;

    bool instant;
    bool resetPower;




    void Start()
    {
        counter = 0;
        instant = true;
        initialZtime = -1.1f;
        tme.color = new Color32(45, 230, 253, 255);
        pwr.color = new Color32(45, 230, 253, 255);
        time = -1.1f;
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        huda = GameObject.FindGameObjectWithTag("perk").GetComponent<hud>();
    }

    IEnumerator depleted()
    {  
        partInstant();
        yield return new WaitForSeconds(0.5f);
        time = initialZtime;
        powerUp.transform.localScale = (new Vector3(0.05f, 0.05f, 0.0f));
        gm.gameOver();
        yield return new WaitForSeconds(0.5f);
        timer.transform.localScale = (new Vector3(0.05f, 0.05f, -1.1f));
        counter = 0;
    }

    //instantiates particle for bar depletion (when time is up)
    void partInstant()
    {
        if (instant == true)
        {
            GameObject timesUp2 = (GameObject)Instantiate(timesUpPrefab, timesUpPrefab.transform.position, timesUpPrefab.transform.rotation);
            Destroy(timesUp2, 2);
        }
        instant = false;       
    }

    void Update ()
    {
    
       
        //if level aka puzzle is well done
        if (gm.oneUp == true)
        {
            counter = counter + time / 6;           
            powerUp.transform.localScale = new Vector3(0.05f, 0.05f, counter);
            gm.oneUp = false;
        }
        //if power up is larger than 1,1 it goes resets itself checks for random numbers to update reply or forward
        if (powerUp.transform.localScale.z < -1.1)
        {
            counter = 0;
            powerUp.transform.localScale = new Vector3(0.05f, 0.05f, 0.0f);
            resetPower = true;
            randomPerk = Random.Range(1, 100);
            au.Play();
            if (randomPerk < 50 && resetPower == true)
            {
                huda.countF = huda.countF + 1;
                randomPerk = 0;
            }
            else
            {
                huda.countR = huda.countR + 1;
                randomPerk = 0;
            }

            if (resetPower == true)
            {
                powerUp.transform.localScale = new Vector3(0.05f, 0.05f, 0.0f);
                resetPower = false;
            }

        }


        //if in pause the puzzle has been ok done and is waiting for the godoja coroutine to finish the puzzle || if the game is over and goes to scores
        if (gm.pause==true)
        {
            time = initialZtime;
            tme.color = new Color32(45, 230, 253, 255);
        }

           // level = gm.round;

            if (gm.gameActive == true)
            {
                //count down stopage and local scale descaling on z 
                if (timer.transform.localScale.z < 0)
                {
                    time = time + Time.deltaTime / 10;
                }
                else
                { 
                    StartCoroutine(depleted());
                }
            //descaling timer bar
                    timer.transform.localScale = new Vector3(0.05f, 0.05f, time);

                //as percentage of time left :) not really true bar is 1,1f  for the colors below
                     timeZ = initialZtime * time * 100;
                        
                //material color change or bar  better would be ratio to byte and change color by time   
                if (timeZ < 90)
                {
                    tme.color = new Color32(45, 253, 89, 255);
                }
                if (timeZ < 70)
                {
                    tme.color = new Color32(45, 253, 107, 255);
                }
                if (timeZ < 60)
                {
                    tme.color = new Color32(69, 253, 45, 255);
                }
                if (timeZ < 50)
                {
                    tme.color = new Color32(174, 253, 45, 255);
                }
                if (timeZ < 40)
                {
                    tme.color = new Color32(216, 253, 45, 255);
                }
                if (timeZ < 30)
                {
                    tme.color = new Color32(253, 230, 45, 255);
                }
                if (timeZ < 20)
                {
                    tme.color = new Color32(255, 37, 0, 255);
                }
            }
        }
}

