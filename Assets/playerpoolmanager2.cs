using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerpoolmanager2 : MonoBehaviour {

	public static playerpoolmanager2 _istance;

	public GameObject bulletfab;
	public GameObject bulletContainer;
	public int bulletsToSppawn;
	public bool willGrow = true;

	public List<GameObject> bulletsList = new List<GameObject>();

	void Awake(){
		_istance = this;
	}

	void Start(){
		for(int i = 0; i< bulletsToSppawn; i++){
			GameObject bullet = Instantiate(bulletfab,Vector3.zero,Quaternion.identity) as GameObject;
            bullet.transform.parent = bulletContainer.transform;
			bullet.SetActive(false);
			bulletsList.Add(bullet);
		}
	}

	public void bollchange(GameObject boll) //用來取得按鈕的事件
    {
        bulletfab = boll;               //取得對應物件的名稱
    }

    void Update(){
		/*if(bulletsList.Count > 299){
			willGrow = false;
		}*/
	}
	public GameObject GetPooledObject(){
        for (int i = 0; i < bulletsList.Count; i++){
            if (!bulletsList[i].activeInHierarchy){
                    return bulletsList[i];
                }
        }

		if(willGrow){
				GameObject bullet = Instantiate(bulletfab,Vector3.zero,Quaternion.identity) as GameObject;
	            bullet.transform.parent = bulletContainer.transform;
				bulletsList.Add(bullet);
				return bullet;
		}
			return null;
	}
}
