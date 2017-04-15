using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceBoxController : MonoBehaviour
{

    float xOfClick = 0;
    float yOfClick = 0;

    float xCenter = 0;
    float yCenter = 0;

    float xDiff = 0;
    float yDiff = 0;

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
        xDiff = (xOfClick - xCenter);
        yDiff = (yOfClick - yCenter);
        Debug.Log("clicks x:" + xOfClick + ", y:" + yOfClick + " |centers x: " + xCenter + ", y: " + yCenter + "| diff x:" + xDiff + "| diff y:" + yDiff);
        //Debug.Log("x:" + (xOfClick - xCenter) + ", y:" + (yOfClick - yCenter));


        var spendingPin = GameObject.FindWithTag("SpendingPin");
        spendingPin.transform.position = new Vector2(xOfClick, yOfClick);

        // Build Attackers
        if ((xDiff > 0 && xDiff < 1) &&
            (yDiff > 0 && yDiff < 1))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 2xAtt,...";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            playerGenZoneController.AddAttacker();
            playerGenZoneController.AddAttacker();

        }

        if ((xDiff > 1 && xDiff < 2) &&
            (yDiff > 1 && yDiff < 2))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 4xAtt,...";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            playerGenZoneController.AddAttacker();
            playerGenZoneController.AddAttacker();
            playerGenZoneController.AddAttacker();
            playerGenZoneController.AddAttacker();
        }

        // Builder Workers
        if ((xDiff < 0 && xDiff > -1) &&
            (yDiff < 0 && yDiff > -1))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 2xWork,...";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            playerGenZoneController.AddWorker();
            playerGenZoneController.AddWorker();
        }

        if ((xDiff < -1 && xDiff > -2) &&
            (yDiff < -1 && yDiff > -2))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 4xWork";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            playerGenZoneController.AddWorker();
            playerGenZoneController.AddWorker();
            playerGenZoneController.AddWorker();
            playerGenZoneController.AddWorker();
        }
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
