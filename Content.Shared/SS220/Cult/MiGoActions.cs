// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt
using Content.Shared.Actions;
using Content.Shared.DoAfter;
using Robust.Shared.Serialization;

namespace Content.Shared.SS220.Cult;
public sealed partial class MiGoEnslavementEvent : EntityTargetActionEvent
{
}

[Serializable, NetSerializable]
public sealed partial class MiGoEnslavetDoAfterEvent : SimpleDoAfterEvent
{
}

public sealed partial class MiGoHealEvent : EntityTargetActionEvent
{
}

public sealed partial class MiGoAstralEvent : InstantActionEvent
{
}

public sealed partial class MiGoErectEvent : InstantActionEvent
{
}

public sealed partial class MiGoSacrificeEvent : InstantActionEvent
{
}
/// <summary>
/// Called after all checks for enslavement happened and DoAfter completed
/// </summary>
[ByRefEvent]
public readonly struct MiGoEnslaveCompleteEvent
{
    public readonly EntityUid Target;
    public readonly EntityUid? User;

    public MiGoEnslaveCompleteEvent(EntityUid target, EntityUid? user)
    {
        Target = target;
        User = user;
    }
}
