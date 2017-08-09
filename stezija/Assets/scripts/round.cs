using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class round : MonoBehaviour {



	void Update () {
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime*0.2f);
    }
}
