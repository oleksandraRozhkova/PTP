using System;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core
{
    public class ApplicationManager
    {

        // Начало этого кода => переход на OnSceneLoaded
        static ApplicationManager()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // Переход после OnMainMenuLoaded 
        public static void StartGame()
        {
            SceneManager.UnloadSceneAsync(ScenesConfig.MainMenuScene);
            SceneManager.LoadSceneAsync(ScenesConfig.LevelsMenu, LoadSceneMode.Additive);
        }

        // Переход от OnLevelsMenuLoaded через OnBackToMainMenuGamePressed к OpenMainMenu
        public static void OpenMainMenu()
        {
            SceneManager.LoadScene(ScenesConfig.MainMenuScene, LoadSceneMode.Additive);
        }

        // Переход от OnLevelsMenuLoaded через OnLevel1ButtonPressed к OpenLevel1
        public static void OpenLevel1()
        {
            SceneManager.LoadSceneAsync(ScenesConfig.GameLevel01, LoadSceneMode.Additive);
        }

        // Прееход от OnGameLevel01Loaded через OnPauseButtonPressed к PauseMenu
        public static void OpenPauseMenu()
        {
            
            SceneManager.LoadSceneAsync(ScenesConfig.PauseMenu, LoadSceneMode.Additive);
        }


        // Проверка, смотря какая сцена loaded(Первая MainMenuScene), переходим на ButtonsToDo Function этой сцены
        private static void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            switch (scene.name)
            {
                case ScenesConfig.MainMenuScene:
                    var controllerGameOgject = scene.GetRootGameObjects()[0];
                    var mainMenuView = controllerGameOgject.GetComponent<IMainMenuView>();

                    OnMainMenuLoaded(mainMenuView);
                    break;

                case ScenesConfig.LevelsMenu:
                    var controllerLevelsMenuObject = scene.GetRootGameObjects()[0];
                    var levelsMenuView = controllerLevelsMenuObject.GetComponent<ILevelsMenuView>();

                    OnLevelsMenuLoaded(levelsMenuView);
                    break;

                case ScenesConfig.GameLevel01:
                    var controllerGameLevel01Object = scene.GetRootGameObjects()[0];
                    var pauseButtonView = controllerGameLevel01Object.GetComponent<IPauseButttonView>();

                    OnGameLevel01Loaded(pauseButtonView);
                    break;

                case ScenesConfig.PauseMenu:
                    var controllerPauseMenuObject = scene.GetRootGameObjects()[0];
                    var pauseMenuView = controllerPauseMenuObject.GetComponent<IPauseMenuView>();

                    OnPauseManuLoaded(pauseMenuView);
                    break;
            }
        }

        // Main Menu ButtonsToDo Function
        private static void OnMainMenuLoaded(IMainMenuView mainMenuview)
        {
            mainMenuview.OnStartGameButtonPressed += StartGame;
        }

        //Levels Menu ButtonsToDO Function
        private static void OnLevelsMenuLoaded(ILevelsMenuView levelsMenuView)
        {
            levelsMenuView.OnBackToMainMenuGamePressed += () =>
            {
                
                SceneManager.UnloadSceneAsync(ScenesConfig.LevelsMenu);
                OpenMainMenu();
            };

            levelsMenuView.OnLevel1ButtonPressed += () =>
            {
                
                SceneManager.UnloadSceneAsync(ScenesConfig.LevelsMenu);

                OpenLevel1();
            };
        }

        // In GameLevel01 is PauseButton, below is what that button do
        private static void OnGameLevel01Loaded(IPauseButttonView gameLevel01View)
        {

            gameLevel01View.OnPauseButtonPressed += () =>
            {
                Time.timeScale = 0f;

                OpenPauseMenu();
            };
        }

        // Pause Menu ButtonsToDo Functions
        private static void OnPauseManuLoaded(IPauseMenuView pauseMenuView)
        {

            pauseMenuView.OnBackToGameButtonPressed += () =>
            {
                Time.timeScale = 1f;

                SceneManager.UnloadSceneAsync(ScenesConfig.PauseMenu);
            };

            pauseMenuView.OnMainManuButtonPressed += () =>
            {
                Time.timeScale = 1f;
                SceneManager.UnloadSceneAsync(ScenesConfig.GameLevel01);
                SceneManager.UnloadSceneAsync(ScenesConfig.PauseMenu);

                OpenMainMenu();
            };
        }

    }
}
