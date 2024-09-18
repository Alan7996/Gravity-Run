using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public static OptionManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<OptionManager>();
            }
            return m_instance;
        }
    }

    private static OptionManager m_instance;

    public GameObject objectMainUIBundle;
    public GameObject panelOptions;
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        panelOptions.SetActive(false);
        if (PlayerPrefs.HasKey("Volume"))
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        else
            volumeSlider.value = 1.0f;
    }

    public void onClickOptionsBtn() {
        GameManager.instance.GamePause();
    }

    public void OpenCloseOptions() {
        if (panelOptions.activeSelf) {
            if (objectMainUIBundle)
                objectMainUIBundle.SetActive(true);
            panelOptions.SetActive(false);
        } else {
            if (objectMainUIBundle)
                objectMainUIBundle.SetActive(false);
            panelOptions.SetActive(true);
        }
    }

    public void ChangeVolume() {
        SoundManager.instance.UpdateVolume(volumeSlider.value);
    }
}
