<!-- markdownlint-disable-next-line -->
<p align="center">
  <a href="#" rel="noopener" target="_blank"><img width="150" src="Resources/UnityInputter_128x128.png" alt="Inputter logo"></a>
</p>

<h1 align="center">Inputter [Unity Engine]</h1>

*Extension tool for the Unity Input System that adds support for the Logitech G29 steering wheel and provides additional functionality for handling input. This tool is designed to enhance the Unity Input System with new features and capabilities, making it easier to work with input devices and manage user interactions in your games and applications.*

<div align="center">
  
[![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/mrrobinofficial/unity-inputter/blob/HEAD/LICENSE.txt)

</div>

## Introduction

Inputter is a extensions of new input system for Unity with combination of Logitech G SDK. Inputter has a new input device called "LogitechG29" with all force feedback and all buttons/axis. 
This parsing system was built using [Logitech G SDK](https://www.logitechg.com/en-us/innovation/developer-lab.html).

## Installation

* [Add package](https://docs.unity3d.com/Manual/upm-ui-giturl.html) from this git URL: ```com.mrrobin.inputter``` or https://github.com/MrRobinOfficial/Unity-Inputter.git

Or

* Clone repo and extract to your Unity project folder.

## Quick guide

```c#
using Inputter;
```
To access Logitech G29 SDK stuff, just access LogitechG29 input device instead 
```c#
const float MIN_RPM = 0f;
const float MAX_RPM = 15000f;

float throttleInput = 0.5f;

LogitechG29.current.PlayLeds(throttleInput * MAX_RPM, MIN_RPM, MAX_RPM);
```
For button check, simple use [indexer](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/) to get ButtonControl
```c#
int speedLimiter = 0;

if (LogitechG29.current[LogitechG29.G29Button.Plus].wasReleasedThisFrame)
    speedLimiter++;
    
if (LogitechG29.current[LogitechG29.G29Button.Minus].wasReleasedThisFrame)
    speedLimiter--;
```
