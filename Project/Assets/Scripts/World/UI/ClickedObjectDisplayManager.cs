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
            clickedObjectButton.enabled = obj.canBePickedUp;
            clickedObjectButton.onClick.AddListener(() =>
            {
                PickUpItem(obj, sender);
            });
        }

        private void PickUpItem(WorldObject obj, GameObject sender)
        {
            var player = GameObject.Find("Player");
            player.GetComponent<Inventory>().Add(obj);
            clickedObjectButton.enabled = false;

            Destroy(sender);
            Invoke(nameof(HideObject), 0.6f);
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