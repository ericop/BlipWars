using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenZoneController : MonoBehaviour
{
    public GameObject blipShell;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
            if (energyController.playerEnergy >= 25)
            {
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(true, false);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 1, speed * 0.5f);
            }
        }

        if (Input.GetKey(KeyCode.Z))
        {
            var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
            if (energyController.playerEnergy >= 25)
            {
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(false, false);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 1, speed * 0.5f);
            }
        }

    }

    public void AddWorker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.playerEnergy >= 25)
        {
            var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(true, false);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed * 0.5f);
        }
    }

    public void AddAttacker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.playerEnergy >= 25)
        {
            var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(false, false);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed * 0.5f);
        }
    }
}
