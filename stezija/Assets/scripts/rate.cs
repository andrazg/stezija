using UnityEngine;

public class rate : MonoBehaviour
{
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20);
	}
}
