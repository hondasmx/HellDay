using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeprechaunYard : MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public Text magicFireButtonText;
    public GameObject magicFireButton;
    private Recipe magicFireRecipe;

    private void Start()
    {
        InitList();
    }

    private void Update()
    {
        magicFireRecipe.CheckStage();
    }

    private void InitList()
    {
        magicFireRecipe = new Recipe(
            Resources.ResourceType.magic_fire,
            time: 3,
            productionCount: 3,
            resources: new Dictionary<Resources.ResourceType, int>
            {
                {Resources.ResourceType.leprechaun_feed, 3}
            },
            buttonText: magicFireButtonText,
            button: magicFireButton
        );
    }


    public void LeprechaunYardPressButton()
    {
        StartCoroutine(magicFireRecipe.PressButton());
    }
}