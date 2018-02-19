using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Object/Equals", "Object.Equals" )]
	public class ObjectEquals : Node 
	{
        [Expose]
        public object objectA;
        [Expose]
        public object objectB;

		protected override void OnExecute()
		{
            if (objectA == objectB)
            {

            }

			// fire exposed method: OnComplete();
			base.OnExecute();
		}

        [Expose(true)]
        public void OnTrue()
        {

        }

        [Expose]
        public void OnFalse()
        {

        }
	}
}
