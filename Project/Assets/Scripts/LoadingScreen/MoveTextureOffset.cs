using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loading
{
    public class MoveTextureOffset : MonoBehaviour
    {
        public Material mat;

        private void Update()
        {
            var texPlace = mat.mainTextureOffset;

            texPlace.x -= Input.GetAxis("Horizontal") * Time.deltaTime;

            mat.mainTextureOffset = texPlace;
        }
    }
}