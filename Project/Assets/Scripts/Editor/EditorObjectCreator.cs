﻿using UnityEditor;
using UnityEngine;

namespace World
{
    public class EditorObjectCreator
    {
        [MenuItem("Tools/Create Clickable object")]
        public static void CreateClickableObject()
        {
            var go = new GameObject("New clickable object", typeof(ClickableObject), typeof(BoxCollider2D));
            var spr = new GameObject("Sprite", typeof(SpriteRenderer));
            spr.transform.SetParent(go.transform);
            spr.transform.localPosition = Vector3.zero;
            var spriteRenderer = spr.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 100;
            spriteRenderer.sortingLayerName = "Back";

            var clickable = go.GetComponent<ClickableObject>();

            clickable.spriteRenderer = spriteRenderer;
            clickable.Item = null;

            go.layer = LayerMask.NameToLayer("Interactable");
        }

        [MenuItem("Tools/Create trigger event")]
        public static void CreateTriggerEventObject()
        {
            new GameObject("New trigger event", typeof(BoxCollider2D), typeof(ScriptableEvents.TriggerEvent));
        }
    }
}