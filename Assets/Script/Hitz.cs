#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class Hitz : BGWBase
{
    public List<Vector3> pointz = new List<Vector3>();
    public float range = 1;
    public int count = 100;
    public string FilterTag = "mob";
}
public partial class Hitz : BGWBase
{
    void Start()
    {
        pointz.Clear();
        for (int i = 0; i < count; i++)
        {
            Vector3 v = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
            Vector3 d = transform.position + v;
            RaycastHit rh = new RaycastHit();
            bool h = Physics.Raycast(d + new Vector3(0, 10, 0), new Vector3(0, -20, 0),out rh);
            if (h && rh.collider.CompareTag(FilterTag))
            {
                pointz.Add(v);
            }
        }
    }
    void Update()
    {

    }
}
