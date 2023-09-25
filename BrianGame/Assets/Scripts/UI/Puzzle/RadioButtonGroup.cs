using UnityEngine;
using UnityEngine.UI;

public class RadioButtonGroup : MonoBehaviour
{
    public Toggle[] toggleOptions;
    private int selectedIndex = 0; // Initialize to 0 to indicate the first button is selected by default.

    private void Start()
    {
        // Get all Toggle components within the group
        toggleOptions = GetComponentsInChildren<Toggle>();

        // Attach an event listener to each toggle, including the first one
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            int index = i; // Capture the current index in the closure
            toggleOptions[i].isOn = false;
            toggleOptions[i].onValueChanged.AddListener((value) => OnToggleValueChanged(index, value));

        }

        // Enable the first toggle by default
        toggleOptions[0].isOn = true;
    }

    void OnToggleValueChanged(int index, bool newValue)
    {
        if (newValue)
        {
            selectedIndex = index;
            // Uncheck all other toggles except the selected one
            for (int i = 0; i < toggleOptions.Length; i++)
            {
                if (i != index)
                {
                    toggleOptions[i].isOn = false;
                }
            }
        }
        else if (index == selectedIndex)
        {
            // If the first toggle is clicked and turned off, turn it back on
            toggleOptions[index].isOn = true;
        }
    }

    // A public method to get the index of the selected button
    public int GetSelectedIndex()
    {
        return selectedIndex;
    }
}
