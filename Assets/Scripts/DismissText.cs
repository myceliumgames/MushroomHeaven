using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DismissText : MonoBehaviour {

    private bool isDismissed;
    private bool doneBeingDismissed;
    public float dismissSpeed;

    // Use this for initialization
    void Start () {
        isDismissed = false;
        doneBeingDismissed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            isDismissed = true;
        }

        if (isDismissed && !doneBeingDismissed) {
            //this.gameObject.SetActive(false);
            Text[] myTexts = transform.GetComponentsInChildren<Text>();
            foreach (Text myText in myTexts)
            {
                Color myColor = myText.color;
                float currentAlpha = myColor.a;
                currentAlpha -= dismissSpeed * Time.deltaTime;
                if (currentAlpha < 0)
                {
                    currentAlpha = 0f;
                    doneBeingDismissed = true;
                }
                myColor.a = currentAlpha;
                myText.color = myColor;
            }
            //foreach (Transform child in transform) {
            //    child.GetComponent<Text>().color.a -= 0.1 * Time.deltaTime;
            //}


            //int numChildren = transform.childCount;
            //for (int i = 0; i < numChildren; i++)
            //{
             //   transform.GetChild(i).GetComponent<Text>().color
            //}
        }
    }
}