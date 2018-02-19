using UnityEngine;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Nodify/Variable/Compare/Integer", "Variable.IntegerCompare" )]
	public class NodifyVariableCompareInteger : Node 
	{
        public string keyName;

        public IntegerCompareType compareType;

        [Expose]
        public int compareAmount;

        protected override void OnExecute()
        {
            int variableValue = (int)GlobalVariable<int>.GetValue(keyName);

            switch (compareType)
            {
                case IntegerCompareType.EQUALS:
                    if (variableValue == compareAmount)
                    {
                        this.Fire("OnTrue");
                    }
                    else
                    {
                        this.Fire("OnFalse");
                    }
                    break;
                case IntegerCompareType.GREATER_THAN:
                    if (variableValue > compareAmount)
                    {
                        this.Fire("OnTrue");
                    }
                    else
                    {
                        this.Fire("OnFalse");
                    }
                    break;
                case IntegerCompareType.GREATER_THAN_EQUALS:
                    if (variableValue >= compareAmount)
                    {
                        this.Fire("OnTrue");
                    }
                    else
                    {
                        this.Fire("OnFalse");
                    }
                    break;
                case IntegerCompareType.LESSER_THAN:
                    if (variableValue < compareAmount)
                    {
                        this.Fire("OnTrue");
                    }
                    else
                    {
                        this.Fire("OnFalse");
                    }
                    break;
                case IntegerCompareType.LESSER_THAN_EQUALS:
                    if (variableValue <= compareAmount)
                    {
                        this.Fire("OnTrue");
                    }
                    else
                    {
                        this.Fire("OnFalse");
                    }
                    break;
            
            }

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

    public enum IntegerCompareType
    {
        EQUALS,
        GREATER_THAN,
        GREATER_THAN_EQUALS,
        LESSER_THAN,
        LESSER_THAN_EQUALS
    }
}
