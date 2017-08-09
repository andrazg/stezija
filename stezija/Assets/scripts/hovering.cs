using UnityEngine;

public class hovering : MonoBehaviour
{

    public Transform go;


    Vector3 hov;
    public float multi = 0.05f;
    public float ampli = 0.05f;

    GameManager gm;

	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent < GameManager>();
        hov = go.transform.position;
	}
	
	void Update ()
    {
        if (gm.gameActive == false)
        {
            //hover letsgo button
            float xLet = hov.x;
            float ylet = multi * Mathf.Sin(Time.fixedTime * ampli) + hov.y;
            float zlet = hov.z;
            go.transform.position = new Vector3(xLet, ylet, zlet);


        }

	}
}