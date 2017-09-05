using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public static string resourcesText;
    public static Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    public static Dictionary<ResourceType, string> names = new Dictionary<ResourceType, string>
    {
        {ResourceType.food, "Food"},
        {ResourceType.gold, "Gold"},
        {ResourceType.horn, "Horn"},
        {ResourceType.horn_sword, "Horn sword"},
        {ResourceType.horn_wand, "Horn wand"},
        {ResourceType.infinity_horn_sword, "Infinity horn sword"},
        {ResourceType.leprechaun_feed, "Leprechaun feed"},
        {ResourceType.magic_fire, "Magic fire"},
        {ResourceType.magic_wand, "Magic wand"},
        {ResourceType.meat, "Meat"},
        {ResourceType.meat_grill, "Meat grill"},
        {ResourceType.sulfur, "Sulfur"}
    };


    public enum ResourceType
    {
        gold,
        food,
        meat,
        sulfur,
        horn,
        leprechaun_feed,
        meat_grill,
        magic_fire,
        horn_sword,
        horn_wand,
        infinity_horn_sword,
        magic_wand
    }

    public static string GetName(ResourceType type)
    {
        return names[type];
    }

    private void Start()
    {
        InitResourcesDictionary();
        UpdateText();
    }

    public static void AddResource(int amount, ResourceType resourceType)
    {
        resources[resourceType] += amount;
        UpdateText();
    }

    public static void UpdateText()
    {
        UpdateResources();
        GameObject.Find("UI/ResourcesText").GetComponent<Text>().text = resourcesText;
    }


    public static void InitResourcesDictionary()
    {
        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
        {
            resources[type] = 10;
        }
        UpdateResources();
    }

    private static void UpdateResources()
    {
        resourcesText = "";
        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
        {
            resourcesText += names[type] + " :" + resources[type] + "\n";
        }
    }
}