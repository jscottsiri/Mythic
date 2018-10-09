using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClick : MonoBehaviour {
    public GameObject Selector;

    Vector3 posit;
    void OnMouseDown()
    {
        //get mouse position
        posit = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //convert to proper placement
        posit.x = Mathf.Floor(posit.x) + 0.5f;
        posit.y = Mathf.Floor(posit.y) + 0.5f;
        posit.z = 0;

        //move selector
        Selector.transform.position = posit;
        Debug.Log(posit.x + ", " + posit.y);
    }
}
