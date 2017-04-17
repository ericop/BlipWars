using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceBoxController : MonoBehaviour
{
    private BuildPerTick buildPerTick;

    float xOfClick = 0;
    float yOfClick = 0;

    float xCenter = 0;
    float yCenter = 0;

    float xDiff = 0;
    float yDiff = 0;

    internal BuildPerTick BuildPerTick
    {
        get
        {
            return buildPerTick;
        }

        set
        {
            buildPerTick = value;
        }
    }

    void Start()
    {
        BuildPerTick = new BuildPerTick()
        {
            Attackers = 0,
            Workers = 0,
            Snipers = 0,
            TaskMasters = 0
        };

        var shape = GetComponent<Collider2D>();
        var selectRectangleCenter = shape.bounds.center;

        //Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);

        xCenter = transform.localPosition.x;
        yCenter = transform.localPosition.y;
        Debug.Log("centers x:" + xCenter + ", y:" + yCenter.ToString());

        StartCoroutine("DoChecks");
    }

    private void Update()
    {
        //
    }

    IEnumerator DoChecks()
    {
        for (;;)
        {
            StartCoroutine("AddUnits", BuildPerTick);
            yield return new WaitForSeconds(.25f);
        }
    }

    IEnumerator AddUnits(BuildPerTick buildPerTick)
    {
        var playerGenZoneController = GameObject.FindWithTag("PlayerGenZone").GetComponent<PlayerGenZoneController>();

        if (buildPerTick.Snipers > 0)
        {
            for (int i = 0; i < buildPerTick.Snipers; i++)
            {
                //yield return new WaitForSeconds(0.1f);
                //playerGenZoneController.AddSniper();
                //energyController.SubtractEnergy();

            }
        }
        if (buildPerTick.TaskMasters > 0)
        {
            for (int i = 0; i < buildPerTick.TaskMasters; i++)
            {
                //yield return new WaitForSeconds(0.1f);
                //playerGenZoneController.AddTaskMaster();
                //energyController.SubtractEnergy();
            }
        }
        if (buildPerTick.Attackers > 0)
        {
            for (int i = 0; i < buildPerTick.Attackers; i++)
            {
                playerGenZoneController.AddAttacker();
                yield return new WaitForSeconds(1);

            }
        }
        if (buildPerTick.Workers > 0)
        {
            for (int i = 0; i < buildPerTick.Workers; i++)
            {
                playerGenZoneController.AddWorker();
                yield return new WaitForSeconds(1);
            }
        }
    }

    void OnMouseDown()
    {
        var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        xOfClick = pos.x;
        yOfClick = pos.y;
        xDiff = (xOfClick - xCenter);
        yDiff = (yOfClick - yCenter);
        Debug.Log("clicks x:" + xOfClick + ", y:" + yOfClick + " |centers x: " + xCenter + ", y: " + yCenter + "| diff x:" + xDiff + "| diff y:" + yDiff);


        var spendingPin = GameObject.FindWithTag("SpendingPin");
        spendingPin.transform.position = new Vector2(xOfClick, yOfClick);

        // Build Attackers
        if ((xDiff > 0 && xDiff < 1) &&
            (yDiff > 0 && yDiff < 1))
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 2,
                Workers = 1,
                Snipers = 0,
                TaskMasters = 0
            };
        }

        if (((xDiff > 0 && xDiff < 1) &&
            (yDiff > 1 && yDiff < 2)) ||
            ((yDiff > 0 && yDiff < 1) &&
            (xDiff > 1 && xDiff < 2)))
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 2,
                Workers = 0,
                Snipers = 0,
                TaskMasters = 0
            };
        }

        if ((xDiff > 1 && xDiff < 2) &&
            (yDiff > 1 && yDiff < 2))
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 4,
                Workers = 0,
                Snipers = 0,
                TaskMasters = 0
            };
        }

        // Builder Workers
        if ((xDiff < 0 && xDiff > -1) &&
            (yDiff < 0 && yDiff > -1))
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 1,
                Workers = 2,
                Snipers = 0,
                TaskMasters = 0
            };
        }

        if (((xDiff < 0 && xDiff > -1) &&
            (yDiff < -1 && yDiff > -2)) ||
            ((yDiff < 0 && yDiff > -1) &&
            (xDiff < -1 && xDiff > -2)))
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 0,
                Workers = 2,
                Snipers = 0,
                TaskMasters = 0
            };
        }

        if ((xDiff < -1 && xDiff > -2) &&
            (yDiff < -1 && yDiff > -2))
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 0,
                Workers = 4,
                Snipers = 0,
                TaskMasters = 0
            };
        }

        currentCommandText.text = BuildPerTick.CurrentCommand();

    }

}
