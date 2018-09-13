﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MouseManager : MonoBehaviour {

    public float mouseDragDistance = 0.1f;

    // Update is called once per frame
    void Update()
    {
        //Performing a 2D Raycast to hit an object
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //If the raycast hit something and is also not over UI
        if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseClickDown(hit.collider.gameObject);
            }
        }

        if (Input.GetMouseButton(0)) {
            MouseHold();
            Drag();
        }

        if (Input.GetMouseButtonUp(0)) {
            MouseUp();
            EndDrag();
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
        draggedObjects.Add(dragged);
    }

    void MouseUp()
    {
        foreach (IClickable thing in clickedObjects) {
            thing.OnClickUp();
            clickedObjects.Remove(thing);
        }
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
            thing.OnDragUpdate();
        }
    }

    void EndDrag () {
        foreach (IDragable thing in draggedObjects)
        {
            thing.OnDragRelease();
            draggedObjects.Remove(thing);
        }
    }
}
