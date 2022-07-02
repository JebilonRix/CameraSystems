using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.CameraSystem
{
    public class CameraPositioner : MonoBehaviour
    {
        public List<SO_CameraPositionAndRotation> cameraPositions;

        private void LateUpdate()
        {
            if (cameraPositions != null)
            {
                MoveCamera(0);
            }
        }

        public void MoveCamera(int id)
        {
            if (transform.position != cameraPositions[id].CameraPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, cameraPositions[id].CameraPosition, Time.deltaTime * 10);
            }

            if (transform.rotation != Quaternion.Euler(cameraPositions[id].CameraRotation))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(cameraPositions[id].CameraRotation), Time.deltaTime * 10);
            }
        }
    }
}