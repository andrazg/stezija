﻿using UnityEngine;

public class cuberotate : MonoBehaviour
{


	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }
}
