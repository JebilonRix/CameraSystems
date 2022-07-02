using UnityEngine;

namespace RedPanda.CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _target;
        [SerializeField] private string _targetTag = "Player";
        [SerializeField] private Vector3 _followDistance = new Vector3(0, 4f, -5f);
        [SerializeField] private Vector3 _followRotation = new Vector3(30f, 0, 0);
        #endregion Fields

        #region Unity Methods
        private void LateUpdate()
        {
            SetPosition();
        }
        #endregion Unity Methods

        #region Public Methods
        public void FindTarget()
        {
            MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();

            foreach (MonoBehaviour item in monoBehaviours)
            {
                if (item.CompareTag(_targetTag))
                {
                    _target = item.gameObject;
                    break;
                }
            }
        }
        public void SetPosition()
        {
            if (_target != null)
            {
                transform.SetPositionAndRotation(_target.transform.position + _followDistance, Quaternion.Euler(_followRotation));
            }
        }
        #endregion Public Methods
    }
}