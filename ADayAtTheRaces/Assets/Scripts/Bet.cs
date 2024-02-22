using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Bet : MonoBehaviour
{
    int dogID;
    int amount;

    public void SetBetting(int dogID, int amount)
    {
        this.dogID = dogID;
        this.amount = amount;
    }

    public string GetDescription()
    {
        // ���� �۸��� 1������ 100�޷��� �����߽��ϴ�.
        StringBuilder sb = new StringBuilder();
        sb.Append(transform.parent.name);
        sb.Append("�� �۸��� ");
        sb.Append(dogID);
        sb.Append(amount);
        sb.Append("�޷��� �����߽��ϴ�.");

        return sb.ToString();
    }
}
