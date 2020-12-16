using InventorySystem.Runtime.Scripts.Core.Models.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventorySystem.Runtime.Scripts.Inventory.Tooltip
{
	public class TooltipView : MonoBehaviour
	{
		private IItem _item;
		
		[Inject]
		void Construct(IItem item)
		{
			_item = item;
		}

		public void Prepare(IItem item)
		{
			_item = item;
			
			Start();
		}

		void Start()
		{
			gameObject.GetComponent<Image>().color = _item?.Color ?? Color.white;
		}


		public class Factory : PlaceholderFactory<IItem, TooltipView>{}
	}
}