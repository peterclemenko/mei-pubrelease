using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Nodify/Utilities/CallMethod", "CallMethod")]
	public class NodifyUtilitiesCallMethod : Node 
	{
		[Expose]
		public string methodName;

		[Expose]
		public MonoBehaviour monoBehaviour;

		protected override void OnExecute()
		{
			Type instance = monoBehaviour.GetType();
			if (instance == null){
				Debug.LogError("monoBehaviour get type fail", this);
				return;
			}else{
				Debug.Log(instance.Name);
			}
			MethodInfo mInfo = instance.GetMethod(methodName);
			if (mInfo == null){
				Debug.LogError(methodName + " : methodName not found - make sure it's public.", this);
				return;
			}
			System.Action Callback = delegate{
				base.OnExecute();	
			};
			mInfo.Invoke(monoBehaviour, new object[]{Callback});
		}		 
	}

}
