using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenZoneController : MonoBehaviour
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

    }

    public void AddWorker()
    {
        var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x,
            transform.position.y), transform.rotation) as GameObject;
        var blip = workerClone.GetComponent<Blip>();
        blip.Init(true, false);
        workerClone.GetComponent<SpriteRenderer>().material.color = blip.color; 
        workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed * 0.5f);
    }

    public void AddAttacker()
    {
        var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x,
            transform.position.y), transform.rotation) as GameObject;
        var blip = workerClone.GetComponent<Blip>();
        blip.Init(false, false);
        workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
        workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed * 0.5f);
    }
}
