using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    [SerializeField]
    int cash = 100;
    public int Cash { get { return cash; } private set { cash = value; } }

    [SerializeField]
    Bet bet;

    // Start is called before the first frame update
    void Start()
    {
        if(!bet)
        {
            Debug.Log(name + "�� Bet ��� ���� ������Ʈ���� bet�� ã�� �ִ´�.");
            bet = GetComponentInChildren<Bet>();
            if(!bet)
            {
                Debug.LogError(name + "�� Bet ����.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
