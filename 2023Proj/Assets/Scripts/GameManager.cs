using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << :

public class GameManager : MonoBehaviour
{
    private static GameManager sInstance;

    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
            }

            return sInstance;
        }

    }
    
    public int changeScene = 0;

    /*struct PlayerInfo
    {
        private string userID;
        private int Gold;
        private int HP;
    }*/

    private int score = 0;
    private int hp = 100;

    private bool hasItem = true;

    private void Awake() // 싱글톤이기 때문에 필요함
    {
        if(sInstance != null && sInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sInstance = this;

        DontDestroyOnLoad(this.gameObject); // 게임 실행 중에는 삭제 하지 않는다.
    }

   public void ChangeScene()
    {
        int sceneIndex = changeScene++ % 2;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetHP(int newHP)
    {
        hp = newHP;
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetHasItem(bool curHasItem)
    {
        hasItem = curHasItem;
    }

    public bool GetHasItem()
    {
        return hasItem;
    }

    public string nextSceneName;
}
