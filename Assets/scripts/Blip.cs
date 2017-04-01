﻿using System.Collections;
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
        }
        else
        {
            energyController.SubtractEnergy();
        }

        //Debug.LogWarning("ownerIsAi=" + this.ownerIsAi + ", this.isWorker=" + this.isWorker + this.ToString());
        //return this;
    }
    void Start()
    {
        //ignore colision with team mate blips
        var blipArray = GameObject.FindGameObjectsWithTag("BlipTranspThreePointedStarPrefab");

        foreach (var otherBlip in blipArray)
        {
            if (otherBlip.gameObject.GetComponent<Blip>() != null &&
            otherBlip.gameObject.GetComponent<Blip>().ownerIsAi == this.ownerIsAi)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherBlip.GetComponent<Collider2D>());
            }
        }
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

        if (!this.isWorker)
        {
            if (this.hp == 1)
            {
                transform.localScale = Vector2.one * 0.5f;
            }
        }

        if (this.hp <= 0 )
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("in " + col.ToString());
        //if (col.gameObject.tag == "BlipTranspThreePointedStarPrefab")
        if (col.gameObject.GetComponent<Blip>() != null)
        {
            col.gameObject.GetComponent<Blip>().hp -= 1;
            Debug.Log("clone bump1 " + col.ToString());

            //if (col.gameObject.GetComponent<Blip>().hp <= 0)
            //{
            //    Destroy(col.gameObject);
            //}
        }

        if (col.gameObject.GetComponent<Blip>() != null &&
            col.gameObject.GetComponent<Blip>().ownerIsAi == this.ownerIsAi)
        {
            Debug.Log("same owner 2" + col.ToString() + col.gameObject.GetComponent<Blip>().ToString());
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "BlipTranspThreePointedStarPrefab" &&
            col.gameObject.GetComponent<Blip>().ownerIsAi == this.ownerIsAi)
        {
            Debug.Log("same owner 3" + col.ToString() + col.gameObject.GetComponent<Blip>().ToString());
            //Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
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
