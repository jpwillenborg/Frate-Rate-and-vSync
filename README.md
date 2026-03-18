# Frame-Rate-and-vSync
Frame rate controller with optional vSync count in Unity
<br><br>

![Project Image](<./.gitimages/Frame Rate and vSync 01.png>)
<br><br>

## Project Description
This is an example relating to frame rates and screen refreshes between frames. By default, the project's vSync count (number of refreshes) is set to 0. This allows you to adjust the frame rate to whichever value you like, up to your display's maximum refresh rate. For example, if your display's maximum refresh rate is capped at 60 Hz, setting the frame rate to 120 will still result in 60 FPS.
<br>

When adjusting the vSync count to anything higher than 0, setting the target frame rate then becomes dependent on the display's maximum refresh rate divided by the number of vSync counts. So for example, if your display's maximum refresh rate is 60 Hz and you set the vSync count to 2, this effectively results in a frame rate of 30 FPS.
<br>

Note: Some assets from the Unity Asset Store are required for a complete build. They are not included in this repo. Please see the Licenses section below for links to the assets. Otherwise, feel free to browse through the project files. Thanks.
<br><br>

## Project Features
* Adjustable Frame Rate
* Adjustable vSync Count 
* Framerate counter
<br><br>

## Licenses
[MIT](./LICENSE)
<br><br>

[Stylized Water 2](https://assetstore.unity.com/packages/vfx/shaders/stylized-water-2-170386) by Staggart Creations: Required for the main scene. Available for purchase on the Unity Asset Store. Used under the standard Unity Asset Store EULA.
<br><br>
