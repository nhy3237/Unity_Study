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
            Debug.Log(name + "는 Bet 없어서 하위 오브젝트에서 bet을 찾아 넣는다.");
            bet = GetComponentInChildren<Bet>();
            if(!bet)
            {
                Debug.LogError(name + "는 Bet 없다.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
