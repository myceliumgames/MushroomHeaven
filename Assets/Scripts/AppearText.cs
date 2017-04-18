using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearText : MonoBehaviour
{

    private bool isAppeared;
    private bool doneAppearing;
    public float appearSpeed;

    // Use this for initialization
    void Start()
    {
        isAppeared = false;
        doneAppearing = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            isAppeared = true;
        }

        if (isAppeared && !doneAppearing)
        {
            //this.gameObject.SetActive(false);
            Text[] myTexts = transform.GetComponentsInChildren<Text>();
            foreach (Text myText in myTexts)
            {
                Color myColor = myText.color;
                float currentAlpha = myColor.a;
                currentAlpha += appearSpeed * Time.deltaTime;
                if (currentAlpha > 1)
                {
                    currentAlpha = 1f;
                    doneAppearing = true;
                }
                myColor.a = currentAlpha;
                myText.color = myColor;
            }
        }

            //if (isAppeared) { objToAppear.SetActive(true); }
    }
}