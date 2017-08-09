using UnityEngine;

public class message : MonoBehaviour
{
    GameManager gm;
    public Transform achievemessage;

    Vector3 up = new Vector3(0, 2, 0);
    

	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
	}
	

	void Update ()
    {
        ///transformation for the checkpoint message
        if (gm.round % 50 == 0 && gm.gameActive)
        {
            if (transform.position.y < -5)
            {
                transform.Translate(up * Time.deltaTime*2);
            }
        }
        else
        {
            if (transform.position.y > -9)
            {
                transform.Translate(-up * Time.deltaTime*2);
            }
        }


        //transformation of the achievements message
        if (gm.round % 100 == 0 && gm.gameActive && gm.round < 1001)
        {
            if (achievemessage.transform.position.y > 5)
            {
                achievemessage.transform.Translate(-up * Time.deltaTime*2);
            }
        }
        else
        {
            if (achievemessage.transform.position.y < 9)
            {
                achievemessage.transform.Translate(up * Time.deltaTime*2);
            }
        }


    }
}
