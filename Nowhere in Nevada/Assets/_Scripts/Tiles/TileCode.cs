using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCode : MonoBehaviour, IClickable, IMouseOverable
{

    public void MouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    public void MouseOver()
    {

    }

    public void MouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void OnClick()
    {

    }

    public void OnClickDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void OnClickUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnDragRelease()
    {

    }

    public void OnDragStart()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void OnDragUpdate()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
