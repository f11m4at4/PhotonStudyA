using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//��, CharacterController�� ���

public class PlayerMove : MonoBehaviour
{
    //�ӷ�
    public float moveSpeed = 5;
    //characterController ���� ����
    CharacterController cc;

    //�߷�
    float gravity = -9.81f;
    //�����Ŀ�
    public float jumpPower = 5;
    //y���� �ӷ�
    float yVelocity;


    void Start()
    {
        //characterController �� ����
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // WSAD�� ������ ��,��,��,��� �̵�
        //1. WSAD�� ��ȣ�� ����.
        float h = Input.GetAxisRaw("Horizontal"); //A : -1, D : 1, ������ ������ : 0
        float v = Input.GetAxisRaw("Vertical");

        //2. ���� ��ȣ�� ������ �����.
        Vector3 dir = transform.forward * v + transform.right * h; // new Vector3(h, 0, v);
        //������ ũ�⸦ 1���Ѵ�.
        dir.Normalize();

        //���࿡ �ٴڿ� ����ִٸ� yVelocity�� 0���� ����
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        //���࿡ �����̹�(Jump)�� ������
        if (Input.GetButtonDown("Jump"))
        {
            //yVelocity�� jumpPower�� ����
            yVelocity = jumpPower;
        }      

        //yVelocity���� �߷����� ���ҽ�Ų��.
        yVelocity += gravity * Time.deltaTime;

        //dir.y�� yVelocity���� ����
        dir.y = yVelocity;

        //3. �� �������� ��������.
        //P = P0 + vt
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}