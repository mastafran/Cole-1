using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void OnButtonPress() {
        GameStateManager.Instance.ChangeState(2);
    }
}
