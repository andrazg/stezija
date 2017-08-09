using UnityEngine;

public class lookcamera : MonoBehaviour {




	void Update ()
    {
        transform.LookAt(Camera.main.transform);
	}
}
