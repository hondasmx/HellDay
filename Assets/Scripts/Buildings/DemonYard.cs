using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonYard : MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public Text hornButtonText;
    public GameObject hornButton;
    public Recipe hornRecipe;

    private void Start()
    {
        InitList();
    }

    private void Update()
    {
        hornRecipe.CheckStage();
    }

    private void InitList()
    {
        hornRecipe = new Recipe(
            Resources.ResourceType.horn,
            time: 10,
            productionCount: 3,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.meat_grill, 3}
            },
            buttonText: hornButtonText,
            button: hornButton
        );

    }

    public void PickUp(string itemName)
    {
        StartCoroutine(PickupText.ShowMessage(itemName));
    }



    public void DemonYardPressButton()
    {
        StartCoroutine(hornRecipe.PressButton());
    }
}