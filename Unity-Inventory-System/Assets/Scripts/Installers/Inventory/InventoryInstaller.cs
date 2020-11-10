using Assets.Scripts.Core.ViewModels;
using UnityEngine;
using UnityInventorySystem.Inventory;
using Zenject;

namespace UnityInventorySystem.Installers
{
	public class InventoryInstaller : Installer<int, InventoryInstaller>
	{
		private readonly int _slotsCount;
		public InventoryInstaller(
			[InjectOptional]
			int slotsCount)
		{
			_slotsCount = slotsCount;
		}
		
		public override void InstallBindings()
		{
			Container
				.Bind<Transform>()
				.FromComponentOnRoot();

			Container
				.BindInterfacesAndSelfTo<InventoryFacade>()
				.AsSingle();

			Container
				.BindFactory<Item, ItemBehaviour, ItemBehaviour.Factory>()
				.FromMonoPoolableMemoryPool(x => 
					x
						.WithInitialSize(3)
						.FromNewComponentOnNewPrefabResource("Prefabs/Inventories/Item")
						.WithGameObjectName("Item"));
			
			Container
				.Bind<SlotsFacadePoolBehaviour>()
				.ToSelf()
				.AsSingle();

			Container
				.BindFactory<SlotFacade, SlotFacade.Factory>()
				.FromPoolableMemoryPool(x =>
					x
						.WithInitialSize(25)
						.ExpandByDoubling()
						.FromSubContainerResolve()
						.ByNewPrefabInstaller<SlotInstaller>(Resources.Load<GameObject>("Prefabs/Inventories/ItemSlot"))
						.WithGameObjectName("ItemSlot"));
				
			Container
				.Bind<ItemPoolBehaviour>()
				.ToSelf()
				.AsSingle();

			Container
				.BindInterfacesAndSelfTo<InventoryBehaviour>()
				.AsSingle();

			Container
				.BindInstance(_slotsCount)
				.WhenInjectedInto<InventoryViewModel>();
			
			Container
				.BindInterfacesAndSelfTo<InventoryViewModel>()
				.AsSingle();
		}
	}
}