using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingKnife : MonoBehaviour
{
    [SerializeField] GameObject Child;
    public float rotationSpeed; // ȸ�� �ӵ� ����
    public float activationDistance; // Ȱ��ȭ �Ÿ�
    float rotatedRange;
    public GameObject Enemy; // �� ������Ʈ
    public bool knifeon, knifeEnd, enemyTouched;

    public void Start()
    {
        rotatedRange = 0;
        knifeon = true;
        Child.GetComponent<TrailRenderer>().enabled = false;
    }
    private void Update()
    {
        if (knifeon && enemyTouched) //�ѹ����� ����, �ѹ����� �� �� ������� ��ٷȴٰ� �ٽ� ���ƾ� �Ѵ�.
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
        //���� ����
        Child.GetComponent<SpriteRenderer>().enabled = false;
        //Child.GetComponent<TrailRenderer>().enabled = false;

        //��Ÿ�� ��ٸ���
        yield return new WaitForSeconds(0.5f);
        //���� Ű��
        Child.GetComponent<SpriteRenderer>().enabled = true;
        //Child.GetComponent<TrailRenderer>().enabled = true;

        //���ݰ���
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