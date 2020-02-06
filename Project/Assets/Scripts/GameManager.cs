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

    private Player.PlayerInventoryManager playerInventoryManager;

    [Space]
    public World.CombinationLock.CombinationChecker combinationLock;

    public static bool inMenu;

    private static string onLoadLevelMessage = string.Empty;

    [Space]
    public Canvas worldCanvas;

    public static string[] scenes;

    private void Awake()
    {
        instance = this;

        playerInventoryManager = FindObjectOfType<Player.PlayerInventoryManager>();

        clickedObjectDisplay = FindObjectOfType<ClickedObjectDisplayManager>();
        helpText = FindObjectOfType<HelpText>();
        cutSceneManager = FindObjectOfType<CutSceneManager>();

        otherInventory.Take = true;
        playerInventory.Take = false;
        playerInventory.Initialize(playerInventoryManager);

        if (onLoadLevelMessage != string.Empty)
        {
            Invoke(nameof(DisplayMessage), 2 * Time.deltaTime);
        }

        if (GetComponent<Canvas>() && worldCanvas == null)
            worldCanvas = GetComponent<Canvas>();

        if (scenes == null || scenes.Length <= 0)
        {
            scenes = new string[SceneManager.sceneCountInBuildSettings];

            for (int index = 0; index < SceneManager.sceneCountInBuildSettings; index++)
            {
                var path = SceneUtility.GetScenePathByBuildIndex(index);
                var sceneName = System.IO.Path.GetFileNameWithoutExtension(path);

                scenes[index] = sceneName;
            }
        }
    }

    private void Update()
    {
        if (inMenu)
        {
            helpText.SetText("");
        }

        if (worldCanvas != null)
        {
            worldCanvas.worldCamera = Camera.main;
        }
    }

    private void DisplayMessage()
    {
        cutSceneManager.DisplayMessage(onLoadLevelMessage);

        onLoadLevelMessage = string.Empty;
    }

    public void LoadScene(string sceneName)
    {
        bool success = false;

        for (int index = 0; index < scenes.Length; index++)
        {
            var name = scenes[index];

            if (name.ToLower().Contains(sceneName.ToLower()))
            {
                Loading.LoadingScreen.levelToLoad = index;

                Debug.Log($"Loading Scene: {name}");

                SceneManager.LoadScene("LoadingScreen");

                success = true;
                break;
            }
        }

        if (!success)
            Debug.LogError($"Could not load level: {sceneName}.");
    }

    public void LoadScene(int buildIndex)
    {
        Loading.LoadingScreen.levelToLoad = buildIndex;

        SceneManager.LoadScene("LoadingScreen");
    }

    public void AddLoadMessageToSceneChange(string message)
    {
        onLoadLevelMessage = message;
    }
}