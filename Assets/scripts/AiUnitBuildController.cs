using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiUnitBuildController : MonoBehaviour {

    private BuildPerTick buildPerTick;
    float secondsElapsed = 0;
    bool doneWithInitalZeroCheck = false;
    SpriteRenderer sprite;
    List<int> randomTimedAttacks;

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
        randomTimedAttacks = new List<int>
        {
            Random.Range(0, 3),
            Random.Range(7, 10),
            Random.Range(15, 20),
            Random.Range(25, 30),
            Random.Range(35, 60),
            Random.Range(65, 90),
            Random.Range(95, 180),
        };
        BuildPerTick = new BuildPerTick()
        {
            Attackers = 0,
            Workers = 0,
            Snipers = 0,
            TaskMasters = 0
        };
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine("DoChecks");
        StartCoroutine("IncrementTime");
    }

    private void Update()
    {
        //
    }

    IEnumerator IncrementTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsElapsed += 1;
            //sprite.color = sprite.color == Color.magenta ? Color.red: Color.magenta;
            //sprite.flipX = !sprite.flipX;
        }

    }

    IEnumerator DoChecks()
    {
        while (true)
        {
            Debug.Log("randomTimedAttacks:" + randomTimedAttacks);
            if (!doneWithInitalZeroCheck && randomTimedAttacks[0] != 0)
            {
                SetToAttackMode(false);
                doneWithInitalZeroCheck = true;
            }

            if (secondsElapsed == randomTimedAttacks[0])
            {
                SetToAttackMode(true);
            }
            if (secondsElapsed == randomTimedAttacks[1])
            {
                SetToAttackMode(false);
            }
            if (secondsElapsed == randomTimedAttacks[2])
            {
                SetToAttackMode(true);
            }
            if (secondsElapsed == randomTimedAttacks[3])
            {
                SetToAttackMode(false);
            }
            if (secondsElapsed == randomTimedAttacks[4])
            {
                SetToAttackMode(true);
            }
            if (secondsElapsed == randomTimedAttacks[5])
            {
                SetToAttackMode(false);
            }
            if (secondsElapsed == randomTimedAttacks[6])
            {
                SetToAttackMode(true);
            }

            StartCoroutine("AddUnits", BuildPerTick);
            yield return new WaitForSeconds(.25f);
        }
    }

    void SetToAttackMode(bool isInAttackMode)
    {
        if (isInAttackMode)
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 2,
                Workers = 0,
                Snipers = 0,
                TaskMasters = 0
            };
            sprite.color = Color.red;
            sprite.flipX = false;
        }
        else
        // full focus on workers
        {
            BuildPerTick = new BuildPerTick()
            {
                Attackers = 0,
                Workers = 4,
                Snipers = 0,
                TaskMasters = 0
            };
            sprite.color = Color.magenta;
            sprite.flipX = true;
        }


    }

    IEnumerator AddUnits(BuildPerTick buildPerTick)
    {
        var aiGenZoneController = GameObject.FindWithTag("AiGenZone").GetComponent<AiGenZoneController>();

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
                aiGenZoneController.AddAiAttacker();
                yield return new WaitForSeconds(1);

            }
        }
        if (buildPerTick.Workers > 0)
        {
            for (int i = 0; i < buildPerTick.Workers; i++)
            {
                aiGenZoneController.AddAiWorker();
                yield return new WaitForSeconds(1);
            }
        }
        var currentCommandText = GameObject.FindWithTag("AiCommandText").GetComponent<Text>(); ;
        currentCommandText.text = BuildPerTick.AiCommand();
    }

    //void OnMouseDown()
    //{
    //    var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>(); ;
    //    var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    xOfClick = pos.x;
    //    yOfClick = pos.y;
    //    xDiff = (xOfClick - xCenter);
    //    yDiff = (yOfClick - yCenter);
    //    Debug.Log("clicks x:" + xOfClick + ", y:" + yOfClick + " |centers x: " + xCenter + ", y: " + yCenter + "| diff x:" + xDiff + "| diff y:" + yDiff);


    //    var spendingPin = GameObject.FindWithTag("SpendingPin");
    //    spendingPin.transform.position = new Vector2(xOfClick, yOfClick);

    //    // Build Attackers
    //    if ((xDiff > 0 && xDiff < 1) &&
    //        (yDiff > 0 && yDiff < 1))
    //    {
    //        BuildPerTick = new BuildPerTick()
    //        {
    //            Attackers = 2,
    //            Workers = 1,
    //            Snipers = 0,
    //            TaskMasters = 0
    //        };
    //    }

    //    if (((xDiff > 0 && xDiff < 1) &&
    //        (yDiff > 1 && yDiff < 2)) ||
    //        ((yDiff > 0 && yDiff < 1) &&
    //        (xDiff > 1 && xDiff < 2)))
    //    {
    //        BuildPerTick = new BuildPerTick()
    //        {
    //            Attackers = 2,
    //            Workers = 0,
    //            Snipers = 0,
    //            TaskMasters = 0
    //        };
    //    }

    //    if ((xDiff > 1 && xDiff < 2) &&
    //        (yDiff > 1 && yDiff < 2))
    //    {
    //        BuildPerTick = new BuildPerTick()
    //        {
    //            Attackers = 4,
    //            Workers = 0,
    //            Snipers = 0,
    //            TaskMasters = 0
    //        };
    //    }

    //    // Builder Workers
    //    if ((xDiff < 0 && xDiff > -1) &&
    //        (yDiff < 0 && yDiff > -1))
    //    {
    //        BuildPerTick = new BuildPerTick()
    //        {
    //            Attackers = 1,
    //            Workers = 2,
    //            Snipers = 0,
    //            TaskMasters = 0
    //        };
    //    }

    //    if (((xDiff < 0 && xDiff > -1) &&
    //        (yDiff < -1 && yDiff > -2)) ||
    //        ((yDiff < 0 && yDiff > -1) &&
    //        (xDiff < -1 && xDiff > -2)))
    //    {
    //        BuildPerTick = new BuildPerTick()
    //        {
    //            Attackers = 0,
    //            Workers = 2,
    //            Snipers = 0,
    //            TaskMasters = 0
    //        };
    //    }

    //    if ((xDiff < -1 && xDiff > -2) &&
    //        (yDiff < -1 && yDiff > -2))
    //    {
    //        BuildPerTick = new BuildPerTick()
    //        {
    //            Attackers = 0,
    //            Workers = 4,
    //            Snipers = 0,
    //            TaskMasters = 0
    //        };
    //    }

    //    currentCommandText.text = BuildPerTick.CurrentCommand();

    //}
}
