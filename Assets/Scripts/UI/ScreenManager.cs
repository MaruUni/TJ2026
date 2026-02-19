using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for managing all screens under the same canvas
/// <para> A screen is defined as a child object on a canvas that has all the information that needs to be displayed at a certain moment (and has a component with the IScreen interface)  </para>
/// <para> The screen manager has a dictionary to all the screens under the canvas, and is be able to switch between them by their name </para>
/// <para> Explore BaseButton class and its children (specially SwitchScreenButton) if you want to know more about how to use this to change between screens</para>
/// </summary>
public class ScreenManager : MonoBehaviour
{

    [SerializeField] private ScreenName _firstShownScreenName; // the screen that will first be visible on the canvas when the scene starts
    private IDictionary<string, IScreen> _screens;
    private IScreen _currentScreen;
    private IScreen _previousScreen; // if a more complex logic was needed to go through multiple previous screens, we could use a stack

    /// <summary>
    /// Enables all screens on Awake so they can be initialized
    /// </summary>
    private void Awake()
    {
        IScreen[] screensUnderManager = GetComponentsInChildren<IScreen>(true);

        foreach (IScreen screen in screensUnderManager)
        {
            screen.Show();
        }
    }

    /// <summary>
    /// Hides all screens on Start and stores them in a dictionary for easy access, then shows the first screen defined on the inspector
    /// </summary>

    private void Start() // some things need to go before
    {
        // store all the screens (even the inactive ones) in a dictionary
        _screens = new Dictionary<string, IScreen>();
        IScreen[] screensUnderManager = GetComponentsInChildren<IScreen>(true);

        foreach (IScreen screen in screensUnderManager)
        {
            screen.Hide();
            _screens.Add(screen.GetName(), screen);
        }

        SwitchScreen(_firstShownScreenName.ToString()); // show the first screen
    }

    public void SwitchScreen(string screenName)
    {
        // try to find the screen by its name on the dictionary
        IScreen screenToSwitch;
        bool foundScreen = _screens.TryGetValue(screenName, out screenToSwitch);

        if (!foundScreen)
        {
            return; // if the screen wasn't found, return without switching
        }

        SwitchScreen(screenToSwitch); // else, call method that switches the given screen
    }

    private void SwitchScreen(IScreen newScreen)
    {
        if (_currentScreen != null) // if there's a screen showing at the moment of the change hide it and store it as the previous screen
        {
            _currentScreen.Hide();
            _previousScreen = _currentScreen;
        }

        _currentScreen = newScreen;
        _currentScreen.Show();
    }

    public void SwitchToPreviousScreen()
    {
        if (_previousScreen != null)
        {
            SwitchScreen(_previousScreen);
        }
    }

    public string GetCurrentScreen()
    {
        return _currentScreen.GetName();
    }
}
