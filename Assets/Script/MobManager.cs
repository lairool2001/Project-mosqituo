#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class MobManager : BGWBase
{
    public List<mobcontroller> AllMob;
    public bool MobOver
    {
        get { return AllMob.Count == 0; }
    }
    public bool MobExit
    { get { return AllMob.Count != 0; } }
}
public partial class MobManager : BGWBase
{
    void Start()
    {
        AllMob.Clear();
        AllMob.AddRange(mobcontroller.FindObjectsOfType<mobcontroller>());
    }
    void Update()
    {

    }
    public void OnMobDie(mobcontroller m)
    {
        print(m.name + " dead.");
        AllMob.Remove(m);
    }
}
