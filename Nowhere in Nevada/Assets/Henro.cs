using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henro : MonoBehaviour {

    float time = 0;
    public float timing = 15f;
    public float moveSpeed = 1f;
    public float rotSpeed = 1f;

    public Vector2 lowerLeft;
    public Vector2 upperRight;

    Vector2 direction = new Vector2(1, 1);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > timing) {
            StartThing();
        }

        transform.Rotate(new Vector3(0, 0, rotSpeed*Time.deltaTime));

        transform.Translate(new Vector3(direction.x * moveSpeed * Time.deltaTime, direction.y * moveSpeed * Time.deltaTime, 0),UnityEngine.Space.World);

        if (transform.position.x > upperRight.x || transform.position.x < lowerLeft.x) {
            direction = new Vector2(direction.x * -1, direction.y);
        }

        if (transform.position.y > upperRight.y || transform.position.y < lowerLeft.y)
        {
            direction = new Vector2(direction.x, direction.y * -1);
        }

        if (time > 10 && gameObject.GetComponent<SpriteRenderer>().enabled) {
            GameObject newDude = Instantiate(this.gameObject);
            newDude.transform.position = new Vector3(UnityEngine.Random.value * 5, UnityEngine.Random.value * 10, 0);
            newDude.GetComponent<SpriteRenderer>().enabled = true;
            time = 0;
        }

    }

    private void StartThing()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
