﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Effects
{
    public class FollowObject : MonoBehaviour
    {
        public Vector2 offset;
        public Transform follow;

        private void OnValidate()
        {
            if (follow == null)
            {
                follow = GameObject.FindGameObjectWithTag("Player").transform;
            }

            if (follow != null)
                transform.position = (Vector3)offset + follow.position;
        }

        private void Update()
        {
            transform.position = (Vector3)offset + follow.position;
        }
    }
}