using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Nodify/Variable/Set", "Variable.Set")]
	public class NodifyVariableSet : Node 
	{
        [Expose]
        public string keyName;

        [Expose]
        public object value;

		protected override void OnExecute()
		{
            GlobalVariableBase.SetValue(keyName, value);

			base.OnExecute();
		}
	}
}
