using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour {

    public float speed = 1f;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(new Vector3(-1.5f*speed*Time.deltaTime,-1f*speed*Time.deltaTime,0));
        if (gameObject.transform.position.y <= -10) {
            gameObject.transform.position = Vector3.zero;
        }
	}
}
