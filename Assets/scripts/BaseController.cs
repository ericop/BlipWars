using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    public int hp;
    public bool ownerIsAi;
    private float orginalScaleFactor;

    // Use this for initialization
    void Start()
    {
        orginalScaleFactor = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 0:
                var energyController = GameObject.FindWithTag("EnergyAmountText").GetComponent<EnergyController>();
                StartCoroutine("ExplodeBase");
                if (ownerIsAi)
                {
                    energyController.PlayerWins();
                }
                else
                {
                    energyController.AiWins();
                }
                break;
            case 1:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.1f;
                break;
            case 2:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.2f;
                break;
            case 3:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.3f;
                break;
            case 4:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.4f;
                break;
            case 5:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.5f;
                break;
            case 6:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.6f;
                break;
            case 7:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.7f;
                break;
            case 8:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.8f;
                break;
            case 9:
                transform.localScale = Vector2.one * orginalScaleFactor * 0.9f;
                break;
            case 10:
                transform.localScale = Vector2.one * orginalScaleFactor;
                break;
        }
    }

    IEnumerator ExplodeBase()
    {
        yield return new WaitForSeconds(0.15f);
        transform.localScale = Vector2.one * orginalScaleFactor * 0.9f;
        yield return new WaitForSeconds(0.15f);
        transform.localScale = Vector2.one * orginalScaleFactor * 0.4f;
        yield return new WaitForSeconds(0.15f);
        transform.localScale = Vector2.one * orginalScaleFactor * 1.5f;
        yield return new WaitForSeconds(0.15f);
        transform.localScale = Vector2.one * orginalScaleFactor * 2.4f;
        Destroy(this);
    }
}
