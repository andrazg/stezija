using UnityEngine;

public class buttons : MonoBehaviour
{

    GameManager gm;


    public Transform but1;
    public Transform but2;
    public Transform but3;
    public Transform but4;

    public Transform init1;
    public Transform init2;
    public Transform init3;
    public Transform init4;

    public Material blue;
    public Material red;
    public Material green;
    public Material yellow;

    public Color blau = new Color();
    public Color rot = new Color();
    public Color grun = new Color();
    public Color jello = new Color();

    bool moveBu1 = false;
    bool moveBu2 = false;
    bool moveBu3 = false;
    bool moveBu4 = false;

    Ray ray;
    RaycastHit hit;

    float time = 0;
    float realTime;

    Vector3 press = new Vector3(0, 0, 65);

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        blau = new Color32(45, 230, 253, 255);
        rot = new Color32(255, 88, 199, 255);
        grun = new Color32(80, 227, 105, 255);
        jello = new Color32(240, 255, 98, 255);
        time = 0;
    }




    void Update()
    {
        realTime = Time.fixedTime;

        /////////////////////////// button 1 press
        if (moveBu1 == true && realTime - time < 0.2)
        {
            but1.transform.position = Vector3.Lerp(but1.transform.position, but1.transform.position + press, Time.deltaTime * 0.01f);
            blue.color = Color.magenta;
        }
        else
        {
            moveBu1 = false;
            if (but1.transform.position != init1.transform.position)
            {
                but1.transform.position = init1.transform.position;
                blue.color = blau;
            }
        }

        ///////////////////////////////////////
        /////////////////////////// button 2 press

        if (moveBu2 == true && realTime - time < 0.2)
        {
            but2.transform.position = Vector3.Lerp(but2.transform.position, but2.transform.position + press, Time.deltaTime * 0.01f);
            red.color = Color.magenta;
        }
        else
        {
            moveBu2 = false;
            if (but2.transform.position != init2.transform.position)
            {
                but2.transform.position = init2.transform.position;
                red.color = rot;
            }
        }

        ///////////////////////////////////////
        /////////////////////////// button 3 press

        if (moveBu3 == true && realTime - time < 0.2)
        {
            but3.transform.position = Vector3.Lerp(but3.transform.position, but3.transform.position + press, Time.deltaTime * 0.01f);
            green.color = Color.magenta;
        }
        else
        {
            moveBu3 = false;
            if (but3.transform.position != init3.transform.position)
            {
                but3.transform.position = init3.transform.position;
                green.color = grun;
            }
        }


        ///////////////////////////////////////
        /////////////////////////// button 4 press

        if (moveBu4 == true && realTime - time < 0.2)
        {
            but4.transform.position = Vector3.Lerp(but4.transform.position, but4.transform.position + press, Time.deltaTime * 0.01f);
            yellow.color = Color.magenta;
        }
        else
        {
            moveBu4 = false;
            if (but4.transform.position != init4.transform.position)
            {
                but4.transform.position = init4.transform.position;
                yellow.color = jello;
            }
        }

        ///////////////////////////////////////


        if (gm.pause == false)
        {
            if (Input.touchCount == 1)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "1")
                    {
                        time = Time.fixedTime;
                        moveBu1 = true;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "2")
                    {
                        time = Time.fixedTime;
                        moveBu2 = true;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "3")
                    {
                        time = Time.fixedTime;
                        moveBu3 = true;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "4")
                    {
                        time = Time.fixedTime;
                        moveBu4 = true;
                    }
                }
            }
        }
    }
}
