using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour {

    public float fadeSpeed = 3.5f;
    public static bool sceneEnd = false;

    private int a = 255;
    private int b = 0;

    void Update()
    {
        Image c = gameObject.GetComponent<Image>();

        c.color = new Color(a, a, a, b);
        
        if (sceneEnd == true)
        {
            System.Threading.Thread.Sleep(200);
            b++;
        }
    }
}
