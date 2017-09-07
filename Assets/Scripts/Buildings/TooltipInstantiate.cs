using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TooltipInstantiate : MonoBehaviour
{
    private Ray curPos;
    public GameObject tooltipPrefab;
    private GameObject tooltipPrefabCreated;
    private Vector3 tooltipPosition;
    private GameObject recipe;
    private Text tooltipText;


    private void OnMouseEnter()
    {
        tooltipPrefabCreated = Instantiate(tooltipPrefab, tooltipPosition, Quaternion.identity);
        GetText();
    }

    private void OnMouseOver()
    {
        tooltipPrefabCreated.transform.position = tooltipPosition;
    }

    private void OnMouseExit()
    {
        Destroy(tooltipPrefabCreated);
    }

    private void Update()
    {
        curPos = Camera.main.ScreenPointToRay(Input.mousePosition);
        tooltipPosition = new Vector3(curPos.origin.x + 0.5f, curPos.origin.y + 0.4f);
    }

    private void GetText()
    {
        recipe = transform.parent.transform.parent.gameObject;
        tooltipText = GameObject.Find("TooltipText(Clone)/Text").GetComponent<Text>();
        tooltipText.text = "";
        var buttonName = gameObject.name;
        Recipe _recipe = null;
        switch (buttonName)
        {
            case "LeprechaunFeedButton":
                _recipe = recipe.GetComponent<GrillHouse>().leprechaunFeedRecipe;
                break;
            case "MeatGrillButton":
                _recipe = recipe.GetComponent<GrillHouse>().meatGrillRecipe;
                break;
            case "MagicFireButton":
                _recipe = recipe.GetComponent<LeprechaunYard>().magicFireRecipe;
                break;
            case "HornButton":
                _recipe = recipe.GetComponent<DemonYard>().hornRecipe;
                break;
            case "HornSwordButton":
                _recipe = recipe.GetComponent<Factory>().hornSwordRecipe;
                break;
            case "HornWandButton":
                _recipe = recipe.GetComponent<Factory>().hornWandRecipe;
                break;
            case "InfinityHornSwordButton":
                _recipe = recipe.GetComponent<MagicHouse>().infinityHornSwordRecipe;
                break;
            case "MagicWandButton":
                _recipe = recipe.GetComponent<MagicHouse>().magicWandRecipe;
                break;
        }

        if (_recipe == null) return;
        foreach (var keyValuePair in _recipe.resources)
        {
            var resourceName = Resources.names[keyValuePair.Key];
            var resourceCount = keyValuePair.Value;
            var resourcesInBank = Resources.resources[keyValuePair.Key];
            tooltipText.text += resourceName + " : " + resourceCount + "/" + resourcesInBank + "\n";
        }
    }
}