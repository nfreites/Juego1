using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision2D col)
    {
        if (col.gameObject.name == "Jugador")
        {
            Destroy(this);
        }
    }
}
