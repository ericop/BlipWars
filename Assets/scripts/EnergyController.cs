using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public int playerEnergy;
    public int aiEnergy;
    public int energyPerReturn;
    public int energyPerBuy;
    void Start()
    {

    }

    void Update()
    {sni
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
        energyText.text = "Energy: " + playerEnergy;
    }

    public void UpdateAiEnergyAmountText()
    {
        var energyText = GameObject.FindWithTag("AiEnergyAmountText").GetComponent<Text>();
        energyText.text = "Bad Guy Energy: " + aiEnergy;
    }
}
