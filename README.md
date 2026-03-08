# Unity Mesh Deformation Tool

Interactive mesh sculpting tool built using Unity version 6000.3.10.f1

## Project Structure

```sh
├── [Assets]
|   ├── [Models] (imported .obj files)
|   ├── [Scenes] (all unity scenes)
|   ├── [Scripts] (scripts for controllers)
├── [MeshDeformerBuild] (windows build)
├── .gitignore
├── README.md
```

## Build/Run Instructions

- Unity Editor: Go to scene 'MeshDeformer.unity' and enter Unity Play Mode
- Build: Build with Unity build profile and launch the built application
- Windows Build: Go to folder 'MeshDeformerBuild' and launch 'MeshDeformer.exe'

## Features

- Vertex mesh deformation
- Adjustable radius and strength
- Raise / lower mode
- UI dashboard
- FPS counter

## Controls

- Left Click: Raise/Lower terrain
- Right Click: Camera look around
- WASDEQ: Move camera

## Architecture and Design Choices

- Mesh deformation logic, input detection and re-rendering all done in 'MeshDeformer.cs' for simplicity
- UICanvas to organise and display UI elements, UIController to manage passing of data to MeshDeformer

## Possible Improvements

- Separation of deformation logic to allow for extension to add other types of mesh editing
- Iterating over all vertices does not scale well, adopt a grid-based look-up approach for efficiency
- System to import user-defined .obj at runtime
- Undo/Redo deformations
