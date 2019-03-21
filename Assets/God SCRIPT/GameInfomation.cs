using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameInfo
{
    public class GameInfomation : MonoBehaviour
    {
        private void Awake()
        {
            GameInfomation[] instances = FindObjectsOfType<GameInfomation>();
            if (instances.Length > 1) Destroy(this.gameObject);
            else
            {
                if (IsContinueGame) ContinueGame();
                else StartNewGame();
            } 
        }
        //以下是保存与读取数据关键
        private Vector3 characterPosition = new Vector3(535, 44, 471);
        private int RPG_Action = 0;
        [SerializeField]
        private bool IsContinueGame = false;
        // Use this for initialization
        public Vector3 CharacterPosition
        {
            get
            {
                return characterPosition;
            }
            set
            {
                characterPosition = value;
            }
        }
        public int RPGAction
        {
            get
            {
                return RPG_Action;
            }
            set
            {
                RPG_Action = value;
            }
        }
        private AsyncOperation _asyncOperation;
        //
        private enum characterVector { x = 1, y = 2, z = 3 }
        private string rpgCheckPosition = "rpgguanka";
        //
        public void SaveScenceInformation(int SceneId)
        {
            CharacterPosition = GameObject.Find("character").transform.position;
            SceneManager.LoadSceneAsync(SceneId);
        }
        public void LoadScenceInfomation()
        {
            _asyncOperation = SceneManager.LoadSceneAsync(2);
        }
        public void ResetScence()
        {
            GameObject.Find("character").transform.position = CharacterPosition;
        }
        //提供从外部数据进入游戏
        private void ReadGameInfoFromDataBase()
        {
            
            CharacterPosition = new Vector3(PlayerPrefs.GetFloat(characterVector.x.ToString()),
                                            PlayerPrefs.GetFloat(characterVector.y.ToString()),
                                            PlayerPrefs.GetFloat(characterVector.z.ToString()));
            RPGAction = PlayerPrefs.GetInt(rpgCheckPosition);

            GameObject.Find("Flowchart-1").GetComponent<Flowchart>().SetIntegerVariable("Change",RPGAction);
        }
        private void SaveGameInfoToDataBase()
        {
            characterPosition = GameObject.Find("character").transform.position;
            PlayerPrefs.SetFloat(characterVector.x.ToString(), characterPosition.x);
            PlayerPrefs.SetFloat(characterVector.y.ToString(), characterPosition.y);
            PlayerPrefs.SetFloat(characterVector.z.ToString(), characterPosition.z);
            PlayerPrefs.SetInt(rpgCheckPosition, GameObject.Find("Flowchart-1").GetComponent<Flowchart>().GetIntegerVariable("Change"));
            PlayerPrefs.Save();
        }
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                SaveGameInfoToDataBase();
            }
        }
        private void StartNewGame()
        {
            DontDestroyOnLoad(this.gameObject);
            characterPosition = new Vector3(535, 44, 471);
        }
        private void ContinueGame()
        {
            ReadGameInfoFromDataBase();
            DontDestroyOnLoad(this.gameObject);
        }
    }

}