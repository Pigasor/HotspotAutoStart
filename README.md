# HotspotAutoStart
A specialized Windows automation tool developed in C# (.NET 8) that programmatically enables the Mobile Hotspot at system boot bypassing the Windows lock screen.

HotspotAutoStart
A lightweight C# tool to automatically enable Windows Mobile Hotspot at boot, even before the user logs in.

Key Features:
Pre-Login Activation: Works on the Windows lock screen.
SYSTEM Account: Bypasses password prompts by running as a system service.
Smart Delay: Includes a 15-second delay to ensure hardware is ready.

How to Use:
Build: Compile the project using .NET 8.
Task Scheduler: Create a task triggered "At startup".
Privileges:
Select "Run whether user is logged on or not".
Set the user account to SYSTEM.

Tech Stack:
Language: C#
API: WinRT (NetworkOperatorTetheringManager)
