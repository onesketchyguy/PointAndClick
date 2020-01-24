using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class ClickedObjectDisplayManager : MonoBehaviour
    {
        public GameObject clickedObjectDisplay;

        public Text clickedObjectText;
        public Image clickedObjectImage;
        public Button clickedObjectButton;

        private void Start()
        {
            HideObject();
        }

        public void DisplayObject(WorldObject obj, GameObject sender)
        {
            clickedObjectImage.sprite = obj.sprite;
            clickedObjectText.text = $"{obj.name}\n" +
                                     $"{obj.description}";

            clickedObjectDisplay.SetActive(true);
            clickedObjectButton.gameObject.SetActive(obj.canBePickedUp);
            clickedObjectButton.onClick.AddListener(() =>
            {
                var player = GameObject.Find("Player");
                player.GetComponent<Inventory>().Add(obj);

                Destroy(sender);

                HideObject();
            });
        }

        public void HideObject()
        {
            clickedObjectDisplay.SetActive(false);

            clickedObjectImage.sprite = null;
            clickedObjectText.text = "";
            clickedObjectButton.onClick.RemoveAllListeners();
        }
    }
}