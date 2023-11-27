using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    // The base class for all third-person camera controllers
    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }

        public void RepositionCamera()
        {
            //a. creating a ray that connects the camera position to the player position
            Vector3 rayDirection = mPlayerTransform.position - mCameraTransform.position;
            Ray cameraRay = new Ray(mCameraTransform.position, rayDirection);

            Debug.DrawRay(mCameraTransform.position, rayDirection, Color.black);

            //b. doing an intersection between this ray and the game objects in the scene, and 
            LayerMask mask = LayerMask.GetMask("Wall");

            RaycastHit hit;

            if (Physics.Raycast(cameraRay, out hit, 20.0f, mask))
            {
                //c. setting the camera's position to that intersected point (add a slight offset as well) to reposition the camera.
                float offsetCam = 0.1f;
                Vector3 newPostion = hit.point + hit.normal * offsetCam;
                mCameraTransform.position = newPostion;
            }

            //-------------------------------------------------------------------
            // Implement here.
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            // Hints:
            //-------------------------------------------------------------------
            // check collision between camera and the player.
            // find the nearest collision point to the player
            // shift the camera position to the nearest intersected point
            //-------------------------------------------------------------------
        }

        public abstract void Update();
    }
}
