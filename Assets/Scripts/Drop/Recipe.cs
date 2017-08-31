using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Recipe
{
    private string displayed_name;
    private int price;
    public Resources.ResourceType resourceType;
    public int productionCount;
    public int time;
    public Text buttonText;
    public Dictionary<Resources.ResourceType, int> resources = new Dictionary<Resources.ResourceType, int>();


    public enum JobStage
    {
        NotEnoughResources,
        ReadyForWork,
        Working,
        Done
    }

    public Recipe(int price, Resources.ResourceType resourceType,
        int productionCount, int time,
        Dictionary<Resources.ResourceType, int> resources, Text buttonText)
    {
        this.price = price;
        this.resourceType = resourceType;
        this.productionCount = productionCount;
        this.time = time;
        this.resources = resources;
        this.buttonText = buttonText;
        this.buttonText.text = Resources.names[resourceType];
    }

    public void PressButton()
    {
        if (!isEnoughResources(resources)) return;
        foreach (var pair in resources)
        {
            var type = pair.Key;
            Resources.AddResource(-pair.Value, type);
        }
        Resources.AddResource(productionCount, resourceType);
        Resources.AddResource(-price, Resources.ResourceType.gold);
    }

    public bool isEnoughResources(Dictionary<Resources.ResourceType, int> _resources)
    {
        var notEnoughResourcesDictionary = _resources.Count(pair =>
            Resources.resources[pair.Key] < pair.Value || Resources.resources[Resources.ResourceType.gold] < price);
        return notEnoughResourcesDictionary == 0;
    }
}