# Inputter
Extension of Unity Logitech G29 SDK &amp; extra stuff for Unity Input System

# Intro

Inputter is a extensions of new input system for Unity with combination of Logitech G SDK. Inputter has a new input device called "LogitechG29" with all force feedback and all buttons/axis. 
This parsing system was built using [Logitech G SDK](https://www.logitechg.com/en-us/innovation/developer-lab.html).

# How To Use It:

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
