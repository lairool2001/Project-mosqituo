#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class MaterialAnimation : BGWBase
{
    private MeshRenderer aMeshRenderer;
    public Vector2 Offset;
    public Vector2 FrameCount;
    public float Timer, TimeLength = 1;
    public Color c;
}
public partial class MaterialAnimation : BGWBase
{
    void Start()
    {
        aMeshRenderer = GetComponent<MeshRenderer>();
        aMeshRenderer.material.color = c;
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > TimeLength)
        {
            Timer = 0;

            aMeshRenderer.material.mainTextureOffset = Offset;
            Offset.x += 1 / FrameCount.x;
            if (Offset.x >= 1)
            {
                Offset.x = 0;
                Offset.y += 1 / FrameCount.y;
                if (Offset.y >= 1)
                {
                    Offset.y = 0;
                }
            }
        }
    }
}
