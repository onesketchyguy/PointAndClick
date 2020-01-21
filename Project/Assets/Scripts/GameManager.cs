using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal ClickedObjectDisplayManager clickedObjectDisplay;
    internal HelpText helpText;
    internal CutSceneManager cutSceneManager;

    public InventoryDisplay playerInventory;
    public InventoryDisplay otherInventory;

    [Space]
    public World.CombinationLock.CombinationChecker combinationLock;

    public static bool inMenu;

    private void Awake()
    {
        instance = this;

        clickedObjectDisplay = FindObjectOfType<ClickedObjectDisplayManager>();
        helpText = FindObjectOfType<HelpText>();
        cutSceneManager = FindObjectOfType<CutSceneManager>();

        otherInventory.Take = true;
        playerInventory.Take = false;
    }

    private void Update()
    {
        if (inMenu)
        {
            helpText.SetText("");
        }
    }
}