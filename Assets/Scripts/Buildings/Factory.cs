using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public Text hornSwordButtonText;
    public GameObject hornSwordButton;
    public Text hornWandButtonText;
    public GameObject hornWandButton;
    private Recipe hornSwordRecipe;
    private Recipe hornWandRecipe;

    private void Start()
    {
        InitList();
    }

    private void Update()
    {
        hornSwordRecipe.CheckStage();
    }

    private void InitList()
    {
        hornSwordRecipe = new Recipe(
            Resources.ResourceType.horn_sword,
            time: 180,
            productionCount: 1,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.horn, 6}
            },
            buttonText: hornSwordButtonText,
            button: hornSwordButton
        );
        hornWandRecipe = new Recipe(
            Resources.ResourceType.horn_wand,
            time: 90,
            productionCount: 1,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.horn, 3}
            },
            buttonText: hornWandButtonText,
            button: hornWandButton
        );
    }


    public void HornSwordPressButton()
    {
        if (hornWandRecipe.currentStage == Recipe.Stage.Idle ||
            hornWandRecipe.currentStage == Recipe.Stage.NotEnoughResources)
        {
            StartCoroutine(hornSwordRecipe.PressButton());
        }
    }

    public void HornWandPressButton()
    {
        if (hornSwordRecipe.currentStage == Recipe.Stage.Idle ||
            hornSwordRecipe.currentStage == Recipe.Stage.NotEnoughResources)
        {
            StartCoroutine(hornWandRecipe.PressButton());
        }
    }
}