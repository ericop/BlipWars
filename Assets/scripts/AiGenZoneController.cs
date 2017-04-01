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

    }

    public void AddAiWorker()
    {
        var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x,
            transform.position.y), transform.rotation) as GameObject;
        var blip = workerClone.GetComponent<Blip>();
        blip.Init(true, true);
        workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
        workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -0.5f);
    }

    public void AddAiAttacker()
    {
        var workerClone = Instantiate(blipShell,
            new Vector2(transform.position.x,
            transform.position.y), transform.rotation) as GameObject;
        var blip = workerClone.GetComponent<Blip>();
        blip.Init(false, false);
        workerClone.GetComponent<SpriteRenderer>().material.color = blip.color;
        workerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, speed * -0.5f);
    }
}
