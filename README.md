# Premonition
![Intro](https://github.com/user-attachments/assets/699189b1-bfd3-4085-80cb-470ef1782611)
_You don't know you're inside the storm until you're knee deep into it._

## 📜 Description
This is the source code for a game I did for the Brackey's 2024.2 Game Jam from September 2024. The code here is different than any other Vulkan desktop Godot 4.3 game, in that it includes the #79731 PR from the Godot engine project. This adds nearest neighbor scaling for 3D viewports.

I self-compiled the 4.3 codebase myself and created two templates: one for Windows and another for Linux. Both releases are [on my itch page here](https://framebuffers.itch.io/premonition).

## 🤔 Why?
PR #79731 has had some activity as of late. This is a good real life test of what this code does on a fully-working released game.

## 🐛 Bugs
- The routine that randomly makes things disappear is inherently broken. It's going to throw a bunch of exceptions. It's my first game, after all.
- There's collision issues on the stairs and a wall besides it. Forgot to add them.
- Audio issues. They were corrected at some point, but I never knew if it was an issue on my end or the engine's side, but it was **dangerously** ear-piercing at some point.
- Some insane inheritance issues. [This one happened to me, and here's some insight found while making this game.](https://github.com/godotengine/godot/issues/71102#issuecomment-2369199135)

## ⚙️ Gear
- Audio: Ableton Live Lite 12.
- 3D: SketchUp + blender.
- Built 95% by myself in one week. Including assets, music, code and story.
- Built on a custom build Godot Engine based on version 4.3, with modifications made by Calinou. 
- Font is [ProggyClean](https://github.com/bluescan/proggyfonts/), (C) 2004 Tristan Grimmer. Released under MIT Licence.
- Camera is [QualityFirstPersonController](https://github.com/ColormaticStudios/quality-godot-first-person-2), (C) 2024 Colormatic, translated to C# by LocoNeko. Released under MIT Licence, with heavy modifications to fit my Framework.
  - The mods ended up becoming [SharperFirstPersonController](https://github.com/Framebuffers/SharperFirstPersonController), my first Godot asset!
- Shader is [PSX Style Camera Shader by immaculate-lift-studio.](https://github.com/immaculate-lift-studio/PSX-Style-Camera-Shader) Released under MIT Licence.

## 📸 Screenshots
![Screenshot 2024-09-16 000742](https://github.com/user-attachments/assets/57e0496a-fad9-4a6e-b04a-c87bff40c9fb)
![Screenshot 2024-09-15 052713](https://github.com/user-attachments/assets/08ae4e97-205f-415f-baa2-2f39c8a84082)
![Screenshot 2024-09-28 161747](https://github.com/user-attachments/assets/636e17b6-8767-4113-b74b-f5b2e09fcd05)
![Screenshot 2024-09-16 001136](https://github.com/user-attachments/assets/a9bad9f7-590d-4141-9b02-dcb99ea87dc8)

This is my first completed game, ever. Hope you like it, and find every little easter egg!
