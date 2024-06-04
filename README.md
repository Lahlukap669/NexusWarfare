# Nexus Warfare
Objective : Defeat the waves using water turrets. Collect the coins dropped by dirty monsters and buy new water turrets to stack and upgrade them. Try surviving all the waves.


# Setup

How to set up the invironment and run the game in visual studio


## Install Latest Visual Studio Community (2022) With .NET8

Don't worry too much about .NET invironment since VS will install missing environments by itself


## Add Extention to Visual Studio

Go to manage extentions and under browse install extention MonoGame for C# (browse: MonoGame)


## Set the right settings to Build the App

Click on the Project Nexus Warfare and select properties. Select TargetedFramework to .NET 8.0, targetOS to Android, TargetOSVersion should be automaticly set to 34.0 and supportedOSVersion to 21.0. Change supportedOSVersion to 23.0


## Installing Android (Google Pixel 5 with API 34.0)

If we try to run the project the Android SDK Manager will open automaticly aksing you to create New Google Pixel 5 emulator. Confirm creation of Android SDK and after installation run the emulator. Once the emulator has been run, shut it down.


## Running the Game

All that is left to do is simply run the project and it should run the Game in the Android emulator.
