using UnityEngine;

public class txthover : MonoBehaviour
{


    Vector3 hov;
    public float multi = 0.05f;
    public float ampli = 0.05f;

    void Start ()
    {
        hov = transform.position;	
	}
	

	void Update ()
    {
        float xLet = hov.x;
        float ylet = multi * Mathf.Sin(Time.fixedTime * ampli) + hov.y;
        float zlet = hov.z;
        transform.position = new Vector3(xLet, ylet, zlet);

    }
}
