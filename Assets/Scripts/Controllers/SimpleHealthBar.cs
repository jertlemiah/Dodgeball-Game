using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
	public Slider slider;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

    public void SetHealth(int health)
	{
          Debug.Log("update slider");
		slider.value = health;
          Debug.Log(slider.value);
	}
}
