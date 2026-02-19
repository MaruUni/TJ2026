using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneButton : BaseButton
{
    [SerializeField] SceneName nextSceneName;

    override protected void OnClick()
    {
        SceneManager.LoadScene(nextSceneName.ToString(), LoadSceneMode.Single);
    }
}