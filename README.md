# Battleship Game

![Unity](https://img.shields.io/badge/Unity-2021.3.0f1-blue.svg)
![License](https://img.shields.io/badge/license-MIT-green)

A classic **Battleship** game implemented in Unity. This project allows players to engage in a strategic naval battle against an AI opponent. The game includes features like grid-based gameplay, and attack mechanics.

## Table of Contents

- [Features](#features)
- [Gameplay](#gameplay)
- [Installation](#installation)
- [Controls](#controls)
- [Screenshots](#screenshots)
- [How to Play](#how-to-play)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Single Player Mode**: Play against a basic AI with random ship placement and attacks.
- **Grid-based Gameplay**: Player take turns guessing the location of the opponent's ships.
- **Simple UI**: Intuitive, clean, and minimalist user interface.
- **3D Graphics**: 2D grid with clear ship and hit markers, in a 3D environment.

## Gameplay

The goal of the game is to sink all of your opponent's ships by guessing their locations on a grid. The Player take turns selecting coordinates to "fire" upon, with feedback provided on whether the shot was a hit or miss. Once all ships are destroyed, the game ends, and a new game starts.

## Installation

1. Clone this repository:
    ```bash
    git clone https://github.com/HUNAToth/Pirate_BattleShip.git
    ```
2. Open the project in Unity (version 2021.3.0f1 or later).
3. Press the **Play** button in the Unity Editor to test the game or build the game by going to `File > Build Settings`.

### Build for Platforms

- To build for Windows, macOS, or Linux, select your platform in **Build Settings** and follow the steps to export the project.
- For mobile platforms (iOS/Android), ensure the appropriate SDKs are installed and follow Unity’s standard build process.

## Controls

- **Left Mouse Button**: Select and fire at enemy ships during gameplay.

## Screenshots

![Gameplay](./Screenshots/2024-09-16%2014_32_37-PirateBattleship.png)


## How to Play

1. **Ship Placement**: At the beginning of each game, the CPU randomly places ships on the grid.

2. **Taking Turns**: Once all ships are placed, the player take turns selecting coordinates to fire at their opponent’s grid.
   
3. **Hit/Miss Feedback**: The game will indicate whether your shot was a hit (direct hit on a ship) or a miss (no ship in that location).
   
4. **Win Condition**: If the player sink all of the CPU's ships wins.

## Contributing

Contributions are welcome! Here's how you can help:

1. Fork the repository.
2. Create a new branch:
    ```bash
    git checkout -b feature-name
    ```
3. Make your changes and commit them:
    ```bash
    git commit -m "Add feature"
    ```
4. Push to the branch:
    ```bash
    git push origin feature-name
    ```
5. Create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
