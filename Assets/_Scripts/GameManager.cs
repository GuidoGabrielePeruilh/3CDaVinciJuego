using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        void Awake()
        {
            if (Instance == null)
            {
                var gameManager = FindObjectOfType<GameManager>();
                if (gameManager)
                {
                    Instance = gameManager;
                }
                else
                {
                    Instance = this;
                }
            }
            Destroy(this);
        }
        
        public void NewGame()
        {
            //pasar a la escena de juego. 4

        }
        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        
        }
        public void Resume()
        {
            //Quitar el menu pausa y hacer el timenose 1;  4
        
        }
        public void RestartLevel()
        {
            //NewGame(); 4
        
        }
        public void BackToMainMenu()
        {
            //pasar a la escena del Menu principal 4
        
        }
    }
}
