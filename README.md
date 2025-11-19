# Offutt Playable Zombie Game

## Overview
Offutt Playable Zombie Game is a first-person Unity prototype featuring player movement, ballistic shooting, zombie enemies, pickups, collision interactions, and a Heads-Up Display (HUD) for health and ammo.  

The game was developed as part of early Unity coursework and demonstrates core concepts in:
- Unity physics
- C# scripting
- Enemy AI behavior
- Prefab-based design
- UI/HUD implementation
- Scene organization and lighting

---

## Features

### Player Mechanics
- First-person movement using Rigidbody and Colliders
- Ballistic shooting system using projectile prefabs
- Ammo tracking displayed on the HUD
- Health system with pickups

### Enemy (Zombie) AI
- Zombies pursue the player using simple chase logic (`EnemyController.cs`)
- Collision-based damage / hit detection
- Multiple zombie prefab variants included

### User Interface
- HUD integrated directly into `SampleScene.unity` under a Canvas object
- Displays:
  - Player health
  - Ammo count

### Gameplay Flow
- Collect ammo and health pickups
- Use ballistic projectile prefabs to eliminate zombies
- Avoid enemy collision to prevent damage
- Scene lighting and fog effects included for atmosphere

---

## Technologies Used
- **Engine:** Unity (URP enabled)
- **Language:** C#
- **Platform:** Windows
- **Components Used:** Rigidbody, Colliders, Triggers, Canvas UI, Prefabs

---

## Project Structure

```
Assets/
  Scenes/
    SampleScene.unity

  Scripts/
    PlayerController.cs
    EnemyController.cs
    Projectile.cs
    EnemyProjectile.cs
    GameManager.cs
    FacePlayer.cs
    LookAt.cs
    OnTrigger.cs
    AddAmmo.cs
    AddHealth.cs
    AddSpeed.cs
    Target.cs

  Prefabs/
    Enemy.prefab
    Zombie1.prefab
    ZombiePat Variant.prefab
    PlayerProjectile.prefab
    Bullet_Pistol_B.prefab
    AmmoPickup.prefab
    HealthPickup.prefab
    EnemyProjectile.prefab

  Models/
    (Zombie and pistol models)

  Materials/
    (Materials for player, enemies, bullets, pickups, environment)
```

*NOTE: The project includes several third-party asset packs such as fence packs and fog systems.  
Only the folders listed above are directly used in gameplay.*

---

## How to Play (Windows Build)

A playable build is included in the repository:

Download:  
Offutt_Playable_Zombie_Game.zip

To play:
1. Download and extract the ZIP.
2. Open the folder.
3. Run `Offutt_Project.exe`.

---

## Script Overview

- **PlayerController.cs** — Handles first-person movement and shooting logic  
- **EnemyController.cs** — Controls basic zombie chase behavior  
- **Projectile.cs** — Handles movement and collision for player bullets  
- **EnemyProjectile.cs** — Handles enemy projectile behaviors (if used)  
- **GameManager.cs** — Tracks game state, score, health, and ammo  
- **AddAmmo.cs / AddHealth.cs / AddSpeed.cs** — Pickup item scripts  
- **FacePlayer.cs / LookAt.cs** — Utility scripts for rotation/aiming  
- **OnTrigger.cs** — Trigger-based interactions between player and enemies  

---

## Skills Demonstrated
- Unity scene composition and prefab workflow  
- C# scripting for gameplay logic  
- Projectile physics and collision handling  
- UI and HUD development within Unity Canvas  
- Enemy behavior and player interaction design  
- Asset integration and environment design  

---

## Future Enhancements
- AI navigation using Unity NavMesh  
- Additional weapons and ammunition types  
- Sound effects and improved animations  
- Expanded levels and game objective system  
- Main menu, pause screen, and settings menu  

---

## About the Developer

David Offutt  
Computer Science Student  
Lake Washington Institute of Technology  

GitHub: https://github.com/doff87  
Portfolio: https://github.com/doff87/CS_Portfolio  
LinkedIn: https://www.linkedin.com/in/d-offutt/

---

This project demonstrates early Unity development experience using C#, prefabs, and physics-driven gameplay mechanics.