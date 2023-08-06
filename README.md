# Chest-System

**Overview**

Welcome to the GitHub repository for our game's advanced Chest System! This system has been designed with modularity and efficiency in mind, using Model-View-Controller (MVC) architecture, State Machine, and Observer Pattern.

**Features**

MVC Architecture: The Chest System is divided into three key components - Model, View, and Controller - to ensure a clear separation of concerns and enhance maintainability.

State Machine: Each chest has three states - Locked, Unlocking, and Unlocked. The State Machine pattern allows smooth transitions between these states, providing a seamless player experience.

Observer Pattern: We have implemented the Observer Pattern to handle updates when a chest is claimed. This pattern notifies the UI to update the current available chests and triggers the unlocking of the next chest in the queue.

**Components**

**Model**: Contains the core logic of the chest system. It manages the state transitions, rewards, timers, and maintains the unlock queue.

**View**: Responsible for displaying the chest UI and animations. The view updates based on the state of each chest, providing visual feedback to players.

**Controller**: Acts as the bridge between the model and view. It handles player interactions, initiates unlocking, and communicates state changes to both the model and view.

**State Transitions**

The State Machine manages state transitions as follows:

**Locked**: The initial state of a chest. It remains locked until the player clicks on it to unlock it.

**Unlocking**: Once unlocked, the chest enters the Unlocking state, and the timer starts ticking. The player must wait for the timer to complete before claiming the reward or use Gems to Unlock Early.

**Unlocked**: After the timer reaches zero, the chest transitions to the Unlocked state, and the reward becomes available for the player to claim.

**Observer Pattern Implementation**

The Observer Pattern is utilized to handle updates when a chest is claimed:

**Currency Update**: When a chest is claimed, the Observer Pattern notifies the UI to update the currency available.

**Next Chest Unlock**: The pattern also triggers the unlocking process for the next chest in the queue, ensuring a continuous flow of available chests.
