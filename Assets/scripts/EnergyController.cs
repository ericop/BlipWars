using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyController : MonoBehaviour
{
    public GameObject blipShell;
    public int speed;
    public int playerEnergy;
    public int aiEnergy;
    public int energyPerReturn;
    public int energyPerBuy;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void SubtractEnergy()
    {
        playerEnergy -= energyPerBuy;
        UpdateEnergyAmountText();
    }

    public void SubtractAiEnergy()
    {
        aiEnergy -= energyPerBuy;
        UpdateAiEnergyAmountText();
    }



    public void AddEnergy ()
    {
        playerEnergy += energyPerReturn;
        UpdateEnergyAmountText();
    }

    public void AddAiEnergy()
    {
        aiEnergy += energyPerReturn;
        UpdateAiEnergyAmountText();
    }

    public void UpdateEnergyAmountText()
    {
        var energyText = GameObject.FindWithTag("EnergyAmountText").GetComponent<Text>();
        energyText.text = "Good Guy Energy: " + playerEnergy;
    }

    public void UpdateAiEnergyAmountText()
    {
        var energyText = GameObject.FindWithTag("AiEnergyAmountText").GetComponent<Text>();
        energyText.text = "Bad Guy Energy: " + aiEnergy;
    }

    public void PlayerWins()
    {
        var blipArray = GameObject.FindGameObjectsWithTag("BlipTranspThreePointedStarPrefab");
        var energyText = GameObject.FindWithTag("EnergyAmountText").GetComponent<Text>();
        energyText.text = "Good Guy Has Won!";
        var aiEnergyText = GameObject.FindWithTag("AiEnergyAmountText").GetComponent<Text>();
        aiEnergyText.text = "Bad Guy Has Lost :(";
        StartCoroutine("ReturnToMenuAfterWin");
        foreach (var blip in blipArray)
        {
            Destroy(blip);
        }
        energyText.text = "Good Guy Has Won!";
        aiEnergyText.text = "Bad Guy Has Lost :(";
    }

    public void AiWins()
    {
        var blipArray = GameObject.FindGameObjectsWithTag("BlipTranspThreePointedStarPrefab");
        var energyText = GameObject.FindWithTag("EnergyAmountText").GetComponent<Text>();
        energyText.text = "Good Guy Has Lost :(";
        var aiEnergyText = GameObject.FindWithTag("AiEnergyAmountText").GetComponent<Text>();
        aiEnergyText.text = "Bad Guy Has Won!";
        StartCoroutine("ReturnToMenuAfterWin");
        foreach (var blip in blipArray)
        {
            Destroy(blip);
        }
        energyText.text = "Good Guy Has Lost :(";
        aiEnergyText.text = "Bad Guy Has Won!";
    }

    IEnumerator ReturnToMenuAfterWin()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("menu");
    }

}
