/// Artimech
/// 
/// Copyright © <2017> <George A Lancaster>
/// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
/// and associated documentation files (the "Software"), to deal in the Software without restriction, 
/// including without limitation the rights to use, copy, modify, merge, publish, distribute, 
/// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
/// is furnished to do so, subject to the following conditions:
/// The above copyright notice and this permission notice shall be included in all copies 
/// or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
/// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
/// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
/// OTHER DEALINGS IN THE SOFTWARE.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region XML_DATA

#if ARTIMECH_META_DATA
<!-- Atrimech metadata for positioning and other info using the visual editor.  -->
<!-- The format is XML. -->
<!-- __________________________________________________________________________ -->
<!-- Note: Never make ARTIMECH_META_DATA true since this is just metadata       -->
<!-- Note: for the visual editor to work.                                       -->

<stateMetaData>
  <State>
    <alias>camUpdate</alias>
    <comment></comment>
    <posX>252</posX>
    <posY>38</posY>
    <sizeX>150</sizeX>
    <sizeY>80</sizeY>
  </State>
</stateMetaData>

#endif

#endregion
namespace Artimech
{
    public class camUpdate : stateGameBase
    {

        /// <summary>
        /// State constructor.
        /// </summary>
        /// <param name="gameobject"></param>
        public camUpdate(GameObject gameobject) : base(gameobject)
        {
            //<ArtiMechConditions>
        }

        /// <summary>
        /// Updates from the game object.
        /// </summary>
        public override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// Fixed Update for physics and such from the game object.
        /// </summary>
        public override void FixedUpdate()
        {
            FixedUpdateTarget();
            FixedUpdateCamera();
            base.FixedUpdate();
        }

        void FixedUpdateCamera()
        {
            aMechThirdPersonCam camScript = StateGameObject.GetComponent<aMechThirdPersonCam>();
            float distance = Vector3.Distance(camScript.m_CameraGoal.transform.position, camScript.m_TargetGoal.transform.position);
            //Debug.Log(distance);
            if (distance > camScript.m_MaxDistanceToPlayer)
            {
                float coef = camScript.m_CamApproachCurve.Evaluate(distance);
                float velocity = coef * camScript.m_CameraFollowVelocity;
                camScript.m_CameraGoal.transform.position = Vector3.Lerp(camScript.m_CameraGoal.transform.position, camScript.m_TargetGoal.transform.position, velocity * gameMgr.GetFixedSeconds());
                //camScript.transform.position = camScript.m_CameraGoal.transform.position;
                //camScript.m_CameraGoal.transform.position = Vector3.Lerp(camScript.m_CameraGoal.transform.position, camScript.m_TargetGoal.transform.position, velocity * gameMgr.GetFixedSeconds());
            }

            if (distance < camScript.m_MinDistanceToPlayer)
            {
                float coef = camScript.m_CamApproachCurve.Evaluate(distance);
                float velocity = coef * camScript.m_CameraFollowVelocity;
                camScript.m_CameraGoal.transform.position = utlMath.ExtendLine(camScript.m_TargetGoal.transform.position, camScript.m_CameraGoal.transform.position, camScript.m_MinDistanceToPlayer - distance);
                Vector3 tempPos = camScript.m_CameraGoal.transform.position;
                tempPos.y = camScript.m_TargetGoal.transform.position.y;
                camScript.m_CameraGoal.transform.position = tempPos;

                //camScript.m_CameraGoal.transform.position = Vector3.Lerp(camScript.m_TargetGoal.transform.position, camScript.m_CameraGoal.transform.position, 1.0f + (velocity * gameMgr.GetFixedSeconds()));
            }

            //camScript.m_CameraGoal.transform.position = Vector3.Lerp(camScript.m_CameraGoal.transform.position, camScript.m_TargetGoal.transform.position, velocity * gameMgr.GetFixedSeconds());

            distance = Vector3.Distance(camScript.transform.position, camScript.m_CameraGoal.transform.position);
            float coefCam = camScript.m_CamApproachCurve.Evaluate(distance);
            float velocityCam = coefCam * camScript.m_FollowToGoalCamVel;

            camScript.transform.position = Vector3.Lerp(camScript.transform.position, camScript.m_CameraGoal.transform.position, velocityCam * gameMgr.GetFixedSeconds());

        }

        void FixedUpdateTarget()
        {
            aMechThirdPersonCam camScript = StateGameObject.GetComponent<aMechThirdPersonCam>();
            float distance = Vector3.Distance(camScript.m_TargetFollow.transform.position, camScript.m_TargetGoal.transform.position);
            float coef = camScript.m_TargetApproachCure.Evaluate(distance);
            float velocity = coef * camScript.m_TargetFollowVelocity;
            camScript.m_TargetFollow.transform.position = Vector3.Lerp(camScript.m_TargetFollow.transform.position, camScript.m_TargetGoal.transform.position, velocity * gameMgr.GetFixedSeconds());

            camScript.transform.LookAt(camScript.m_TargetFollow.transform);
        }

        /// <summary>
        /// For updateing the unity gui.
        /// </summary>
        public override void UpdateEditorGUI()
        {
            base.UpdateEditorGUI();
        }

        /// <summary>
        /// When the state becomes active Enter() is called once.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
        }

        /// <summary>
        /// When the state becomes inactive Exit() is called once.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
        }
    }
}