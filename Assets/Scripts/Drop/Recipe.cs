using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Recipe
{
    private string displayed_name;
    public Resources.ResourceType resourceType;
    public int productionCount;
    public int time;
    public Text buttonText;
    public GameObject button;
    public Dictionary<Resources.ResourceType, int> resources;
    public Stage currentStage;


    public Recipe(Resources.ResourceType resourceType,
        int productionCount, int time,
        Dictionary<Resources.ResourceType, int> resources, Text buttonText, GameObject button)
    {
        this.resourceType = resourceType;
        this.productionCount = productionCount;
        this.time = time;
        this.button = button;
        this.resources = resources;
        this.buttonText = buttonText;
        this.buttonText.text = Resources.names[resourceType];
        currentStage = Stage.Idle;
    }

    public enum Stage
    {
        Idle,
        Working,
        Done,
        NotEnoughResources
    }

    public IEnumerator PressButton()
    {
        switch (currentStage)
        {
            case Stage.Idle:
                currentStage = Stage.Working;
                //отнимаем ресурсы на производство
                foreach (var pair in resources)
                {
                    var type = pair.Key;
                    Resources.AddResource(-pair.Value, type);
                }

                //запускаем прогрессбар
                var currentTimer = time;
                button.GetComponent<Button>().interactable = false;
                while (button.GetComponent<Image>().fillAmount < 1.0f)
                {
                    buttonText.text = currentTimer.ToString();
                    button.GetComponent<Image>().fillAmount += 100 / (float) time / 100;
                    yield return new WaitForSeconds(1);
                    currentTimer--;
                }

                currentStage = Stage.Done;
                break;
            case Stage.Done:
                //добавляем приготовенные ресурсы

                Resources.AddResource(productionCount, resourceType);
                currentStage = Stage.Idle;
                break;
        }
    }

    public bool isEnoughResources(Dictionary<Resources.ResourceType, int> _resources)
    {
        var notEnoughResourcesDictionary = _resources.Count(pair =>
            Resources.resources[pair.Key] < pair.Value);
        return notEnoughResourcesDictionary == 0;
    }

    public void CheckStage()
    {
        switch (currentStage)
        {
            case Stage.Idle:
                buttonText.text = Resources.names[resourceType];
                if (isEnoughResources(resources))
                {
                    button.GetComponent<Button>().interactable = true;
                    button.GetComponent<Image>().color = Color.green;
                    button.GetComponent<Image>().fillAmount = 0;
                }
                else
                {
                    currentStage = Stage.NotEnoughResources;
                }
                break;
            case Stage.Working:
                button.GetComponent<Button>().interactable = false;
                break;
            case Stage.Done:
                buttonText.text = "Ready!";
                button.GetComponent<Button>().interactable = true;
                break;
            case Stage.NotEnoughResources:
                buttonText.text = Resources.names[resourceType];
                if (!isEnoughResources(resources))
                {
                    button.GetComponent<Button>().interactable = false;
                    button.GetComponent<Image>().color = Color.red;
                    button.GetComponent<Image>().fillAmount = 1.0f;
                }
                else
                {
                    currentStage = Stage.Idle;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}