using System.Collections;
using System.Collections.Generic;
using Hiramesaurus.Minerva;
using UnityEngine;

public class IncrementGlobalTest : MonoBehaviour
{
    public GlobalInt Global;

    // Update is called once per frame
    private void Update()
    {
        Global.Increment ();
    }
}
