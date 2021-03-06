﻿using InventorySystem.Runtime.Scripts.Inventory.Slot;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace InventorySystem.Runtime.Scripts.Inventory.Components
{
	public class ItemDropBehaviour : MonoBehaviour
	{
		private SlotView _slotView;
		
		[Inject]
		void Construct(SlotView slotView)
		{
			_slotView = slotView;
		}
		
		void Start()
		{
			gameObject
				.AddComponent<ObservableDropTrigger>()
				.OnDropAsObservable()
				.Subscribe(OnDrop)
				.AddTo(this);
		}

		private void OnDrop(PointerEventData eventData)
		{
			// Debug.Log("On Drop");
			//
			 if (eventData.pointerDrag == null) return;
			 if (!eventData.pointerDrag.CompareTag("Item")) 
				 return;
			 // eventData.pointerDrag.transform.SetParent(transform, false);
			// 	
			// eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
			// 	GetComponent<RectTransform>().anchoredPosition;
		}
	}
}
