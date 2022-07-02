using UnityEditor;
using UnityEngine;

namespace RedPanda.CameraSystem
{
    [CustomEditor(typeof(CameraFollow))]
    public class CameraFollowEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CameraFollow cameraFollow = (CameraFollow)target;

            if (GUILayout.Button("Find Target"))
            {
                cameraFollow.FindTarget();
            }

            if (GUILayout.Button("Set Camera Position"))
            {
                cameraFollow.SetPosition();
            }
        }
    }
}