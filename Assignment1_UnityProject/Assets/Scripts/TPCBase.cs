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
            Vector3 playerPositionOffset = new Vector3(0.0f, CameraConstants.CameraPositionOffset.y, 0.0f); //camera y offset from the ThirdPersonCamera class is 2.0f

            Vector3 playerHeadPos = mPlayerTransform.position + playerPositionOffset;
            Vector3 rayDirection = mCameraTransform.position - playerHeadPos;

            Ray cameraRay = new Ray(playerHeadPos, rayDirection);

            Debug.DrawRay(playerHeadPos, rayDirection, Color.black);

            //b. doing an intersection between this ray and the game objects in the scene, and 
            LayerMask mask = LayerMask.GetMask("Wall");

            RaycastHit hit;

            if (Physics.Raycast(cameraRay, out hit, (mCameraTransform.position - playerHeadPos).magnitude, mask))
            {
                //c. setting the camera's position to that intersected point (add a slight offset as well) to reposition the camera.
                Vector3 newCamPosition = hit.point;
                mCameraTransform.position = newCamPosition;
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
