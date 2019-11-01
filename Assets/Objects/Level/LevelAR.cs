using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;

using UnityEngine.XR;

namespace Game
{
    [DefaultExecutionOrder(Level.ExecutionOrder + 10)]
    public class LevelAR : MonoBehaviour
	{
        public Level Level => Level.Instance;

        public MarkerProperty marker;
        [Serializable]
        public class MarkerProperty
        {
            public ImageTargetBehaviour behaviour;

            public bool Visible
            {
                set
                {
                    foreach (var target in behaviour.GetComponentsInChildren<Renderer>())
                        target.enabled = value;

                    foreach (var target in behaviour.GetComponentsInChildren<Collider>())
                        target.enabled = value;

                    foreach (var target in behaviour.GetComponentsInChildren<Canvas>())
                        target.enabled = value;
                }
            }

            public LevelAR AR => Level.Instance.AR;

            public virtual void Init()
            {
                
            }

            public void Reset()
            {
                behaviour.transform.position = Vector3.zero;
                behaviour.transform.rotation = Quaternion.identity;
            }
        }

        public CameraDevice CameraDevice => CameraDevice.Instance;

        public LevelCameraSetup CameraSetup => Level.CameraSetup;

        public bool Active
        {
            set
            {
                if (value)
                {
                    marker.Visible = false;

                    CameraDevice.Start();
                }
                else
                {
                    CameraDevice.Stop();
                }

                IEnumerator Procedure()
                {
                    CameraSetup.AR.gameObject.SetActive(value);
                    CameraSetup.Standard.gameObject.SetActive(!value);

                    yield return new WaitForEndOfFrame();

                    if (value)
                    {

                    }
                    else
                    {
                        marker.Visible = true;
                    }

                    marker.Reset();
                }

                StartCoroutine(Procedure());
            }
        }

        private void Start()
        {
            marker.Init();
        }
    }
}