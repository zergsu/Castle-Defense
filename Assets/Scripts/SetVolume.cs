using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {
	[SerializeField] AudioMixer mixer;
	float sliderValue = 0.5f;

	private void Start() {
		sliderValue = gameObject.GetComponent<Slider>().value;
	}

	public void SetLevel() {
		mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
	}
}
