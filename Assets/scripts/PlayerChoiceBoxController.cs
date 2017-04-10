using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceBoxController : MonoBehaviour
{

    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }
    void OnMouseOver()
    {
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0) 
        //     //&&
        //     //Input.mousePosition.x > 648 &&
        //     // Input.mousePosition.x < 1048 && 
        //     // Input.mousePosition.y > 21 && 
        //     // Input.mousePosition.y < 190 
        //      )
        // {
        //     //var mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //     //Debug.Log("mousePosition:" + mousePosition);
        // }
        //if (Input.touchCount > 0 && Input.touchCount < 3)
        // {
        //     var touchPosition = Input.GetTouch(1).position;
        //     Debug.Log("touchPosition1:" + touchPosition);

        //     var touchPosition2 = Input.GetTouch(2).position;
        //     Debug.Log("touchPosition2:" + touchPosition2);

        // }

    }
}
