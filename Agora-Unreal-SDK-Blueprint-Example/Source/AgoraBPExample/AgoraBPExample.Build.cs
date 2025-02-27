// Copyright(c) 2024 Agora.io. All rights reserved.

using System.IO;
using System;
using UnrealBuildTool;

public class AgoraBPExample : ModuleRules
{
	public AgoraBPExample(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore","UMG"});

		PrivateDependencyModuleNames.AddRange(new string[] {  });

        // Uncomment if you are using Slate UI
        PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

        // Uncomment if you are using online features
        // PrivateDependencyModuleNames.Add("OnlineSubsystem");

        // To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true

        if (Target.Platform == UnrealTargetPlatform.Android)
        {
            PrivateDependencyModuleNames.AddRange(new string[] { "AndroidPermission" });
            string UPLFilePath = Path.Combine(ModuleDirectory, "UPL","AgoraExample_UPL_Android.xml");
            Console.WriteLine("AgoraExample UPL Path: " + UPLFilePath);
            // Modify AndroidMenifest.xml
            AdditionalPropertiesForReceipt.Add("AndroidPlugin", UPLFilePath);
        }

        if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            string UPLFilePath = Path.Combine(ModuleDirectory, "UPL","AgoraExample_UPL_IOS.xml");
            Console.WriteLine("AgoraExample IOS UPL Path: " + UPLFilePath);
            // Modify info.plist
            AdditionalPropertiesForReceipt.Add("IOSPlugin", UPLFilePath);
        }
    }
}
