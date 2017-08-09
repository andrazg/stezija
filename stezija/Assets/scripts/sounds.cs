using UnityEngine;

public class sounds : MonoBehaviour
{
    GameManager gm;
    AudioSource au;



    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        au = GameObject.FindGameObjectWithTag("effects").GetComponent<AudioSource>();

    }



    void up()
    {
        au.volume += Time.deltaTime * 0.2f;
    }

    void down()
    {
        au.volume -= Time.deltaTime * 0.2f;
    }

        void Update()
    {
        //if game starts the volume goes down
        if (gm.gameActive && au.volume > 0.1f)
        {
            down();
        }

        //if game ends the sound goes up
        else if (!gm.gameActive && au.volume < 0.7f)
        {
            up();
        }
    }
}
    