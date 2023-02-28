using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

namespace ToasterGames
{
	public class UIMoneyPanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text moneyText;
		[SerializeField] private TMP_Text diamondsText;

		public void AddMoney(int addedMoney)
		{
			string change = addedMoney.ToString();
			if (addedMoney > 10000)
			{
				change = $"{addedMoney/1000f}K ";
			}
			moneyText.text = change;
		}
		public void AddDiamonds(int change)
		{
			diamondsText.text = change.ToString();
		}
	}

}