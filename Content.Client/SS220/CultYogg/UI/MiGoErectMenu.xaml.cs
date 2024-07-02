using Content.Client.UserInterface.Controls;
using Content.Shared.Silicons.Laws.Components;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.SS220.CultYogg.Ui;

[GenerateTypedNameReferences]
public sealed partial class MiGoErectMenu : FancyWindow
{
    public SiliconLawMenu()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);
    }

    public void Update(EntityUid uid, MiGoErectBuiState state)
    {
        state.Laws.Sort();
        LawDisplayContainer.Children.Clear();

        foreach (var law in state.Laws)
        {
            var control = new LawDisplay(uid, law, state.RadioChannels);

            LawDisplayContainer.AddChild(control);
        }
    }
}
