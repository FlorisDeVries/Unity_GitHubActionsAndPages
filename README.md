# Unity-GitHubActions: Project showing the Unity + GitHub Actions build and deploy

![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)

## Overview
This project is created as an experiment to show the build and publish capabilities of GitHub actions for a Unity project.
Each time a new PR is merged into master the `some-pipeline-name` workflow will trigger, building and publishing the Unity project for WebGL (GitHub pages).

## Features
- **Unity sandbox**: A minimal Unity project is included, where the player can push some 0-friction blocks around with WASD.
- **CI/CD**: `some-pipeline-name` automatically builds and deploys the game to GitHub pages, when a new version is available on the `main` branch.

## Setup instructions
If you would like to apply this simple workflow to your Unity project, follow these steps:
1. **Unity Settings**: Brotli compression format

<img src="img/unity-settings.png" alt="Unity Settings" width="400"/>

2. **Copy workflow**:
3. **Create Build branch**:
4. **Setup GitHub pages**:
5. **Extract Unity license**:
6. **Create Personal Access Token**:
   1. [Personal Access Tokens](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token)
   2. 'Contents' => Read/Write
   3. ACTIONS_PAT
7. **Add environment secrets**:
   1. UNITY_EMAIL
   2. UNITY_LICENSE
   3. UNITY_PASSWORD
8. **Try it out!**: