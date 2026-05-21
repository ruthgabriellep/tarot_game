using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{

    [Header("Menu Navigation")] [SerializeField]
    private SaveSlotsMenu saveSlotsMenu;
    
    [Header("Menu Buttons")] [SerializeField]
    private Button newGameButton;

    [SerializeField] private Button continueGameButton;

    [SerializeField] private Button loadGameButton;
    
    [SerializeField] private Vector3 spawnPositionInNextScene;
    
    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        // if (!DataPersistenceManager.instance.HasGameData())
        // {
        // }
        
        continueGameButton.interactable = false;
        loadGameButton.interactable = false;
    }

    public void OnNewGameClicked()
    {
        // saveSlotsMenu.ActivateMenu(false);
        // this.DeactivateMenu();
        
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        GameManager.Instance.savedPosition = spawnPositionInNextScene;
        GameManager.Instance.hasSavedPosition = true;
        SceneManager.LoadSceneAsync("Comic");
    }

    public void OnLoadGameClicked()
    {
        // saveSlotsMenu.ActivateMenu(true);
        // this.DeactivateMenu();
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        
        // DataPersistenceManager.instance.SaveGame();
        
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetLastSavedScene());
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
