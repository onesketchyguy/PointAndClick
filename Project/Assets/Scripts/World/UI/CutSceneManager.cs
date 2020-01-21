using UnityEngine;

namespace World.UI
{
    public class CutSceneManager : MonoBehaviour
    {
        public PortaitManager playerPortait;

        private void Start()
        {
            HideMessage();
        }

        public void DisplayMessage(string message)
        {
            playerPortait.gameObject.SetActive(true);
            playerPortait.DisplayMessage(message);
        }

        public void HideMessage()
        {
            playerPortait.gameObject.SetActive(false);
        }
    }
}