using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ToasterGames
{
	public class UIManager : MonoBehaviour
	{
		[HideInInspector] public static UIManager instance;

		[Header("Fields")]
		[SerializeField] private UIDocument moneyRoot;
		[SerializeField] private UIDocument mainRoot;

		[Header("Sources")]
		[SerializeField] private VisualTreeAsset main;
		[SerializeField] private VisualTreeAsset interact;




		private void OnEnable()
		{
			instance = this;

			Button butonCart = moneyRoot.rootVisualElement.Q<Button>();

			butonCart.clicked += () => Debug.Log("Cliked");
		}

		public void Interact(bool setActive)
		{
			if (setActive)
			{
				mainRoot.visualTreeAsset = interact;
			}
			else
			{
				mainRoot.visualTreeAsset = main;
			}
		}
	}
}