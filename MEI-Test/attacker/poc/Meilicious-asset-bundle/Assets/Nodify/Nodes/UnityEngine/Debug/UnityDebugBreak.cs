using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Unity/Debug/Break", "Debug.Break" )]
	public class UnityDebugBreak : Node 
	{
		protected override void OnExecute()
		{
            Debug.Break();

			// fire exposed method: OnComplete();
			base.OnExecute();
		}
	}


}
