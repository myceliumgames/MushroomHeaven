using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour {

    public float maxSize;
    public float growSpeed;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0f, 0f, 0f);
        maxSize = Random.Range(0.2f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x < maxSize)
        {
            float myUpdate = Time.deltaTime * growSpeed;
            transform.localScale += new Vector3(myUpdate, myUpdate, myUpdate);
        }
	}
}
