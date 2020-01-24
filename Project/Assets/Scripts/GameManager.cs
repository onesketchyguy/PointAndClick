using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private static string onLoadLevelMessage = string.Empty;

    private void Awake()
    {
        instance = this;

        clickedObjectDisplay = FindObjectOfType<ClickedObjectDisplayManager>();
        helpText = FindObjectOfType<HelpText>();
        cutSceneManager = FindObjectOfType<CutSceneManager>();

        otherInventory.Take = true;
        playerInventory.Take = false;

        if (onLoadLevelMessage != string.Empty)
        {
            Invoke(nameof(DisplayMessage), 2 * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (inMenu)
        {
            helpText.SetText("");
        }

        if (playerInventory.inventoryToDisplay == null)
        {
            playerInventory.Initialize(FindObjectOfType<Player.PlayerInventoryManager>());
        }
    }

    private void DisplayMessage()
    {
        cutSceneManager.DisplayMessage(onLoadLevelMessage);

        onLoadLevelMessage = string.Empty;
    }

    public void LoadScene(string sceneName)
    {
        var scene = SceneManager.GetSceneByName(sceneName).buildIndex;

        Loading.LoadingScreen.levelToLoad = scene;

        SceneManager.LoadScene("LoadingScreen");
    }

    public void AddLoadMessageToSceneChange(string message)
    {
        onLoadLevelMessage = message;
    }
}