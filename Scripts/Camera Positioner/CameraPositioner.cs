using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.CameraSystem
{
    public class CameraPositioner : MonoBehaviour
    {
        #region Fields And Properties
        [Header("Target")]
        [SerializeField] private Transform _target;
        [SerializeField] private bool _followTarget = true;

        [Header("Camera Movement")]
        [SerializeField][Range(0.1f, 10f)] private float _speed = 5f;
        [SerializeField] private bool _setPosition = true;
        [SerializeField] private bool _setRotation = true;
        [SerializeField] private List<SO_CameraPositionAndRotation> _cameraPositions = new List<SO_CameraPositionAndRotation>();
        private int _index = 0;

        public List<SO_CameraPositionAndRotation> CameraPositions => _cameraPositions;
        public bool SetPosition { get => _setPosition; }
        public bool SetRotation { get => _setRotation; }
        #endregion Fields And Properties

        #region Unity Methods
        private void Start()
        {
            if (_followTarget && _target == null)
            {
                _target = GameObject.Find("Player").transform;
            }

            SetIndex(0);
        }
        private void LateUpdate()
        {
            if (CameraPositions == null)
            {
                Debug.Log("There is no position preset. Please add one.");
                return;
            }

            Move(_index);
        }
        #endregion Unity Methods

        #region Public Methods
        public void SetIndex(int id)
        {
            _index = id;
        }
        private void Move(int id)
        {
            if (_followTarget && _target == null)
            {
                return;
            }

            if (SetPosition)
            {
                transform.position = Vector3.Lerp(transform.position, _target.transform.position + CameraPositions[id].CameraPosition, Time.deltaTime * _speed);
            }
            if (SetRotation)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CameraPositions[id].CameraRotation), Time.deltaTime * _speed);
            }
        }
        #endregion Public Methods
    }
}