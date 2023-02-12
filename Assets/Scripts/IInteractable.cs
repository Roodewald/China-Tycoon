using UnityEngine;

namespace ToasterGames
{
	public interface IInteractable
	{
		void Interact()
		{
			UIManager.instance.Interact(true);
		}
	}
}

