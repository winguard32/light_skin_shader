//Light_Skin_Shador_2.0
//Reference the function of the unity chan toon shader.
//For information on existing shaders, please use the related link.
//https://unity-chan.com/

You can add a pattern to an existing surface by adding a Material on top of the mesh.

Please Read me (Caution).          ------------------------------------
Due to the nature of the downloaded product, you cannot get a refund after purchasing it.
Mark positions appear relative to existing UVs, so they may appear differently depending on the UV mapping settings.
In the Skinned Mesh Render setting, if multiple materials are split, they may not appear or appear differently.


Terms of Service -----------------------------------------------------
1. Personal Use
Allowed
2. Use of corporations
Partially allowed (Inquiry for commercial use)
3. Use of R-18 grade
Allowed
4. Use of R-18G grades
Allowed
5. Use for political and religious activities
prohibited at all
6. Redistribution
Prohibits redistribution that contains the product data.
Prevent redistribution of data in a form that can be used by re-extracting it


※ main function             ---------------------------

▶ size
▶ rotation
▶ position placement
▶ Emissive function of basic unity chan toon shader
▶ Bloom function
▶Scrolling emission function



How to Apply
mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add

1. Select the mesh you want from Hierachy
2. In the Skinned Mesh Render component section of the Inspector window,
3. Increase the number of materials by 1 (Element add)
4. Put the prepared prefab into the newly created element item


Material shader settings    -------------------------------------


texture
┕ Texture must be set to sprite (2d and ui).
┕ The texture pattern must be white in the desired shape and transparent around it
(Please refer to the available texture for an example.)
┕ The texture must be the same size horizontally and vertically (ex) 512x512, 1024x1024, 2048x2048
┕ Texture pattern must be centered on the texture
(For easier adjustment, it is recommended to place the pattern in the center.)

Bloom texture
┕ This is a format that covers the existing texture with a texture in the form of Bloom. (optional)

▶ size
┕ The size basis is the center of the texture.

▶ rotation
┕ The rotation basis is the center of the texture.
┕ When it is 0 to 1, it rotates one rotation.

▶ offset (position placement)
┕ It is placed based on the background texture uv.
┕ With respect to x and y, z and w do not need to be adjusted.

-----

▶ Emissive function of basic unity chan toon shader
┕ Reference the function of the unity chan toon shader.

Base Speed (Time): The time interval of the animation to be executed. Unit: Seconds
┕ 1 speed - 1 second, 2 speed - 0.5 seconds. (Inversely proportional)

Scroll U/X direction: Motion direction and strength in U/X direction

Scroll V/Y direction: Motion direction and intensity in V/Y direction

Rotate around UV center : 1 turn clockwise when Base Speed is 1
┕ Rotate after satisfying the scroll setting.

PingPong Move for Base: Repeat in the set direction

-----

Bloom function
┕ Bloom texture is optional.
┕ This function is not included in the unity chan toon shader feature.

-----

▶ Scrolling with Time: Adding a scrolling function to Emission

Strength : Apply scroll strength

Blinking Emission: Periodic setting of Emission

Min: Minimum period
Max: Maximum period
Velocity: Speed

Direction : Scrollable Directional Coordinates

Width : Scope of Emissive being scrolled
Velocity: scroll speed
Interval: Scroll cycle

-----

▶ ColorShift with Time: Colour change towards Destination Color in Emissive Texture

Destination Color: Resultant color HDR available

ColorShift Speed (Time): Interval between color changes.
┕ 1 speed - 6-second interval change (proportional)

-----

▶ ViewShift of Color: Normal front view, changed color representation in side view

ViewShift Color: Color Settings on the Side view