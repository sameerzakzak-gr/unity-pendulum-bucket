# Unity Pendulum Bucket

A legacy Unity physics experiment exploring pendulum motion, adjustable simulation parameters, collision behavior, and paint-drop mechanics in an interactive 3D environment.

## Overview

This project was built as an experimental Unity simulation centered around a suspended bucket moving as a pendulum.

The repository preserves the C# scripts used for the simulation, including custom pendulum motion calculations, runtime parameter controls, paint-drop spawning, basic collision experiments, camera movement, and pause-menu behavior.

The original compiled Windows demo was built with **Unity 2019.2.1f1** and has been verified to run.

> **Note:** This repository is a source-code snapshot rather than the complete original Unity project. Unity scene files, prefabs, materials, textures, and `ProjectSettings` are not included.

## What the Demo Includes

The original interactive demo contains:

- A swinging bucket suspended from a pivot
- Adjustable rope length
- Adjustable mass
- A runtime parameter labeled friction
- Configurable paint-drop holes
- Paint drops that fall from the moving bucket
- Paint placement when drops reach the target surface
- Material-selection controls for parts of the environment
- Free camera navigation
- Pause and resume controls
- A complete 3D demonstration environment

## Core Implementation

### Custom Pendulum Motion

[`scripts/Pendulum.cs`](scripts/Pendulum.cs) contains the main simulation logic.

It:

- Tracks bucket velocity manually
- Applies gravity during the simulation
- Constrains the bucket to a configurable rope length
- Calculates a tension-like force
- Includes a centripetal-force term
- Uses a fixed internal timestep
- Interpolates positions for smoother rendering

This was an experimental implementation created to explore physics calculations rather than a replacement for Unity's production physics system.

### Paint Drops

The `drop`, `drop1`, and `drop2` scripts spawn paint-drop objects from configurable positions around the bucket.

[`scripts/splash.cs`](scripts/splash.cs) detects contact with the target surface and creates a paint object at the impact location.

The compiled demo supports enabling and disabling multiple bucket holes to change the paint-drop behavior.

### Runtime Controls

Several scripts connect UI controls to simulation properties:

- [`scripts/rope_length.cs`](scripts/rope_length.cs) — rope length and mass
- [`scripts/friction.cs`](scripts/friction.cs) — friction-related simulation parameter
- [`scripts/position.cs`](scripts/position.cs) — object position controls
- [`scripts/PauseMenu.cs`](scripts/PauseMenu.cs) — pause, resume, and quit behavior

### Additional Experiments

The repository also contains smaller experimental components covering:

- Manual free-fall movement
- Two-body collision calculations
- Trigger-based collision behavior
- Camera movement
- Object orientation toward the pendulum pivot

Some of these scripts are exploratory, duplicated, partially implemented, or unused in the final demo. They are preserved as part of the original project history.

## Repository Structure

```text
.
├── LICENSE
├── README.md
└── scripts/
    ├── Pendulum.cs
    ├── CollisionPhysics.cs
    ├── FreeFall.cs
    ├── splash.cs
    ├── drop.cs
    ├── drop1.cs
    ├── drop2.cs
    ├── rope_length.cs
    ├── friction.cs
    ├── position.cs
    ├── Came.cs
    ├── CameraMovement.cs
    ├── LookAtOther.cs
    ├── PauseMenu.cs
    └── additional experimental scripts
```

## Technology
- Unity
- C#
- Unity version used by the preserved Windows build: 2019.2.1f1
- Unity UI
- Unity colliders and trigger events
- Custom motion and force calculations
## Project Status
This is a legacy educational / experimental project preserved as part of my software-development portfolio.
The original project assets and Unity editor project are no longer included in this repository, so cloning this repository alone is not sufficient to rebuild the original application.
The C# source is retained to document the simulation techniques and experiments implemented during the project.
## License
Licensed under the MIT License.
## Author
Sameer Zakzak
