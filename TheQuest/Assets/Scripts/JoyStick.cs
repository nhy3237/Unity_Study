using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform m_rectBack;
    RectTransform m_rectJoystick;

    Transform m_trPlayer;
    Transform m_trEnemy;

    float m_fRadius;
    float m_fSpeed = 5.0f;
    bool m_bTouch = false;
    bool m_bMoving = false;

    Vector3 m_targetPosition;

    void Start()
    {
        m_rectBack = transform.Find("JoystickBack").GetComponent<RectTransform>();
        m_rectJoystick = transform.Find("JoystickBack/Joystick").GetComponent<RectTransform>();

        m_trPlayer = GameObject.Find("Player").transform;
        m_trEnemy = GameObject.Find("Enemy").transform;

        // JoystickBackground�� �������Դϴ�.
        m_fRadius = m_rectBack.rect.width * 0.5f;

        m_targetPosition = m_trPlayer.position;
    }

    void Update()
    {
        if (m_bMoving)
        {
            m_trPlayer.position = Vector3.MoveTowards(m_trPlayer.position, m_targetPosition, m_fSpeed * Time.deltaTime);
            m_trEnemy.position = Vector3.MoveTowards(m_trEnemy.position, m_targetPosition, m_fSpeed * Time.deltaTime);
        }
    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2(vecTouch.x - m_rectBack.position.x, vecTouch.y - m_rectBack.position.y);

        // vec���� m_fRadius �̻��� ���� �ʵ��� �մϴ�.
        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        m_rectJoystick.localPosition = vec;

        // ���̽�ƽ ���� ���̽�ƽ���� �Ÿ� ������ �̵��մϴ�.
        float fSqr = (m_rectBack.position - m_rectJoystick.position).sqrMagnitude / (m_fRadius * m_fRadius);

        // �����̴� ������ ����ȭ
        Vector2 vecNormal = vec.normalized;

        m_bMoving = true;

        // ĳ������ ���� ��ġ�� ��ǥ ��ġ�� y���� 1�̰�, ���� ���� �ִ��� �˻��մϴ�.
        if (m_trPlayer.position.y == 1)
        {
            // �����¿� �������θ� �̵��ϵ��� ó��
            if (Mathf.Abs(vecNormal.x) > Mathf.Abs(vecNormal.y))
            {
                m_targetPosition = new Vector3(m_trPlayer.position.x + Mathf.Sign(vecNormal.x), 1f, m_trPlayer.position.z);
            }
            else
            {
                m_targetPosition = new Vector3(m_trPlayer.position.x, 1f, m_trPlayer.position.z + Mathf.Sign(vecNormal.y));
            }
        }
        else
        {
            m_targetPosition = new Vector3(m_trPlayer.position.x, m_trPlayer.position.y, m_trPlayer.position.z);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_rectJoystick.localPosition = Vector2.zero;
        m_bTouch = false;
        m_bMoving = false;
    }
}
