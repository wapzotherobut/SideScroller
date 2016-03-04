using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShotCount : MonoBehaviour
{
    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Shots: " + (PlayerControl.sh);
    }
    //0 1.5 -23
}