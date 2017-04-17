using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGenZoneController : MonoBehaviour
{
    public GameObject blipShell;
    public float speed;
    public bool IsTwoPlayerMode;

    void Start()
    {

    }

    void Update()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();

        if (IsTwoPlayerMode)
        {
            var attackerButton = GameObject.FindWithTag("AddAttackerButton").GetComponent<Button>();
            attackerButton.interactable = energyController.playerEnergy >= 100;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (energyController.playerEnergy >= 25)
            {
                energyController.SubtractEnergy();
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(true, false);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 1, speed * .5f);
            }
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (energyController.playerEnergy >= 100)
            {
                energyController.SubtractEnergy();
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(false, false);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 1, speed * .5f);
            }
        }

    }

    public void AddWorker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.playerEnergy >= 25)
        {
            energyController.SubtractEnergy();
            var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(true, false);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 1, speed * .5f);
        }
    }

    public void AddAttacker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.playerEnergy >= 100)
        {
            energyController.SubtractEnergy();
            var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(false, false);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 1, speed * .5f);
        }
    }
}
