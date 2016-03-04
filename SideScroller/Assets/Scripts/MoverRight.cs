using UnityEngine;
using System.Collections;

public class MoverRight : MonoBehaviour {

    void Start()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().velocity = transform.right * 12f;
        }
        
    }
    //Collision with wall
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Border")
        {
            Destroy(gameObject);
        }
    }
}
