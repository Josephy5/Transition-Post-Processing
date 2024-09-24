![TransitionV2](https://github.com/user-attachments/assets/4783a647-7a3e-45f1-8196-d1cbabc03004)

#Transition Post Processing
![Unity Version](https://img.shields.io/badge/Unity-2021.3%36LTS%2B-blueviolet?logo=unity)
![Unity Pipeline Support (Built-In)](https://img.shields.io/badge/BiRP_❌-darkgreen?logo=unity)
![Unity Pipeline Support (URP)](https://img.shields.io/badge/URP_✔️-blue?logo=unity)
![Unity Pipeline Support (HDRP)](https://img.shields.io/badge/HDRP_❌-darkred?logo=unity)

A transition post processing effect for Unity URP (2022.3.20f1) that I made for Serious Point Games as part of my studies in shader development.
You can refer to the effect's documentation for more info (should be in the repo and its release as a PDF file).

## Features
- Fade transitions
- Custom transitions via textures (see examples or preview above)
- Able to transition to a screen color or a texture

## Example[s]
![image_006_0001](https://github.com/user-attachments/assets/d5da36e6-593c-48d2-95a6-a2ae37f8130a)
Angular Transition

![image_007_0001](https://github.com/user-attachments/assets/b511742c-1567-4a51-9fa7-3ac9cda8782b)
Spiral Transition

![image_008_0001](https://github.com/user-attachments/assets/eac5e5c1-b7a4-4096-8aa5-893ee9704a54)
Top and Bottom Transition

## Installation
1. Clone repo or download the folder and load it into an unity project.
2. Add the render feature of the effect to the Universal Renderer Data you are using.
3. Create a volume game object and load the effect's volume component in the volume profile to adjust values
4. If needed, you can change the effect's render pass event in its render feature under settings.

## Credits/Assets used
Shader code is based from Dan Moran's Shaders Case Study—Pokémon Battle Transitions YouTube video
[-Youtube Video Link-](https://youtu.be/LnAoD7hgDxw?si=tCtTEOshaZdfLi6R).
<br><br>
The provided transition textures are made by Dan Moran from his Shaders Case
Study—Pokémon Battle Transitions YouTube video [-Youtube Video Link-](https://youtu.be/LnAoD7hgDxw?si=tCtTEOshaZdfLi6R)
under the CC By 4.0 Attribution 4.0 International License.
