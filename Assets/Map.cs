using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumIDs = EnumID.EnumID;

public class Map : MonoBehaviour
{
    //private int a[10] = new int;
    static readonly int _Width = 6;
    static readonly int _Height = 5;
    static readonly int _DropMaxNum = 4;

    int[] _Stage = new int[_Width * _Height];

    [SerializeField] private Drop _dropPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int r1 = Random.Range(0, 4);

        for (int y = 0; y < _Height; ++y)
        {
            for (int x = 0; x < _Width; ++x)
            {
                _Stage[y * _Width + x] = Random.Range(0, _DropMaxNum);
                var drop = Instantiate(_dropPrefab);
                drop.Init(_Stage[y * _Width + x]);
                drop.SetPos(x,y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
