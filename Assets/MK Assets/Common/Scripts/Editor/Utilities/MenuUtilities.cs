/* 
 * Author : Mohsin Khan
 * Portfolio : http://mohsinkhan26.github.io/ 
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
*/
using UnityEditor;
using UnityEngine;

namespace MK.Common.Utilities
{
    public static class MenuUtilities
    {
        [MenuItem("Tools/MK Assets/Check All Plugins", false, 50)]
        public static void CheckAllPlugins()
        {
            Application.OpenURL("https://assetstore.unity.com/publishers/28971");
        }

        [MenuItem("Tools/MK Assets/GitHub Profile", false, 50)]
        public static void CheckGitHubProfile()
        {
            Application.OpenURL("https://github.com/mohsinkhan26/");
        }

        [MenuItem("Tools/MK Assets/BitBucket Profile", false, 50)]
        public static void CheckBitBucketProfile()
        {
            Application.OpenURL("https://bitbucket.org/mohsinkhan26/");
        }

        [MenuItem("Tools/MK Assets/OpenScene/UI Sprite Manager - Demo Scene")]
        public static void OpenDemoScene()
        {
            OpenScene("Demo");
        }

        static void OpenScene(string name)
        {
            if (UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/MK Assets/UI Sprite Manager/Scene/" + name + ".unity");
            }
        }
    }
}
