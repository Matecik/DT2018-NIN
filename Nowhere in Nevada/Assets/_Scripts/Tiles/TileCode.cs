using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCode : MonoBehaviour, IDragable, IMouseOverable
{

    public void MouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    public void MouseOver()
    {
        throw new System.NotImplementedException();
    }

    public void MouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void OnClick()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

    public void OnDragStart()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void OnDragUpdate()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
