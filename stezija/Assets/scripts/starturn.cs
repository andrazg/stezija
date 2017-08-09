using UnityEngine;

public class starturn : MonoBehaviour
{


	void Update ()
    {
        transform.Rotate(Vector3.right * Time.deltaTime*50);
	}
}
