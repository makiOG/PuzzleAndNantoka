using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumIDs = EnumID.EnumID;

public class Drop : MonoBehaviour
{
    private bool _initFlag = false;
    //引数を渡したいので、StartではなくInit関数を作っている
    //つまりDropを生成するときはInit(ドロップタイプの引数)をセットで使用してください
    //initせずにupdateが回るとエラーメッセージが表示されます
    public void Init(int type)
    {
        var DropSprite = this.GetComponent<SpriteRenderer>();

        string dropName; 
        switch (type)
        {
            case (int)EnumIDs.DropType.twitter:
                dropName = "twitter";
                break;
            case (int)EnumIDs.DropType.note:
                dropName = "note";
                break;
            case (int)EnumIDs.DropType.trophy:
                dropName = "trophy";
                break;
            case (int)EnumIDs.DropType.heart:
                dropName = "heart";
                break;
            default:
                Debug.LogError("範囲外の値です");
                _initFlag = false;
                return;
        }
        DropSprite.sprite = Resources.Load<Sprite>(dropName);
        _initFlag = true;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_initFlag == false)
        {
            Debug.LogError("DropクラスのInitを実行してください");
        }
    }

    public void SetPos(float x,float y)
    {
        Transform myTransform = this.transform;
        myTransform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

        // 座標を取得
        Vector2 pos = myTransform.position;
        pos.x += x * 0.75f;    // x座標へ0.01加算
        pos.y += y * 0.75f;    // y座標へ0.01加算

        myTransform.position = pos;  // 座標を設定
    }
}
