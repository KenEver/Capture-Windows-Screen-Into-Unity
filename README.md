# Capture-Windows-Screen-Into-Unity
 
*This project uses unity `2020.3.35f1` while developing.

*It only supports Windows(including Windows 11) because the application would call  the functions provided by `system32.dll`.

![image](https://github.com/KenEver/Unity-Screen-Reader-From-Windows-Application-To-VR-Environment/blob/main/Screenshot.jpg)

# Feature
- The displayed screen of the player's monitor would be casted to the raw image object in the game. The main program for controlling the raw image is`Assets/recorder.cs`. 
- As the project is for VR environments, it originally supports VR control by XR Rig Plugin.

# Player Control(For keyboard and Mouse)
- Control movement by `W`,`A`,`S`,`D` keyDown.
- Rotate the camera by mouse.

# Problem
- Calling the functions provided by `system32.dll` delays the speed of `void Update()`, so the FPS of the raw picture is low.
- There are memory allocation errors although it does not affect all functions.
