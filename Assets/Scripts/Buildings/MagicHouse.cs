using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicHouse: MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public Text infinityHornSwordButtonText;
    public GameObject infinityHornSwordButton;
    private Recipe infinityHornSwordRecipe;

    public Text magicWandButtonText;
    public GameObject magicWandButton;
    private Recipe magicWandRecipe;


    private void Start()
    {
        InitList();
    }

    private void Update()
    {
        infinityHornSwordRecipe.CheckStage();
    }

    private void InitList()
    {
        infinityHornSwordRecipe = new Recipe(
            Resources.ResourceType.infinity_horn_sword,
            time: 180,
            productionCount: 1,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.horn_sword, 1},
                {Resources.ResourceType.magic_fire, 2}
            },
            buttonText: infinityHornSwordButtonText,
            button: infinityHornSwordButton
        );
        magicWandRecipe = new Recipe(
            Resources.ResourceType.magic_wand,
            time: 600,
            productionCount: 1,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.horn_wand, 1},
                {Resources.ResourceType.magic_fire, 10}
            },
            buttonText: magicWandButtonText,
            button: magicWandButton
        );
    }


    public void InfinityHornSwordPressButton()
    {
        if (magicWandRecipe.currentStage == Recipe.Stage.Idle ||
            magicWandRecipe.currentStage == Recipe.Stage.NotEnoughResources)
        {
            StartCoroutine(infinityHornSwordRecipe.PressButton());
        }
    }

    public void MagicWandPressButton()
    {
        if (infinityHornSwordRecipe.currentStage == Recipe.Stage.Idle ||
            infinityHornSwordRecipe.currentStage == Recipe.Stage.NotEnoughResources)
        {
            StartCoroutine(magicWandRecipe.PressButton());
        }
    }
}