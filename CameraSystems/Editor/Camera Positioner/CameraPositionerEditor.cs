using UnityEditor;
using UnityEngine;

namespace RedPanda.CameraSystem
{
    [CustomEditor(typeof(CameraPositioner))]
    public class CameraPositionerEditor : Editor
    {
        private CameraPositioner positioner;
        private int _index = 0;

        private int Index
        {
            get
            {
                if (_index >= positioner.cameraPositions.Count)
                {
                    _index = 0;
                }
                else if (_index < 0)
                {
                    _index = positioner.cameraPositions.Count - 1;
                }

                return _index;
            }

            set => _index = value;
        }

        private void OnEnable()
        {
            Index = 0;
            positioner = (CameraPositioner)target;
        }
        private void OnDisable()
        {
            Index = 0;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Next Position"))
            {
                ToPosition(1);
            }

            if (GUILayout.Button("Before Position"))
            {
                ToPosition(-1);
            }
        }
        private void ToPosition(int index)
        {
            Index += index;
            positioner.transform.SetPositionAndRotation(positioner.cameraPositions[Index].CameraPosition, Quaternion.Euler(positioner.cameraPositions[Index].CameraRotation));
        }
    }
}