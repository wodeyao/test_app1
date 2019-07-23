//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class TestAI : MonoBehaviour
//{

//    public GameObject[] GoOnPatrolPoint;
//    NavMeshAgent enemynavmeshagent;
//    int count = 1;
//    Animator EnemyAnimator;
//    bool startoroutine;
//    GameObject distance;
//    Vector3 distancePosition;
//    bool IsAttack;

//    // Use this for initialization
//    void Start()
//    {

//        EnemyAnimator = GetComponent<Animator>();
//        enemynavmeshagent = GetComponent<NavMeshAgent>();
//        enemynavmeshagent.destination = GoOnPatrolPoint[0].transform.position;

//    }

//    // Update is called once per frame
//    void Update()
//    {

//        Collider[] Players = Physics.OverlapSphere(this.transform.position, 9);

//        if (Players != null)
//        {
//            foreach (Collider _AttackPlayer in Players)
//            {
//                if (_AttackPlayer.name != "humanoid_dying")
//                {
//                    IsAttack = false;
//                    continue;
//                }
//                if (_AttackPlayer.name == "humanoid_dying")
//                {
//                    IsAttack = true;
//                    StopCoroutine("ChangeDestination");
//                    distance = _AttackPlayer.gameObject;
//                    this.transform.LookAt(distance.transform.position);
//                }
//                if ((_AttackPlayer.transform.position - this.transform.position).magnitude < 1)
//                {
//                    EnemyAnimator.SetBool("Attack", true);
//                }
//                EnemyAnimator.SetBool("ToRun", true);
//                enemynavmeshagent.destination = _AttackPlayer.transform.position;
//            }
//            if (enemynavmeshagent.remainingDistance == 0 && startoroutine == false)
//            {
//                StartCoroutine("ChangeDestination");
//            }
//            if (distance != null && (distance.transform.position - this.transform.position).magnitude >= 10 && !IsAttack)
//            {
//                EnemyAnimator.SetBool("ToRun", false);
//                EnemyAnimator.SetBool("Attack", false);
//                enemynavmeshagent.destination = distancePosition;
//            }
//        }
//    }

//    IEnumerator ChangeDestination()
//    {
//        startoroutine = true;
//        EnemyAnimator.SetTrigger("Idle");

//        yield return new WaitForSeconds(EnemyAnimator.GetCurrentAnimatorStateInfo(0).length);

//        this.transform.Rotate(Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 180, 0), 0.3f));
//        enemynavmeshagent.destination = GoOnPatrolPoint[count % GoOnPatrolPoint.Length].transform.position;
//        count++;
//        distancePosition = enemynavmeshagent.destination;
//        startoroutine = false;
//    }
//}


//using UnityEngine;

//using System.Collections;



//public class Enimy : MonoBehaviour
//{



//     Use this for initialization

//    private Transform player;

//    public float attackDistance = 2;//这是攻击目标的距离，也是寻路的目标距离

//    private Animator animator;

//    public float speed;

//    private CharacterController cc;

//    public float attackTime = 3;   //设置定时器时间 3秒攻击一次

//    private float attackCounter = 0; //计时器变量

//    void Start()
//    {

//        player = GameObject.FindGameObjectWithTag("Player").transform;

//        cc = this.GetComponent<CharacterController>();

//        animator = this.GetComponent<Animator>();//控制动画状态机中的奔跑动作调用

//        attackCounter = attackTime;//一开始只要抵达目标立即攻击

//    }



//     //Update is called once per frame

//    void Update()
//    {



//        Vector3 targetPos = player.position;

//        targetPos.y = transform.position.y;//此处的作用将自身的Y轴值赋值给目标Y值

//        transform.LookAt(targetPos);//旋转的时候就保证已自己Y轴为轴心旋转

//        float distance = Vector3.Distance(targetPos, transform.position);

//        if (distance <= attackDistance)

//        {

//            attackCounter += Time.deltaTime;

//            if (attackCounter > attackTime)//定时器功能实现

//            {

//                int num = Random.Range(0, 2);//攻击动画有两种，此处就利用随机数（【0】，【1】）切换两种动画

//                if (num == 0) animator.SetTrigger("Attack1");

//                else animator.SetTrigger("Attack2");



//                attackCounter = 0;

//            }

//            else

//            {

//                animator.SetBool("Walk", false);



//            }

//        }

//        else

//        {

//            attackCounter = attackTime;//每次移动到最小攻击距离时就会立即攻击

//            if (animator.GetCurrentAnimatorStateInfo(0).IsName("EnimyWalk"))//EnimyWalk是动画状态机中的行走的状态

//                cc.SimpleMove(transform.forward * speed);

//            animator.SetBool("Walk ", true);//移动的时候播放跑步动画

//        }

//    }

//}
