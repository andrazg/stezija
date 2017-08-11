using UnityEngine;

public class TouchInput : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Rigidbody rb;

    public bool left;
    public bool right;
    public bool jump;
    public int speed;



    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("player").GetComponent<Rigidbody>();
        speed = 1;
    }

    void Update()
    {
        if (left)
        {
            rb.AddForce(-10*speed, 0, 0);
        }
        if (right)
        {
            rb.AddForce(10*speed, 0, 0);
        }
        if (jump)
        {
            rb.AddForce(0, 10*speed, 0);
        }
        
        Touch[] myTouches = Input.touches;

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity) == true)
                {
                    //touch phase has begun
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        if (hit.collider.tag == "left")
                        {
                            left = true;
                        }
                        else if (hit.collider.tag == "right")
                        {
                            right = true;
                        }
                        else if (hit.collider.tag == "jump")
                        {
                            jump = true;
                        }
                    }
                    //touch phase has ended for buttons
                    else if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        if (hit.collider.tag == "left")
                        {
                            left = false;
                        }
                        else if (hit.collider.tag == "right")
                        {
                            right = false;
                        }
                        else if (hit.collider.tag == "jump")
                        {
                            jump = false;
                        }
                    }
                }
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) == false)
                {
                    left = false;
                    right = false;
                    jump = false;
                }
            }
        }
    }
}

