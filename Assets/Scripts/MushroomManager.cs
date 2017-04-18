using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager : MonoBehaviour {

    public GameObject mushroom;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    public float spawnTime = 8f;

    private AudioSource audio;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 2f, spawnTime);
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Spawn () {
        audio.Play();
        GameObject myMushroom = Instantiate(mushroom, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
        //myMushroom.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        myMushroom.GetComponentInChildren<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //float myScale = Random.Range(0.2f, 5f);
        //myMushroom.GetComponent<Enlarge>().maxSize = Random.Range(0.2f, 5f);
        //myMushroom.GetComponent<Transform>().localScale *= myScale;
	}
}
