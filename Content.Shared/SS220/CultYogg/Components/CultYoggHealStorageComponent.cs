// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt

using Robust.Shared.Serialization;

namespace Content.Shared.SS220.CultYogg.Components;

[RegisterComponent]
public sealed partial class CultYoggHealStorageComponent : Component
{
    [DataField]
    public EntityUid? InsertedEnt;


    [NetSerializable, Serializable]
    public enum CultYoggPodVisuals : byte
    {
        Base,
        Inserted
    }
}
