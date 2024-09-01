﻿using Content.Server.Popups;
using Content.Shared.SS220.CultYogg.Components;
using Robust.Server.GameObjects;
using Robust.Shared.Containers;
using Content.Shared.SS220.CultYogg.FungusMachineSystem;
using Content.Shared.UserInterface;

namespace Content.Server.SS220.CultYogg.Fungus.Systems
{
    public sealed class FungusMachineSystem : SharedFungusMachineSystem
    {
        [Dependency] private readonly UserInterfaceSystem _userInterfaceSystem = default!;
        [Dependency] private readonly SharedContainerSystem _containerSystem = default!;
        [Dependency] private readonly PopupSystem _popupSystem = default!;

        public override void Initialize()
        {
            base.Initialize();

            SubscribeLocalEvent<FungusMachineComponent, ActivatableUIOpenAttemptEvent>(OnAttemptOpenUI);
            Subs.BuiEvents<FungusMachineComponent>(FungusMachineUiKey.Key, subs =>
            {
                subs.Event<BoundUIOpenedEvent>(OnBoundUIOpened);
            });
        }

        private void OnAttemptOpenUI(Entity<FungusMachineComponent> ent, ref ActivatableUIOpenAttemptEvent args)
        {
            if (HasComp<MiGoComponent>(args.User))
                return;

            _popupSystem.PopupEntity(Loc.GetString("cult-yogg-buckle-attempt"), ent, args.User);
            args.Cancel();
        }

        protected override void OnComponentInit(EntityUid uid, FungusMachineComponent component, ComponentInit args)
        {
            base.OnComponentInit(uid, component, args);

            component.Container = _containerSystem.EnsureContainer<Container>(uid, FungusMachineComponent.ContainerId);
        }

        private void OnBoundUIOpened(EntityUid uid, FungusMachineComponent component, BoundUIOpenedEvent args)
        {
            UpdateFungusMachineInterfaceState(uid, component);
        }

        private void UpdateFungusMachineInterfaceState(EntityUid uid, FungusMachineComponent component)
        {
            var state = new FungusMachineInterfaceState(GetInventory(uid, component));

            _userInterfaceSystem.SetUiState(uid, FungusMachineUiKey.Key, state);
        }

        private FungusMachineInventoryEntry? GetEntry(EntityUid uid, string entryId, FungusMachineComponent? component = null)
        {
            if (!Resolve(uid, ref component))
                return null;

            return component.Inventory.GetValueOrDefault(entryId);
        }
    }
}

