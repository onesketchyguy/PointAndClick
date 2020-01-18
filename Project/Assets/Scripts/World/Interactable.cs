using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.UI;

namespace World
{
    public class Interactable : MonoBehaviour
    {
        public Interaction[] interactions;

        private CutSceneManager cutSceneManager;

        private void Start()
        {
            cutSceneManager = FindObjectOfType<CutSceneManager>();
        }

        private void OnMouseUpAsButton()
        {
            Use(InteractionManager.objectUsing);
        }

        public void Use(WorldObject @object)
        {
            // Check to see the usage of this item
            for (int i = 0; i < interactions.Length; i++)
            {
                if (interactions[i].objectUsed == @object)
                {
                    interactions[i].Event.Invoke();

                    cutSceneManager.DisplayMessage(interactions[i].output);

                    return;
                }
            }

            cutSceneManager.DisplayMessage($"I can't do that...");
        }
    }
}