//Light_Skin_Shador
//Reference the function of the unity chan toon shader.
//For information on existing shaders, please use the related link.
//https://unity-chan.com/

You can add a pattern to an existing surface by adding a Material on top of the mesh.

Please understand.          ------------------------------------
Refunds are not possible after purchase due to the nature of the downloaded product and booth specifications.
Since the mark position appears based on the existing UV, it may appear differently depending on the UV mapping settings.
It may not appear if multiple materials are divided in the Skined Mesh Renderer settings.


※ main function             ---------------------------

▶ size
▶ rotation
▶ position placement
▶ Emissive function of basic unity chan toon shader
▶ Bloom function
▷poiyomi's emission function(not implemented)


Application method
mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add



Material shader settings    -------------------------------------


texture
┕ The texture should be set to sprite(2d and ui).
┕ The pattern of the texture should have an empty periphery.
┕ They must be the same length and width.
┕ The texture pattern should be placed in the center of the texture.

Bloom texture
┕ This is a format that covers the existing texture with a texture in the form of Bloom. (optional)

▶ size
┕ The size basis is the center of the texture.

▶ rotation
┕ The rotation basis is the center of the texture.
┕ When it is 0 to 1, it rotates one rotation.

▶ position placement
┕ It is placed based on the background texture uv.
┕ With respect to x and y, z and w do not need to be adjusted.

▶ Emissive function of basic unity chan toon shader
┕ Reference the function of the unity chan toon shader.

▶ Bloom function
┕ Bloom texture is optional.
┕ This function is not included in the unity chan toon shader feature.

Terms of service            -------------------------------------------------------
    1. Personal commercial use
        permit
    2. Commercial use of legal entities
        permit
    3. Use of Sexual Expressions
        permit
    4. Use of Violent Language
        permit
    5. Use for political and religious activities
        Please contact us individually.
    6. Redistribution
        Redistribution, including product data, is prohibited.
        Distribution in a form that does not contain product data,
        such as texture and material settings presumed to have been used in the product, is permitted.