using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

#region Script Details
/*
 0. STARTUP - serves as a load point for game initialization. Autoloads Title screen
 1. TITLE - Contains splash animation and start screen. Pressing start transitions to next state
 2. GAME - Gameplay
 4. MENU - Pause game when entering menu. Unpause on exit.
 5. QUIT - Bring up a menu asking if play wants to quit. Selecting yes exits application
*/
#endregion

public class GameStateManager : Singleton<GameStateManager>
{
    private enum GameState { STARTUP, TITLE, GAME, CUT, QUIT };
    private GameState game_state;
    private GameState current_game_state;
    private bool can_open_menu = true;

    public override void Awake() {
        base.Awake();
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            game_state = GameState.STARTUP;
            current_game_state = game_state;
            StartCoroutine(Startup());
        } else {
            game_state = current_game_state;
            current_game_state = game_state;
        }
    }

    // STATE METHODS //////////////////////////////////////////////////////////

    IEnumerator Startup() {
        yield return new WaitForSeconds(2.5f);
        game_state = GameState.STARTUP;
        StartCoroutine(Title());
    }

    IEnumerator Title() {
        yield return new WaitForSeconds(1.5f);
        game_state = GameState.TITLE;
        StartCoroutine(TransitionScene(1));
    }

    IEnumerator Game() {
        yield return null;
        StartCoroutine(TransitionScene(2));
    }

    IEnumerator Cut() {
        yield return null;
        StartCoroutine(TransitionScene(4));
    }

    IEnumerator Quit() {
        yield return new WaitForSeconds(1.5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    /////////////////////////////////////////////////////////////////////////

    public void QuitGame() {
        game_state = GameState.QUIT;
    }

    /////////////////////////////////////////////////////////////////////////

    IEnumerator TransitionScene(int scene) {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }

    private void GameStateChanged() {
        switch (game_state) {
            case GameState.STARTUP:
                StartCoroutine(Startup());
                break;
            case GameState.TITLE:
                StartCoroutine(Title());
                break;
            case GameState.GAME:
                StartCoroutine(Game());
                break;           
            case GameState.CUT:
                StartCoroutine(Cut());
                break;
            case GameState.QUIT:
                StartCoroutine(Quit());
                break;
        }
    }

    public void ChangeState(int state) {
        switch (state) {
            case 0:
                game_state = GameState.STARTUP;
                break;
            case 1:
                game_state = GameState.TITLE;
                break;
            case 2:
                game_state = GameState.GAME;
                break;           
            case 3:
                game_state = GameState.CUT;
                break;
            case 4:
                game_state = GameState.QUIT;
                break;
        }
    }

    private void CheckState() {
        if (current_game_state != game_state) {
            Debug.Log("< Game State Has Changed > Previous:  " + current_game_state + " Current: " + game_state);
            current_game_state = game_state;
            GameStateChanged();
        }
    }

    void Update() {
        CheckState();
    }
}
