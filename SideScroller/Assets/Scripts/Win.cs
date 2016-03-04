using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
    public static int Enemies;

        

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Enemies = GameObject.FindGameObjectsWithTag("Disappointment").Length;

        /*if (Enemies == 0)
        {
            Debug.Log("what a meme");
        }*/
        
    }
}
