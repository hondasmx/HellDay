using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public static string resourcesText;
    public static Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    //Название ресурсов как они будут отображаться в интерфейсе
    private static readonly Dictionary<ResourceType, string> names = new Dictionary<ResourceType, string>
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
    
    //Стоимость продажи ресурсов на рынке
    private static readonly Dictionary<ResourceType, int> sellValues = new Dictionary<ResourceType, int>
    {
        {ResourceType.food, 2},
        {ResourceType.gold, 1},
        {ResourceType.horn, 3},
        {ResourceType.horn_sword, 4},
        {ResourceType.horn_wand, 5},
        {ResourceType.infinity_horn_sword, 6},
        {ResourceType.leprechaun_feed, 7},
        {ResourceType.magic_fire, 8},
        {ResourceType.magic_wand, 9},
        {ResourceType.meat, 10},
        {ResourceType.meat_grill, 11},
        {ResourceType.sulfur, 12}
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

    public static int GetResourceAmount(ResourceType type)
    {
        return resources[type];
    }

    public static int GetSellValue(ResourceType type)
    {
        return sellValues[type];
    }

    private void Awake()
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