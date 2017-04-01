using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blip : MonoBehaviour
{

    public bool ownerIsAi;
    public bool isWorker;
    public string blipType;
    public bool hasEnergy = false;
    public Color color;
    public int hp;
    public float speed;
    public bool firstTrip = true;

    public void Init(bool isWorker, bool ownerIsAi)
    {
        this.ownerIsAi = ownerIsAi;
        this.isWorker = isWorker;
        this.blipType = this.isWorker ? "worker" : "attacker";
        // http://answers.unity3d.com/questions/353015/how-to-instantiate-a-prefab-and-change-its-color.html
        //this.GetComponent<MeshRenderer>().material.color = 
        this.color = ownerIsAi ?
            (isWorker ? Color.magenta : Color.red) :
            (isWorker ? Color.green : Color.blue);
        this.hp = this.isWorker ? 1 : 2;
        this.speed = 1;

        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        if (ownerIsAi)
        {
            energyController.SubtractAiEnergy();
        } else
        {
            energyController.SubtractEnergy();
        }

        //Debug.LogWarning("ownerIsAi=" + this.ownerIsAi + ", this.isWorker=" + this.isWorker + this.ToString());
        //return this;
    }
    void Start()
    {
        //ignore colision with team mate blips
        //Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), opponentFrog.GetComponent<Collider2D>());
    }

    void Update()
    {
        if (this.hasEnergy)
        {
            transform.localScale = Vector2.one * 1.25f;
        }
        else
        {
            transform.localScale = Vector2.one / 1.25f;
        }
    }

    private void OnCollisionEnter2D(Collider2D col)
    {
        Debug.LogWarning("2d col" + col.ToString() + col.GetComponent<Blip>().ToString());
        if (col.GetComponent<Blip>() != null &&
            col.GetComponent<Blip>().ownerIsAi == this.ownerIsAi)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
            return;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
        // if (blip.type == "Worker")
        if (this.isWorker && col.gameObject.tag == "EnergyWell")
        {
            this.hasEnergy = true;
            this.firstTrip = false;
            GetComponent<Rigidbody2D>()
                .velocity = new Vector2(
                GetComponent<Rigidbody2D>()
                    .velocity.x * -1,
                GetComponent<Rigidbody2D>()
                    .velocity.y * -1);
        }

        if (!firstTrip && col.gameObject.tag == "PlayerBase")
        {
            this.hasEnergy = false;
            energyController.AddEnergy();
            GetComponent<Rigidbody2D>()
                .velocity = new Vector2(
            GetComponent<Rigidbody2D>()
                .velocity.x * -1,
            GetComponent<Rigidbody2D>()
                .velocity.y * -1);
        }

        if (!firstTrip && col.gameObject.tag == "AiBase")
        {
            this.hasEnergy = false;
            energyController.AddAiEnergy();
            GetComponent<Rigidbody2D>()
                .velocity = new Vector2(
            GetComponent<Rigidbody2D>()
                .velocity.x * -1,
            GetComponent<Rigidbody2D>()
                .velocity.y * -1);
        }
    }
}
