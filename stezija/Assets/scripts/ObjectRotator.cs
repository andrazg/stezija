using UnityEngine;

public class ObjectRotator : MonoBehaviour
{


	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }
}
