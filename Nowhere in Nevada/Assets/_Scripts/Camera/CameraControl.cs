using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public bool cameraCanMove = true;
    Vector3 prevMousePos = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraCanMove)
        {
            if (Input.GetMouseButton(2))
            {
                Vector3 transformAmmount;
                transformAmmount = Input.mousePosition - prevMousePos;
                gameObject.transform.Translate(transformAmmount);
            }
        }
        prevMousePos = Input.mousePosition;
    }
}
