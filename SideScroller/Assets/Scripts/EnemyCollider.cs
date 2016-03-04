using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    //Collision with bullet
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "ShotRight(Clone)")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.name == "ShotLeft(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
