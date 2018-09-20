using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MouseManager : MonoBehaviour {

    public float mouseDragDistance = 0.1f;
    IMouseOverable mouseOverCurrent;

    // Update is called once per frame
    void Update()
    {
        //Performing a 2D Raycast to hit an object
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
        //If the raycast hit something and is also not over UI
        if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseClickDown(hit.collider.gameObject);
            }
            IMouseOverable mouseOver = (IMouseOverable)hit.collider.gameObject.GetComponent(typeof(IMouseOverable));
            if (mouseOver != null && draggedObjects.Count == 0) {
                if (mouseOver != null)
                {
                    if (mouseOverCurrent != (IMouseOverable)mouseOver)
                    {
                        if (mouseOverCurrent != null)
                        {
                            mouseOverCurrent.MouseExit();
                        }
                        mouseOver.MouseEnter();
                        mouseOverCurrent = mouseOver;
                    }
                    mouseOver.MouseOver();
                }
            } else {
                if (mouseOverCurrent != null) {
                    mouseOverCurrent.MouseExit();
                    mouseOverCurrent = null;
                }
            }
        } else {
            if (mouseOverCurrent != null)
            {
                mouseOverCurrent.MouseExit();
                mouseOverCurrent = null;
            }
        }

        if (Input.GetMouseButton(0)) {
            MouseHold();
            Drag();
        }
    }



    void MouseClickDown(GameObject reciver) {
        IClickable item = (IClickable)reciver.GetComponent(typeof(IClickable));
        if (item != null) {
            item.OnClickDown();
            RegisterClick(reciver);
            mouseDownScreenPos = Input.mousePosition;
        }
    }



    static List<IClickable> clickedObjects = new List<IClickable>();
    static List<IDragable> draggedObjects = new List<IDragable>();
    Vector3 mouseDownScreenPos = Vector3.zero;

    void RegisterClick(GameObject clicked) {
        clickedObjects.Add((IClickable)clicked.GetComponent(typeof(IClickable)));
    }

    void RegisterDrag(IDragable dragged) {
        if (draggedObjects.Contains(dragged)){
            return;
        }
        draggedObjects.Add(dragged);
    }

    void MouseUp()
    {
        foreach (IClickable thing in clickedObjects) {
            thing.OnClickUp();
        }
        clickedObjects.Clear();
        EndDrag();
    }

    void MouseHold()
    {
        foreach (IClickable thing in clickedObjects)
        {
            try {
                thing.OnClick();
            } 
            catch
            {

            }


            if (Vector3.Distance(Input.mousePosition, mouseDownScreenPos) > mouseDragDistance && thing is IDragable)
            {
                StartDrag((IDragable)thing);
                RegisterDrag((IDragable)thing);
            }
        }
    }

    void StartDrag (IDragable dragable) {
        dragable.OnDragStart();
    }

    void Drag () {
        foreach (IDragable thing in draggedObjects) {
            try
            {
                thing.OnDragUpdate();
            }
            catch (NotImplementedException e)
            {
                Debug.LogWarning(e.Message);
            }

        }
    }

    void EndDrag () {
        foreach (IDragable thing in draggedObjects)
        {
            try
            {
                thing.OnDragRelease();
            } catch (NotImplementedException e) {
                Debug.LogWarning(e.Message);
            }
        }
        draggedObjects.Clear();
    }
}
