using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lab1;
using UnityEngine.UI;

public class GameCenter : MonoBehaviour
{
    [SerializeField]
    Transform dogRoot;
    [SerializeField]
    Transform guyRoot;

    [SerializeField]
    Button buttonRace;

    [SerializeField]
    Transform panelBetting;

    enum Step
    {
        Betting,
        ReadyRace,
        StartRace,
        Racing,
        EndRace,
        ShowResult,
    }

    [SerializeField]
    Step currentStep;
    
    Guy[] guys = null;
    Dog[] dogs = null;

    // Start is called before the first frame update
    void Start()
    {
        if( !buttonRace)
        {
            Debug.LogError("레이스 버튼이 연결되지 않음.");
        }

        LoadGuys(guyRoot.childCount);
        LoadDogs(dogRoot.childCount);
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Z))
        {
            buttonRace.interactable = !buttonRace.interactable;
            Debug.Log("레이스 버튼이 토글됨 - 사용가능여부 " + buttonRace.interactable);
        }*/

       if(Input.GetKeyDown(KeyCode.S))
        {
            /*if (currentStep == Step.ShowResult)
                currentStep = Step.Betting;

            else
                currentStep += 1;*//*

            // 한 줄에 쓰기
            currentStep = (currentStep == Step.ShowResult) ? Step.Betting : currentStep + 1;*/

            NextStep();
        }
    }

    void LoadGuys(int count)
    {
        guys = new Guy[count];
        for (int i=0;i<count;i++)
        {
            guys[i] = guyRoot.transform.GetChild(i).GetComponent<Guy>();
            Debug.Log(guys[i].name + "읽었다.");
        }
    }

    void LoadDogs(int count)
    {
        dogs = new Dog[count];
        for (int i = 0; i < count; i++)
        {
            dogs[i] = dogRoot.transform.GetChild(i).GetComponent<Dog>();
            Debug.Log(dogs[i].name + "읽었다.");
        }
    }

    void NextStep()
    {
        Step preStep = currentStep;
        currentStep = (currentStep == Step.ShowResult) ? Step.Betting : currentStep + 1;

        switch (currentStep)
        {
            case Step.ReadyRace:
                {
                    buttonRace.interactable = true;
                }
                break;
            case Step.StartRace:
                {
                    buttonRace.interactable = false;
                }
                break;
            case Step.Racing:
                {

                }
                break;
        }
    }

    public void StartRace()
    {
        NextStep();

        Debug.Log("Start Race");

        for (int i = 0; i < dogs.Length; i++)
        {
            dogs[i].Run();
        }

        NextStep();
    }
    
    public void EndBet()
    {
        panelBetting.gameObject.SetActive(false);
        Debug.Log("End Bet");
     
        NextStep();
    }
}
