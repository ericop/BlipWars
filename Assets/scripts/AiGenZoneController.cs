using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiGenZoneController : MonoBehaviour
{

    public GameObject blipShell;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
            if (energyController.aiEnergy >= 25)
            {
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(true, true);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -0.5f);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
            if (energyController.aiEnergy >= 25)
            {
                var workerClone = Instantiate(blipShell,
                    new Vector2(transform.position.x,
                    transform.position.y), transform.rotation) as GameObject;
                var blip = workerClone.GetComponent<Blip>();
                blip.Init(false, true);
                workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
                workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -0.5f);
            }
        }
    }

    public void AddAiWorker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.aiEnergy >= 25)
        {
            var workerClone = Instantiate(blipShell,
                new Vector2(transform.position.x,
                transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(true, true);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -0.5f);
        }
    }

    public void AddAiAttacker()
    {
        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (energyController.aiEnergy >= 25)
        {
            var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x,
            transform.position.y), transform.rotation) as GameObject;
            var blip = workerClone.GetComponent<Blip>();
            blip.Init(false, true);
            workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
            workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -0.5f);
        }
    }
}