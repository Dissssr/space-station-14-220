using Robust.Shared.GameStates;
using System.Text.Json.Serialization;
using Content.Shared.Damage;

namespace Content.Shared.SS220.CultYogg.Components;

[RegisterComponent, NetworkedComponent]
public sealed partial class MiGoHealComponent : Component
{
    public float TimeBetweenIncidents = 10;//ToDo tweak this parameter

    public float NextIncidentTime;


    //copypaste=rename
    [DataField(required: true)]
    [JsonPropertyName("damage")]
    public DamageSpecifier Damage = default!;
}
