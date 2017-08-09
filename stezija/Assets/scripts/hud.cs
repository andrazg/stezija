using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud : MonoBehaviour
{

    GameManager gm;

    public Material forward;
    public Material reply;

    public Transform fwdGO;
    public Transform repGO;
    public Transform initFwd;
    public Transform initRep;    

    public TextMesh repMesh;
    public TextMesh fwdMesh;
    public TextMesh ro;
    public TextMesh le;

    bool rotator;
    bool rotator2;

    Ray ray;
    RaycastHit hit;

    public int countF;
    public int countR;
    int countPuzzle;

    float realTime;
    float time;

    Color fwd = new Color32(60, 255, 34, 255);
    Color rep = new Color32(60, 255, 34, 255);
    Color magi = Color.magenta;

    Vector3 press;

    AudioSource au;

    void Start()
    {
        countPuzzle = 0;
        time = 0;
        press = new Vector3(50, 0, 0);
        rotator = false;
        rotator2 = false;
        forward.color = fwd;
        reply.color = rep;
        gm = Camera.main.GetComponent<GameManager>();
        au=GetComponent<AudioSource>();
        countF = 5;
        countR = 5;     
    }

    void Update()
    {
        if (gm.gameActive == true)
        {
            realTime = Time.fixedTime;
            if (countF == 0)
            {
                forward.color = magi;
            }
            else if (countF > 0)
            {
                forward.color = fwd;
            }

            if (countR == 0)
            {
                reply.color = magi;
            }
            else if (countR > 0)
            {
                reply.color = rep;
            }

            countPuzzle = gm.puzzle.Count - gm.result.Count;

            string r = countR.ToString();
            string f = countF.ToString();
            string lengthS = countPuzzle.ToString();
            string roundS = gm.round.ToString();

            fwdMesh.text = f;
            repMesh.text = r;
            le.text = lengthS;
            ro.text = roundS;


            //////////////////////////////////////////////////////////////move reply button

            if (rotator2 == true && realTime - time < 0.3)
            {
                repGO.transform.position = Vector3.Lerp(repGO.transform.position, repGO.transform.position + press, Time.deltaTime * 0.01f);
            }
            else
            {
                rotator2 = false;

                if (repGO.transform.position != initRep.transform.position)
                {
                    repGO.transform.position = initRep.transform.position;
                }
            }

            //////////////////////////////////////////////////////////////move forward button

            if (rotator == true && realTime - time < 0.4)
            {
                fwdGO.transform.position = Vector3.Lerp(fwdGO.transform.position, fwdGO.transform.position + press, Time.deltaTime * 0.01f);

            }
            else
            {
                rotator = false;

                if (fwdGO.transform.position != initFwd.transform.position)
                {
                    fwdGO.transform.position = initFwd.transform.position;
                }
            }

            if (gm.pause == false)
            {
                if (Input.touchCount == 1)
                {
                    ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "forward")
                        {
                            if (countF > 0)
                            {
                                countF -= 1;
                                rotator = true;
                                gm.perk2 = true;
                                time = Time.fixedTime;
                                au.Play();
                            }
                        }
                        if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "reply")
                        {
                            if (countR > 0)
                            {
                                countR -= 1;
                                rotator2 = true;
                                gm.perk = true;
                                time = Time.fixedTime;
                                au.Play();
                            }
                        }
                    }
                }
            }
        }
        else if (gm.gameActive == false)
        {
            forward.color = fwd;
            reply.color = rep;
            countF = 5;
            countR = 5;
        }
    }
}
