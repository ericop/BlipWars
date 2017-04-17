using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveEnergyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var xOfClick = pos.x;
        var yOfClick = pos.y;

        var spendingPin = GameObject.FindWithTag("SpendingPin");
        spendingPin.transform.position = new Vector2(xOfClick, yOfClick);

        var playerChoiceBox = GameObject.FindWithTag("PlayerChoiceBox").GetComponent<PlayerChoiceBoxController>();
        playerChoiceBox.BuildPerTick = new BuildPerTick()
        {
            Attackers = 0,
            Workers = 0,
            Snipers = 0,
            TaskMasters = 0
        };

        var currentCommandText = GameObject.FindWithTag("CurrentCommandText").GetComponent<Text>();
        currentCommandText.text = playerChoiceBox.BuildPerTick.CurrentCommand();
    }
}


