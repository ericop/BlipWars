using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceBoxController : MonoBehaviour
{

    float xOfClick = 0;
    float yOfClick = 0;

    float xCenter = 0;
    float yCenter = 0;

    void Start()
    {
        var shape = GetComponent<Collider2D>();
        var selectRectangleCenter = shape.bounds.center;

        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);

        xCenter = transform.localPosition.x;
        yCenter = transform.localPosition.y;
        Debug.Log("centers x:" + xCenter + ", y:" + yCenter);

    }

    void OnMouseDown()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        xOfClick = pos.x;
        yOfClick = pos.y;
        Debug.Log("clicks x:" + xOfClick + ", y:" + yOfClick + " |centers x: " + xCenter + ", y: " + yCenter);
        //Debug.Log("x:" + (xOfClick - xCenter) + ", y:" + (yOfClick - yCenter));
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)
    //         //&&
    //         //Input.mousePosition.x > 648 &&
    //         // Input.mousePosition.x < 1048 && 
    //         // Input.mousePosition.y > 21 && 
    //         // Input.mousePosition.y < 190 
    //         )
    //    {
    //        //var mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //        //Debug.Log("mousePosition:" + mousePosition);
    //    }
    //    if (Input.touchCount > 0 && Input.touchCount < 3)
    //    {
    //        var touchPosition = Input.GetTouch(1).position;
    //        Debug.Log("touchPosition1:" + touchPosition);

    //        var touchPosition2 = Input.GetTouch(2).position;
    //        Debug.Log("touchPosition2:" + touchPosition2);

    //    }

    //}
}
