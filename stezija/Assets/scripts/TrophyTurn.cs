using UnityEngine;

public class TrophyTurn : MonoBehaviour
{

	

	void Update ()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 40);
	}
}
