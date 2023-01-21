<!-- markdownlint-disable-next-line -->
<p align="center">
  <a href="#" rel="noopener" target="_blank"><img width="150" src="" alt="Inputter logo"></a>
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

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel efficitur enim. Donec lobortis nibh ac commodo viverra. Curabitur scelerisque mi nisi, ac fringilla ante porta quis. Morbi aliquam posuere mauris. Fusce condimentum est accumsan lorem sagittis convallis. Curabitur egestas, arcu vitae varius tempor, turpis libero aliquam nisi, et gravida leo urna non sem. In vulputate tincidunt lectus, eget blandit tortor. Morbi id luctus urna. Vestibulum in magna at metus ultricies vulputate. Ut ultricies hendrerit tortor sit amet fringilla. Nullam nec suscipit neque. Pellentesque in vulputate lectus.

Nunc consequat diam id turpis imperdiet, id tempus turpis dictum. Vestibulum non rhoncus orci, nec vestibulum elit. Vestibulum eu blandit erat. Duis porta ultrices tellus sit amet efficitur. Morbi dignissim justo pellentesque turpis elementum dapibus. Vivamus rutrum ligula et elementum viverra. Maecenas blandit varius purus a faucibus. Aenean leo tellus, lacinia et nisl sed, iaculis sodales ipsum. Aenean sollicitudin, libero ac viverra pellentesque, odio odio rhoncus turpis, eu mattis ligula dolor ut risus. Vivamus tincidunt nisl vitae nunc aliquet pulvinar ac quis nisi. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed pharetra lacus aliquet porttitor tempus.

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
