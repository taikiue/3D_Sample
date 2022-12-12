using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //（追加）


public class timeCamra : MonoBehaviour
{

  

    private GameObject TimeText;

    // Start is called before the first frame update
    void Start()
    {
       

        //シーン中のstateTextオブジェクトを取得（追加）
        this.TimeText = GameObject.Find("TimeCamera");

       
    }
    // Update is called once per frame
    void Update()
    {
        //ゲーム中か？
        if (UnityChanController.isEnd == false)
        {
            //stateTextにtimeを表示（追加）
            this.TimeText.GetComponent<Text>().text = "タイム" + Time.time.ToString("f2") + "秒";


        }   
    }
}
