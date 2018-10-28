using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour {

    public float yRotationSpeed = 4f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, yRotationSpeed, 0);
	}
}
