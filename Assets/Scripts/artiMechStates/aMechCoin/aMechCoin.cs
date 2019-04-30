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

namespace Artimech
{
    public class aMechCoin : stateMachineGame
    {
        public Vector3 m_MinSpawnForce;
        public Vector3 m_MaxSpawnForce;
        public Vector3 m_RotForce;
        public float m_CollectTimeLimit = 0.5f;
        public MeshRenderer m_MeshRender;
        bool m_PlayerCollide = false;
        aMechPlayerController m_PlayerController;

        public bool PlayerCollide { get => m_PlayerCollide; set => m_PlayerCollide = value; }
        public aMechPlayerController PlayerController { get => m_PlayerController; set => m_PlayerController = value; }

        void OnCollisionEnter(Collision collision)
        {
            aMechPlayerController playerController = collision.gameObject.GetComponent<aMechPlayerController>();
            if (collision.gameObject.GetComponent<aMechPlayerController>()!=null)
            {
                PlayerCollide = true;
                PlayerController = playerController;
                //playerController.NumGold += 1;
            }
        }

            new void Awake()
        {
            base.Awake();
            CreateStates();
        }

        // Use this for initialization
        new void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
        }

        new void FixedUpdate()
        {
            base.FixedUpdate();
        }

        /// <summary>
        /// Autogenerated state are created here inside this function.
        /// </summary>
        void CreateStates()
        {

            m_CurrentState = AddState(new coinStart(this.gameObject), "coinStart");

            //<ArtiMechStates>
            AddState(new coinCollectEnd(this.gameObject),"coinCollectEnd");
            AddState(new coinCollectStart(this.gameObject),"coinCollectStart");
            AddState(new coinUpdate(this.gameObject),"coinUpdate");

        }
    }
}