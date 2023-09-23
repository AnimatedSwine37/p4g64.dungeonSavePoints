using p4g64.dungeonSavePoints.Template.Configuration;
using System.ComponentModel;

namespace p4g64.dungeonSavePoints.Configuration;
public class Config : Configurable<Config>
{
    [DisplayName("Return To Entrance")]
    [Description("If enabled the save point will also let you return to the entrance.")]
    [DefaultValue(true)]
    public bool ReturnToEntrance { get; set; } = true;
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}