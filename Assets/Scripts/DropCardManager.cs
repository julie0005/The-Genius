using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCardManager : MonoBehaviour
{
    private int cardcount=0;

    private void Update()
    {
        cardcount = this.transform.childCount;
    }
}
