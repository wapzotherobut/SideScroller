using UnityEngine;
using System.Collections;

public class MoverLeft : MonoBehaviour {

    
	// Use this for initialization
	void Start () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().velocity = transform.right * -12f;
        }
    }
    //Collision with Wall
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Border")
        {
            Destroy(gameObject);
        }
    }
}
