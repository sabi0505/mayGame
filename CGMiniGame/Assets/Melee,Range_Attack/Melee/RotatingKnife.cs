using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingKnife : MonoBehaviour
{
    [SerializeField] GameObject Child;
    public float rotationSpeed; // 회전 속도 조절
    public float activationDistance; // 활성화 거리
    float rotatedRange;
    public GameObject Enemy; // 적 오브젝트
    public bool knifeon, knifeEnd, enemyTouched;

    public void Start()
    {
        rotatedRange = 0;
        knifeon = true;
        Child.GetComponent<TrailRenderer>().enabled = false;
    }
    private void Update()
    {
        if (knifeon && enemyTouched) //한바퀴를 돌되, 한바퀴를 돈 후 어느정도 기다렸다가 다시 돌아야 한다.
        {
            Child.GetComponent<TrailRenderer>().enabled = true;
            transform.Rotate(new Vector3(0, 0, 30), rotationSpeed);
            rotatedRange += rotationSpeed;
            if (rotatedRange >= 360)
            {
                knifeon = false;
                StartCoroutine(knifeCool());
                rotatedRange = 0;
                enemyTouched = false;
                Child.GetComponent<TrailRenderer>().enabled = false;
            }
        }

    }

    IEnumerator knifeCool()
    {
        //외형 끄기
        Child.GetComponent<SpriteRenderer>().enabled = false;
        //Child.GetComponent<TrailRenderer>().enabled = false;

        //쿨타임 기다리기
        yield return new WaitForSeconds(0.5f);
        //외형 키기
        Child.GetComponent<SpriteRenderer>().enabled = true;
        //Child.GetComponent<TrailRenderer>().enabled = true;

        //공격가능
        knifeon = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        enemyTouched = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (rotatedRange >= 360)
            enemyTouched = false;
    }
}

/*
public class RotatingKnife : MonoBehaviour
{
   
    // Start is called before the first frame update

    public float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,30), rotationSpeed * Time.deltaTime);
    }
    
}
*/