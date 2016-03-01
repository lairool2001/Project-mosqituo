#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class CharacterMake : BGWBase
{
    public int Count;
    public Text CountShower;
    public Image TypeShower;
    public Text NameShower;
    public Image MonsterImage;
    public MonsterData aMonsterData;
    [HideInInspector]
    public GameObject Monster;
}
public partial class CharacterMake : BGWBase
{
    void Start()
    {
        Monster = GameTopDataManger.The.TypeToMonster[aMonsterData.Type];
    }
    void Update()
    {
        UICorrespond();
    }
    public void UICorrespond()
    {
        CountShower.text = Count.ToString();
        TypeShower.color = GameTopDataManger.The.TypeToColor[aMonsterData.Type];
        NameShower.text = aMonsterData.NameText;
        MonsterImage.sprite = aMonsterData.MonsterImage;
    }
    public void ChangeMonster()
    {
        GameTopDataManger.The.TheBollcreat.bollchange(Monster, this);
    }
}
[System.Serializable]
public class MonsterData
{
    public int Type;
    public Sprite MonsterImage;
    public string NameText;
}
