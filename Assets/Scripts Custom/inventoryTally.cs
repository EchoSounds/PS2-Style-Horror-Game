using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventoryTally : MonoBehaviour
{
    public TMP_Text itemOneTally;
    public TMP_Text itemTwoTally;
    //public TMP_Text itemThreeTally;

    private void Update()
    {
        itemOneTally.SetText(globalVariables.itemOne.ToString());  //When adding more items, make sure to add into globalVariables script as well.
        itemTwoTally.SetText(globalVariables.itemTwo.ToString());
        //itemThreeTally.SetText(globalVariables.itemThree.ToString());
    }

}
