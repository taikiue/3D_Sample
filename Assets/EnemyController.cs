using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UIの部品
using UnityEngine.UI;





public class EnemyController : MonoBehaviour
{
    //アニメーターのコンポーネントを入れる
    private Animator myAnimator;

    //Rock1を入れる
    public GameObject Rock1;

    //RockPrefabを入れる
    public GameObject RockPrefab;

    //treePrefabを入れる
    public GameObject treePrefab;

    //Churchを入れる
    public GameObject Church;

    //tree_1を入れる
    public GameObject tree_1;

    //UnityChanを入れる
    public GameObject UnityChan;

    //プレイヤーの方向を定義
    private float directionPlayer;

    //範囲移動
    //private Vector3 pos;


    //敵の左右移動（１８０度回転）
    
    Transform endPoint;

    //開始位置
    Vector3 startPos;

    //終端位置
    Vector3 endPos;

    //次の目的地
    Vector3 destPos;

    //移動速度
    private float speed = 3f;

    //回転速度
    //private float rotateSpeed = 180f;

    //方向転換時の回転量
    private float rotateNum;


    // 回転速度
    private float rotSpeed = 40.0f;





    //停止時間
    // private float chargeTime = 5.0f;

    //タイムカウント
    // private float timeCount;

    //プレイヤーオブジェクト
    private GameObject playerObject;

    //プレイヤーまでの距離
    private float lengthPlayer;

    //壁までの距離 ※最初は範囲外にしておく
    private float lengthWall = 1000.0f;

    //プレイヤーが見えている
    private bool isVisible = false;

    //デバッグ表示をするテキスト
    private GameObject debugText;

    //敵キャラを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;

    //移動の速度
     //float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //Rigidbodyコンポーネントを取得（追加）
        this.myRigidbody = GetComponent<Rigidbody>();

        //プレイヤーオブジェクトを取得
        this.playerObject = GameObject.Find( "UnityChan");

        //DebugTextオブジェクトを取得
        this.debugText = GameObject.Find( "DebugText");

        //範囲移動
        //pos = transform.position;

        /*startPos = transform.position;
        endPos = endPoint.position;
        destPos = endPos;
        */

        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);


    }



    // Update is called once per frame
    void Update()
    {
        //プレイヤーまでの距離を取得
        this.lengthPlayer = getLength(this.transform.position, playerObject.transform.position);

        //プレイヤーの方向を取得 ※オイラー（-180～0～+180) 360度
        this.directionPlayer = getDirection(this.transform.position, playerObject.transform.position);

        //プレイヤーが見えているか？
        if (isVisible)
        {
            this.debugText.GetComponent<Text>().text = "【!!!!!】";


            //プレイヤーへ向く Y軸 ※オイラー
            this.transform.eulerAngles = new Vector3(0f, this.directionPlayer, 0f);

            //向いている角度に移動させる
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sin(this.directionPlayer * Mathf.Deg2Rad), 0f, Mathf.Cos(this.directionPlayer * Mathf.Deg2Rad));
            this.myRigidbody.velocity = new Vector3(Mathf.Sin(this.directionPlayer * Mathf.Deg2Rad) * speed, 0f, Mathf.Cos(this.directionPlayer * Mathf.Deg2Rad) * speed);

            //アニメーション
            //Runアニメを再生
            this.myAnimator.SetBool("Run", true);
             speed = 5f;

            
        }

        
        
        else
        {
            this.debugText.GetComponent<Text>().text = "";
            speed = 3f;

            //回転
            // transform.Rotate(0f, 120.0f * Time.deltaTime, 0f);
            this.transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);

            myAnimator.SetBool("Run", false);
           // myAnimator.SetBool("Idle", true);

            //myAnimator.SetBool("Walk", true);


            /*端に到達したときの方向転換
            if ((destPos - transform.position).magnitude < 0.1f)
            {
                //回転途中の場合
                if (rotateNum < 180)
                {
                    myAnimator.SetBool("Walk", false);
                    transform.position = destPos;

                    float addNum = rotateSpeed * Time.deltaTime;
                    rotateNum += addNum;
                    transform.Rotate(0, addNum, 0);
                }

                //回転しきった場合
                //次の目的地の設定と回転量のリセット
                else
                {
                    destPos = destPos == startPos ? endPos : startPos;
                    rotateNum = 0;


                }

                        
             }

            //次の目的地に向けて移動する
            myAnimator.SetBool("Walk", true);
            transform.LookAt(destPos);
            transform.position += transform.forward * speed * Time.deltaTime;

           


            //範囲移動
            // transform.position = new Vector3(pos.x +  5, pos.y, pos.z);
            */




            /*
            //歩くのを止める、アイドリングにする。
            timeCount += Time.deltaTime;

            // 自動前進
            transform.position += transform.forward * Time.deltaTime;

            // 指定時間の経過（条件）
            if (timeCount > chargeTime)
            {
                // 進路をランダムに変更する
                Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
                transform.localRotation = Quaternion.Euler(course);

                // タイムカウントを０に戻す
                timeCount = 0;
            

            }
            */

        }

        //デバッグ
        /*if ( isVisible) {
            this.debugText.GetComponent<Text>().text = "【プレイヤーが見えています。】";
        }
        else
        {
            this.debugText.GetComponent<Text>().text = "";
        }*/
       
    }

    //距離を求める関数
    float getLength( Vector3 current, Vector3 target)
    {
        return Mathf.Sqrt( ((current.x - target.x) * (current.x - target.x)) + ((current.z - target.y) * (current.z - target.y)));
    }

    //  角度を求める式関数
    float getDirection(Vector3 current,Vector3 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.z) * Mathf.Rad2Deg;
    }

    //視線の衝突判定 ※衝突時に常に呼ばれる
    void OnTriggerStay( Collider other)
    {
        //プレイヤーまでの距離を取得
        this.lengthPlayer = getLength( this.transform.position, playerObject.transform.position);
      

        if( other.gameObject.tag == "Player" )
        {
            //壁がプレイヤーより近い？
            if( this.lengthWall < this.lengthPlayer) {
                //プレイヤーが壁に隠れている
                this.isVisible = false;

                myAnimator.SetBool("Run", false);
                this.transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);




            }
            else
            {

                
                //プレイヤーが視界範囲にいる
                this.isVisible = true;

                //Runアニメを再生
                //this.myAnimator.SetBool("Run", true);

               



            }
        }
        else if( other.gameObject.tag == "WallTag")
        {
            //壁がプレイヤーより近い？
            if( getLength( this.transform.position, other.transform.position) < lengthPlayer)
            {
                //壁までの距離を取得
                this.lengthWall= getLength( this.transform.position, other.transform.position);

                myAnimator.SetBool("Run", false);
                this.transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);




                //Walkアニメを再生
                //this.myAnimator.SetBool("Walk", true);
            }
        }
    }

    //視線の衝突判定 ※離れた時に呼ばれる
    void OnTriggerExit( Collider other)
    {
        if( other.gameObject.tag == "Player")
        {
            //プレイヤーが視界範囲にいない
            this.isVisible = false;

            //Runアニメを再生
           this.myAnimator.SetBool("Run", false);
            

            //Walkアニメを再生
            //this.myAnimator.SetBool("Walk", true);
        }
        else if( other.gameObject.tag == "WallTag")
        {
            //壁までの距離を範囲外にする
            this.lengthWall= 1000.0f;
        }
    }

     

        
    
}