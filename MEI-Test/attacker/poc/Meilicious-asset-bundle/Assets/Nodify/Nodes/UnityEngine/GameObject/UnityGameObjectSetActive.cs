using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Unity/GameObject/Set Active", "GameObject.SetActive", "Icons/unity_gameobject_setactive_icon")]
	public class UnityGameObjectSetActive : Node 
	{
        [Expose]
        public GameObject target;

        [Expose]
        public bool activeState;

		protected override void OnExecute()
		{
            if (target.activeSelf != activeState)
            {
                target.SetActive(activeState);
            }

			base.OnExecute();
		}
	}
}
