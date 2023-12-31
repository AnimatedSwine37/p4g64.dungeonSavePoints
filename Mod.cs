﻿using BF.File.Emulator.Interfaces;
using p4g64.dungeonSavePoints.Configuration;
using p4g64.dungeonSavePoints.NuGet.templates.defaultPlus;
using p4g64.dungeonSavePoints.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.IO;

namespace p4g64.dungeonSavePoints;
/// <summary>
/// Your mod logic goes here.
/// </summary>
public class Mod : ModBase // <= Do not Remove.
{
    /// <summary>
    /// Provides access to the mod loader API.
    /// </summary>
    private readonly IModLoader _modLoader;

    /// <summary>
    /// Provides access to the Reloaded.Hooks API.
    /// </summary>
    /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
    private readonly IReloadedHooks? _hooks;

    /// <summary>
    /// Provides access to the Reloaded logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Entry point into the mod, instance that created this class.
    /// </summary>
    private readonly IMod _owner;

    /// <summary>
    /// Provides access to this mod's configuration.
    /// </summary>
    private Config _configuration;

    /// <summary>
    /// The configuration of the currently executing mod.
    /// </summary>
    private readonly IModConfig _modConfig;

    public Mod(ModContext context)
    {
        _modLoader = context.ModLoader;
        _hooks = context.Hooks;
        _logger = context.Logger;
        _owner = context.Owner;
        _configuration = context.Configuration;
        _modConfig = context.ModConfig;

        Utils.Initialise(_logger);

        var bfEmulatorController = _modLoader.GetController<IBfEmulator>();
        if (bfEmulatorController == null || !bfEmulatorController.TryGetTarget(out var bfEmulator))
        {
            Utils.LogError($"Unable to get controller for BF Emulator, stuff won't work :(");
            return;
        }

        if (_configuration.ReturnToEntrance) return;

        // Make the butterfly only allow saving
        var modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId);
        var flowFile = Path.Combine(modDir, "BF","saveOnly.flow");

        for(int i = 23; i <= 30; i++)
        {
            bfEmulator.AddFile(flowFile, $"f0{i}.flow");
        }
    }

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        _configuration = configuration;
        _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}