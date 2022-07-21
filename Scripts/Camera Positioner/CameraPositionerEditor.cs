using UnityEditor;
using UnityEngine;

namespace RedPanda.CameraSystem
{
    [CustomEditor(typeof(CameraPositioner))]
    public class CameraPositionerEditor : Editor
    {
        #region Fields And Properties
        private CameraPositioner positioner;
        private int _index = 0;

        private int Index
        {
            get
            {
                if (_index >= positioner.CameraPositions.Count)
                {
                    _index = 0;
                }
                else if (_index < 0)
                {
                    _index = positioner.CameraPositions.Count - 1;
                }

                return _index;
            }

            set => _index = value;
        }

        #endregion Fields And Properties

        #region Unity Methods
        private void OnEnable()
        {
            Index = 0;
            positioner = (CameraPositioner)target;
        }
        private void OnDisable() => Index = 0;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Next Position"))
            {
                ToPosition(1);
            }

            if (GUILayout.Button("Previous Position"))
            {
                ToPosition(-1);
            }
        }
        #endregion Unity Methods

        #region Private Methods
        private void ToPosition(int index)
        {
            Index += index;

            if (positioner.SetPosition)
            {
                positioner.transform.position = positioner.CameraPositions[Index].CameraPosition;
            }
            if (positioner.SetRotation)
            {
                positioner.transform.rotation = Quaternion.Euler(positioner.CameraPositions[Index].CameraRotation);
            }
        }
        #endregion Private Methods
    }
}