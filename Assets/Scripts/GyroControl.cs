using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    private Rigidbody rb;
    public AudioSource goodMushroomAudio;
    public AudioSource badMushroomAudio;

    private int count;

    public Text scoreText;

    private Vector3 velocity;

    public float frictionFraction;
    private float velocityScale = 0.1f;
    

    private void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
        //goodMushroomAudio = GetComponent<AudioSource>();
        //badMushroomAudio = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        velocity = new Vector3(0, 0, 0);

    }

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);


            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
            velocity *= 1f - frictionFraction;

            if (Input.touchCount >= 1) { velocity += velocityScale * this.transform.forward; }
            cameraContainer.transform.position += velocity * Time.deltaTime;

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            Color myColor = other.GetComponent<MeshRenderer>().material.color;
            //Color myColor = other.GetComponentInChildren<MeshRenderer>().material.color;
            float myScale = other.GetComponentInParent<Transform>().localScale.x;
            int thisMushroomScore = (int)(-50f * myColor.r + (25f * myColor.g - 5f) * (25f * myColor.b - 5f) + 10f * Mathf.Pow(myScale, 2));
            if (thisMushroomScore >= 0) { goodMushroomAudio.Play(); }
            else { badMushroomAudio.Play(); }
            count += thisMushroomScore;
            if (count < 0) { count = 0; }
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
    }
}
