using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrillHouseRecipes : MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public Text leprechaunFeedButton, meatGrillButton;

    private Recipe leprechaunFeedRecipe;
    private Recipe meatGrillRecipe;

    private void Start()
    {
        InitList();
    }


    private void InitList()
    {
        leprechaunFeedRecipe = new Recipe(
            price: 100,
            resourceType: Resources.ResourceType.leprechaun_feed,
            time: 60,
            productionCount: 3,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.meat, 6}
            },
            buttonText: leprechaunFeedButton
        );

        meatGrillRecipe = new Recipe(
            price: 120,
            resourceType: Resources.ResourceType.meat_grill,
            time: 30,
            productionCount: 3,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.meat, 3},
                {Resources.ResourceType.sulfur, 2}
            },
            buttonText: meatGrillButton
        );
    }

    public void PickUp(string itemName)
    {
        StartCoroutine(PickupText.ShowMessage(itemName));
    }

    public void LeprechaunMeatPressButton()
    {
        leprechaunFeedRecipe.PressButton();
    }

    public void MeatGrillPressButton()
    {
        meatGrillRecipe.PressButton();
    }
}