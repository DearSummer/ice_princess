using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool{
    private static BulletPool instance;
    public static BulletPool Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new BulletPool();
            }
            return instance;
        }
    }
    private BulletPool()
    {
    }
    private List<GameObject> BulletStore = new List<GameObject>();
    private List<GameObject> LendingRecords = new List<GameObject>();

    private int Count = 0;
    private readonly string Name = "Bullet--";

    [SerializeField]
    private GameObject Store;
    public GameObject GetBullet()
    {
        GameObject temp;
        if (BulletStore.Count==0)
        {
            Store = GameObject.Find("---ShootBullet----");
            temp = GameObject.Instantiate(GameObject.Find("Bullet"));
            temp.AddComponent<BulletMove>();
            temp.name = Name + Count.ToString();
            Count++;
            LendingRecords.Add(temp);
            return temp;
        }
        temp = BulletStore[BulletStore.Count-1];
        temp.SetActive(true);
        temp.transform.parent = null;
        BulletStore.Remove(temp);
        LendingRecords.Add(temp);
        return temp;
    }
    public void ReturnBullet(GameObject thing)
    {
        if(LendingRecords.Contains(thing))
        {
            LendingRecords.Remove(thing);
            BulletStore.Add(thing);
            thing.transform.parent = Store.transform;
            thing.SetActive(false);
        }
    }
}
