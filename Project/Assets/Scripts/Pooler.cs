using UnityEngine;
using System.Collections;

public class Pooler:MonoBehaviour  {
    public static Pooler current;

    public string[] names;
    public int[] size;

    public GameObject[] prefabs;

    PooledObjectType[] pooled;

    void Awake()
    {
        if (current != null) Destroy(gameObject);
        else current = this;
    }

  void Start()
    {
        pooled = new PooledObjectType[names.Length];

        for (int i = 0; i< names.Length; i++)
        {
            pooled[i] = new PooledObjectType(prefabs[i], size[i]);

        }
    }

    public GameObject GetPooled(string name)
    {
        for (int i = 0; i <names.Length;i++)
        {
            if (name == names[i])
            {
                return pooled[i].GetPooled();
            }
        }
        return null;
    }


	
}
