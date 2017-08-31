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
        {ResourceType.food, "Еда"},
        {ResourceType.gold, "Золото"},
        {ResourceType.horn, "Рог"},
        {ResourceType.horn_sword, "Меч из рогов"},
        {ResourceType.horn_wand, "Жезл из рогов"},
        {ResourceType.infinity_horn_sword, "Жезл из рогов бесконечности"},
        {ResourceType.leprechaun_feed, "Еда для лепрекона"},
        {ResourceType.magic_fire, "Магический огонь"},
        {ResourceType.magic_wand, "Магический жезл"},
        {ResourceType.meat, "Мясо"},
        {ResourceType.meat_grill, "Жареное мясо"},
        {ResourceType.sulfur, "Сульфур"}
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
            resources[type] = 1000;
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