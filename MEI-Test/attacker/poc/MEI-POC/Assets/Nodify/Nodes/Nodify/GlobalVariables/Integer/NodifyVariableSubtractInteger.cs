using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Nodify/Variable/Subtract/Integer", "Variable.SubtractInteger" )]
	public class NodifyVariableSubtractInteger : Node 
	{
        public string keyName;

        [Expose]
        public int amountToSubtract;

		protected override void OnExecute()
		{
            int originalValue = (int)GlobalVariable<int>.GetValue(keyName);
            int modifiedValue = originalValue - amountToSubtract;

            GlobalVariable<int>.SetValue(keyName, modifiedValue);

			// fire exposed method: OnComplete();
			base.OnExecute();
		}
	}
}
