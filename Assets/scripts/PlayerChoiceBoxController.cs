using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceBoxController : MonoBehaviour
{
    BuildPerTick buildPerTick;
    int attackerPerTick = 0;
    int workersPerTick = 0;
    int specialistPerTick = 0;
    int reseachPerTick = 0;

    float xOfClick = 0;
    float yOfClick = 0;

    float xCenter = 0;
    float yCenter = 0;

    float xDiff = 0;
    float yDiff = 0;

    void Start()
    {
        buildPerTick = new BuildPerTick()
        {
            AttackerPerTick = 0,
            WorkersPerTick = 0,
            SpecialistPerTick = 0,
            ResearchPerTick = 0
        };

    var shape = GetComponent<Collider2D>();
        var selectRectangleCenter = shape.bounds.center;

        //Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);

        xCenter = transform.localPosition.x;
        yCenter = transform.localPosition.y;
        Debug.Log("centers x:" + xCenter + ", y:" + yCenter);

    }

    private void Update()
    {
        StartCoroutine("AddUnit", buildPerTick);
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
            buildPerTick = new BuildPerTick()
            {
                AttackerPerTick = 2,
                WorkersPerTick = 0,
                SpecialistPerTick = 0,
                ResearchPerTick = 0
            };

        }

        if ((xDiff > 1 && xDiff < 2) &&
            (yDiff > 1 && yDiff < 2))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 4xAtt,...";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            buildPerTick = new BuildPerTick()
            {
                AttackerPerTick = 4,
                WorkersPerTick = 0,
                SpecialistPerTick = 0,
                ResearchPerTick = 0
            };
        }

        // Builder Workers
        if ((xDiff < 0 && xDiff > -1) &&
            (yDiff < 0 && yDiff > -1))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 2xWork,...";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            buildPerTick = new BuildPerTick()
            {
                AttackerPerTick = 0,
                WorkersPerTick = 2,
                SpecialistPerTick = 0,
                ResearchPerTick = 0
            };
        }

        if ((xDiff < -1 && xDiff > -2) &&
            (yDiff < -1 && yDiff > -2))
        {
            var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
            currentCommandText.text = "Current Command: 4xWork";
            var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();
            buildPerTick = new BuildPerTick()
            {
                AttackerPerTick = 0,
                WorkersPerTick = 4,
                SpecialistPerTick = 0,
                ResearchPerTick = 0
            };
        }
    }

}
