using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�̕��i
using UnityEngine.UI;





public class EnemyController : MonoBehaviour
{
    //�A�j���[�^�[�̃R���|�[�l���g������
    private Animator myAnimator;

    //Rock1������
    public GameObject Rock1;

    //RockPrefab������
    public GameObject RockPrefab;

    //treePrefab������
    public GameObject treePrefab;

    //Church������
    public GameObject Church;

    //tree_1������
    public GameObject tree_1;

    //UnityChan������
    public GameObject UnityChan;

    //�v���C���[�̕������`
    private float directionPlayer;

    //�͈͈ړ�
    //private Vector3 pos;


    //�G�̍��E�ړ��i�P�W�O�x��]�j
    
    Transform endPoint;

    //�J�n�ʒu
    Vector3 startPos;

    //�I�[�ʒu
    Vector3 endPos;

    //���̖ړI�n
    Vector3 destPos;

    //�ړ����x
    private float speed = 3f;

    //��]���x
    //private float rotateSpeed = 180f;

    //�����]�����̉�]��
    private float rotateNum;


    // ��]���x
    private float rotSpeed = 40.0f;





    //��~����
    // private float chargeTime = 5.0f;

    //�^�C���J�E���g
    // private float timeCount;

    //�v���C���[�I�u�W�F�N�g
    private GameObject playerObject;

    //�v���C���[�܂ł̋���
    private float lengthPlayer;

    //�ǂ܂ł̋��� ���ŏ��͔͈͊O�ɂ��Ă���
    private float lengthWall = 1000.0f;

    //�v���C���[�������Ă���
    private bool isVisible = false;

    //�f�o�b�O�\��������e�L�X�g
    private GameObject debugText;

    //�G�L�������ړ�������R���|�[�l���g������
    private Rigidbody myRigidbody;

    //�ړ��̑��x
     //float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //Rigidbody�R���|�[�l���g���擾�i�ǉ��j
        this.myRigidbody = GetComponent<Rigidbody>();

        //�v���C���[�I�u�W�F�N�g���擾
        this.playerObject = GameObject.Find( "UnityChan");

        //DebugText�I�u�W�F�N�g���擾
        this.debugText = GameObject.Find( "DebugText");

        //�͈͈ړ�
        //pos = transform.position;

        /*startPos = transform.position;
        endPos = endPoint.position;
        destPos = endPos;
        */

        //��]���J�n����p�x��ݒ�
        this.transform.Rotate(0, Random.Range(0, 360), 0);


    }



    // Update is called once per frame
    void Update()
    {
        //�v���C���[�܂ł̋������擾
        this.lengthPlayer = getLength(this.transform.position, playerObject.transform.position);

        //�v���C���[�̕������擾 ���I�C���[�i-180�`0�`+180) 360�x
        this.directionPlayer = getDirection(this.transform.position, playerObject.transform.position);

        //�v���C���[�������Ă��邩�H
        if (isVisible)
        {
            this.debugText.GetComponent<Text>().text = "�y!!!!!�z";


            //�v���C���[�֌��� Y�� ���I�C���[
            this.transform.eulerAngles = new Vector3(0f, this.directionPlayer, 0f);

            //�����Ă���p�x�Ɉړ�������
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sin(this.directionPlayer * Mathf.Deg2Rad), 0f, Mathf.Cos(this.directionPlayer * Mathf.Deg2Rad));
            this.myRigidbody.velocity = new Vector3(Mathf.Sin(this.directionPlayer * Mathf.Deg2Rad) * speed, 0f, Mathf.Cos(this.directionPlayer * Mathf.Deg2Rad) * speed);

            //�A�j���[�V����
            //Run�A�j�����Đ�
            this.myAnimator.SetBool("Run", true);
             speed = 5f;

            
        }

        
        
        else
        {
            this.debugText.GetComponent<Text>().text = "";
            speed = 3f;

            //��]
            // transform.Rotate(0f, 120.0f * Time.deltaTime, 0f);
            this.transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);

            myAnimator.SetBool("Run", false);
           // myAnimator.SetBool("Idle", true);

            //myAnimator.SetBool("Walk", true);


            /*�[�ɓ��B�����Ƃ��̕����]��
            if ((destPos - transform.position).magnitude < 0.1f)
            {
                //��]�r���̏ꍇ
                if (rotateNum < 180)
                {
                    myAnimator.SetBool("Walk", false);
                    transform.position = destPos;

                    float addNum = rotateSpeed * Time.deltaTime;
                    rotateNum += addNum;
                    transform.Rotate(0, addNum, 0);
                }

                //��]���������ꍇ
                //���̖ړI�n�̐ݒ�Ɖ�]�ʂ̃��Z�b�g
                else
                {
                    destPos = destPos == startPos ? endPos : startPos;
                    rotateNum = 0;


                }

                        
             }

            //���̖ړI�n�Ɍ����Ĉړ�����
            myAnimator.SetBool("Walk", true);
            transform.LookAt(destPos);
            transform.position += transform.forward * speed * Time.deltaTime;

           


            //�͈͈ړ�
            // transform.position = new Vector3(pos.x +  5, pos.y, pos.z);
            */




            /*
            //�����̂��~�߂�A�A�C�h�����O�ɂ���B
            timeCount += Time.deltaTime;

            // �����O�i
            transform.position += transform.forward * Time.deltaTime;

            // �w�莞�Ԃ̌o�߁i�����j
            if (timeCount > chargeTime)
            {
                // �i�H�������_���ɕύX����
                Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
                transform.localRotation = Quaternion.Euler(course);

                // �^�C���J�E���g���O�ɖ߂�
                timeCount = 0;
            

            }
            */

        }

        //�f�o�b�O
        /*if ( isVisible) {
            this.debugText.GetComponent<Text>().text = "�y�v���C���[�������Ă��܂��B�z";
        }
        else
        {
            this.debugText.GetComponent<Text>().text = "";
        }*/
       
    }

    //���������߂�֐�
    float getLength( Vector3 current, Vector3 target)
    {
        return Mathf.Sqrt( ((current.x - target.x) * (current.x - target.x)) + ((current.z - target.y) * (current.z - target.y)));
    }

    //  �p�x�����߂鎮�֐�
    float getDirection(Vector3 current,Vector3 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.z) * Mathf.Rad2Deg;
    }

    //�����̏Փ˔��� ���Փˎ��ɏ�ɌĂ΂��
    void OnTriggerStay( Collider other)
    {
        //�v���C���[�܂ł̋������擾
        this.lengthPlayer = getLength( this.transform.position, playerObject.transform.position);
      

        if( other.gameObject.tag == "Player" )
        {
            //�ǂ��v���C���[���߂��H
            if( this.lengthWall < this.lengthPlayer) {
                //�v���C���[���ǂɉB��Ă���
                this.isVisible = false;

                myAnimator.SetBool("Run", false);
                this.transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);




            }
            else
            {

                
                //�v���C���[�����E�͈͂ɂ���
                this.isVisible = true;

                //Run�A�j�����Đ�
                //this.myAnimator.SetBool("Run", true);

               



            }
        }
        else if( other.gameObject.tag == "WallTag")
        {
            //�ǂ��v���C���[���߂��H
            if( getLength( this.transform.position, other.transform.position) < lengthPlayer)
            {
                //�ǂ܂ł̋������擾
                this.lengthWall= getLength( this.transform.position, other.transform.position);

                myAnimator.SetBool("Run", false);
                this.transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);




                //Walk�A�j�����Đ�
                //this.myAnimator.SetBool("Walk", true);
            }
        }
    }

    //�����̏Փ˔��� �����ꂽ���ɌĂ΂��
    void OnTriggerExit( Collider other)
    {
        if( other.gameObject.tag == "Player")
        {
            //�v���C���[�����E�͈͂ɂ��Ȃ�
            this.isVisible = false;

            //Run�A�j�����Đ�
           this.myAnimator.SetBool("Run", false);
            

            //Walk�A�j�����Đ�
            //this.myAnimator.SetBool("Walk", true);
        }
        else if( other.gameObject.tag == "WallTag")
        {
            //�ǂ܂ł̋�����͈͊O�ɂ���
            this.lengthWall= 1000.0f;
        }
    }

     

        
    
}