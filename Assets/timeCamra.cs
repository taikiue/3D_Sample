using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //�i�ǉ��j


public class timeCamra : MonoBehaviour
{

  

    private GameObject TimeText;

    // Start is called before the first frame update
    void Start()
    {
       

        //�V�[������stateText�I�u�W�F�N�g���擾�i�ǉ��j
        this.TimeText = GameObject.Find("TimeCamera");

       
    }
    // Update is called once per frame
    void Update()
    {
        //�Q�[�������H
        if (UnityChanController.isEnd == false)
        {
            //stateText��time��\���i�ǉ��j
            this.TimeText.GetComponent<Text>().text = "�^�C��" + Time.time.ToString("f2") + "�b";


        }   
    }
}
