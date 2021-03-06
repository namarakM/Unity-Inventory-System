﻿using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InventorySystem.Runtime.Scripts.Core.Models.Interfaces
{
	public interface ISlotFacade : IDisposable
	{
		Transform Transform { get; }
		
		bool Empty { get; }
		
		bool Selected { get;}

		void SetEmpty();

		void AddItemToSlot(IItemFacade item);

		void AddItemsToSlot(IEnumerable<IItemFacade> items);

		void SetSelected(bool value);
		
		void ClearItems();

		void FillSlotBackground();
		
		IReactiveCollection<IItemFacade> AllItemsInSlot { get; }
	}
}