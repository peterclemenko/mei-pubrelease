using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Nodify/Variable/Add/Integer", "Variable.AddInteger" )]
	public class NodifyVariableAddInteger : Node 
	{
        public string keyName;

        [Expose]
        public int amountToAdd;

		protected override void OnExecute()
		{
            int originalValue = (int)GlobalVariable<int>.GetValue(keyName);
            int modifiedValue = originalValue + amountToAdd;

            GlobalVariable<int>.SetValue(keyName, modifiedValue);

			// fire exposed method: OnComplete();
			base.OnExecute();
		}
	}
}
