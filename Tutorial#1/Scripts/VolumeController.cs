using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeContorller : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;

    private void Awake()
    {
        slider.value = 1; 
    }

    private void Update()
    {
        VolumeContorl();
    }

    public void VolumeContorl()
    {
        audioSource.volume = slider.value;
        text.text = ((int)(slider.value * 100)).ToString();
    }
}
