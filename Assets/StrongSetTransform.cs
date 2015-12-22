#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class StrongSetTransform : BGWBase
{
    public float RotationX;
}
public partial class StrongSetTransform : BGWBase
{
    void Start()
    {

    }
    void Update()
    {
        transform.eulerAngles = new Vector3(RotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
