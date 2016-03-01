#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class GameTopDataManger : BGWBase
{
    public bollcreat TheBollcreat;
    public GameObject RMonster, GMonster, BMonster;
    public Dictionary<int, Color> TypeToColor = new Dictionary<int, Color>();
    public Dictionary<int, GameObject> TypeToMonster = new Dictionary<int, GameObject>();
    public static GameTopDataManger The;

}
public partial class GameTopDataManger : BGWBase
{
    void Awake()
    {
        TypeToColor.Add(0, Color.red);
        TypeToColor.Add(1, Color.green);
        TypeToColor.Add(2, Color.blue);
        TypeToMonster.Add(0, RMonster);
        TypeToMonster.Add(1, GMonster);
        TypeToMonster.Add(2, BMonster);
        The = this;
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
