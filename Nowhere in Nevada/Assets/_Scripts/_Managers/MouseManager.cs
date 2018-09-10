using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Performing a 2D Raycast to hit an object
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //If the raycast hit something and is also not over UI
        if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0)) {
                MouseClickDown(hit);
            }
            if (Input.GetMouseButtonUp(0))
            {
                MouseClickUp(hit);
            }
            if (Input.GetMouseButton(0))
            {
                MouseClick(hit);
            }
        }
    }

    void MouseClickDown(RaycastHit2D hit) {
        IClickable item = (IClickable)hit.collider.gameObject.GetComponent(typeof(IClickable));
        if (item != null) {
            item.OnClickDown();
        }
    }

    void MouseClickUp(RaycastHit2D hit)
    {
        IClickable item = (IClickable)hit.collider.gameObject.GetComponent(typeof(IClickable));
        if (item != null)
        {
            item.OnClickUp();
        }
    }

    void MouseClick(RaycastHit2D hit)
    {
        IClickable item = (IClickable)hit.collider.gameObject.GetComponent(typeof(IClickable));
        if (item != null)
        {
            item.OnClick();
        }
    }
}
