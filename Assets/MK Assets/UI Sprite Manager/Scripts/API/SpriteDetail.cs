/* 
 * Author : Mohsin Khan
 * Portfolio : http://mohsinkhan26.github.io/ 
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
*/
using System;
using UnityEngine;

namespace MK.UISprite.API
{
    [Serializable]
    class SpriteDetail
    {
        /// <summary>
        /// Saves sprite enum respective to sprite
        /// </summary>
        public SpriteEnum spriteEnum;

        /// <summary>
        /// Saves sprite respective to enum
        /// </summary>
        public Sprite sprite;
    }
}
