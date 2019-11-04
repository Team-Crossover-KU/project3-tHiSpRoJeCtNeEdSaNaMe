using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
*  @class description: RestartGame Contains scene management reloading command.
*  @libraries cited: UnityEngine.SceneManagement library was used for the Sceen Manager to reload the game scene.
*/
public class RestartGame : MonoBehaviour
{
    public UnityEngine.UI.Button button;

    /**
    * @pre Start is called before the first frame update.
    * @post Event listener is added to button.
    * @param None.
    * @return None.
    */
    void Start()
    {
        button.onClick.AddListener(Restart);
    }

    /**
    * @pre Restart method will listen for the button onClick event.
    * @post Restart method will reload the scene.
    * @param None.
    * @return None.
    */
    public void Restart()
    {
        /**
        * The line of code for the Restart() function can be found in the Unity Answer Forum: https://answers.unity.com/questions/46918/reload-scene-when-dead.html
        */
        Debug.Log("Restart Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
