using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiGenZoneController : MonoBehaviour
{

    public GameObject blipShell;
    public float speed;
    public bool IsTwoPlayerMode;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();

        if (IsTwoPlayerMode)
        {
            var attackerButton = GameObject.FindWithTag("AiAddAttackerButton").GetComponent<Button>();
            attackerButton.interactable = energyController.aiEnergy >= 100;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (energyController.aiEnergy >= 25)
            {
                energyController.SubtractAiEnergy();
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(true, true);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -.5f);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (energyController.aiEnergy >= 100)
            {
                energyController.SubtractAiEnergy();
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(false, true);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -.5f);
            }
        }
    }

    public void AddAiWorker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.aiEnergy >= 25)
        {
            energyController.SubtractAiEnergy();
            var workerClone = Instantiate(blipShell,
                new Vector2(transform.position.x,
                transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(true, true);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -.5f);
        }
    }

    public void AddAiAttacker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.aiEnergy >= 100)
        {
            energyController.SubtractAiEnergy();
            var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x,
            transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(false, true);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -.5f);
        }
    }
}