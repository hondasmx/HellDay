using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrillHouse : MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public Text leprechaunFeedButtonText, meatGrillButtonText;
    public GameObject leprechaunFeedButton, meatGrillButton;
    private Recipe leprechaunFeedRecipe;
    private Recipe meatGrillRecipe;
    private Recipe buildingState;

    private void Start()
    {
        InitList();
    }

    private void Update()
    {
        leprechaunFeedRecipe.CheckStage();
        meatGrillRecipe.CheckStage();
    }

    private void InitList()
    {
        leprechaunFeedRecipe = new Recipe(
            Resources.ResourceType.leprechaun_feed,
            time: 3,
            productionCount: 3,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.meat, 6}
            },
            buttonText: leprechaunFeedButtonText,
            button: leprechaunFeedButton
        );

        meatGrillRecipe = new Recipe(
            Resources.ResourceType.meat_grill,
            time: 5,
            productionCount: 3,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.meat, 3},
                {Resources.ResourceType.sulfur, 2}
            },
            buttonText: meatGrillButtonText,
            button: meatGrillButton
        );
    }

    public void PickUp(string itemName)
    {
        StartCoroutine(PickupText.ShowMessage(itemName));
    }

    public void LeprechaunMeatPressButton()
    {
        if (meatGrillRecipe.currentStage == Recipe.Stage.Idle ||
            meatGrillRecipe.currentStage == Recipe.Stage.NotEnoughResources)
        {
            StartCoroutine(leprechaunFeedRecipe.PressButton());
        }
    }


    public void MeatGrillPressButton()
    {
        if (leprechaunFeedRecipe.currentStage == Recipe.Stage.Idle ||
            leprechaunFeedRecipe.currentStage == Recipe.Stage.NotEnoughResources)
        {
            StartCoroutine(meatGrillRecipe.PressButton());
        }
    }
}