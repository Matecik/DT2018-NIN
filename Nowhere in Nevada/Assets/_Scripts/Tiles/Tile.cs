using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IClickable {

    public void OnClick()
    {
        throw new System.NotImplementedException();
    }

    public void OnClickDown()
    {
        Debug.Log("HEY YALLL I HAVE BEEN CLCIKED");
    }

    public void OnClickUp()
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
