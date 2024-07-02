# AR-Food-Menu

This repository contains the code and instructions to create an Augmented reality(AR) experience to view the food items in a menu. This project uses C# and Unity's AR Foundation to provide an AR experience.

## Project Overview
The AR Food Menu Project allows the user to scan a QR code to access a food menu in website. Each food item in the website has an associated image and a button to view the AR view of corresponding image. On clicking the 'AR View' button, the phone camera is activated and it will search for a suitable plane and the point of interest to place the AR View of the image. 

## Prerequisites
* Unity 2019.4 or later
* AR Foundation package
* AR Subsystem package

## Installation
* ### Install Unity and Create New Project
  * Download and install Unity Hub from https://unity.com/download.<br />
  * Open Unity Hub and click on New Project, choose 3D template and name the project.<br />
* ### Install AR Foundation and AR Subsystems<br />
  * Open Unity > **Windows > Package Manager > Packages : Unity Registry**<br />
  * In packages, search for and install **AR Foundation** and **AR Subsystems**.<br />
    
## Project Setup

* ### Create required GameObjects <br />
  * AR Session Origin Setup<br />
    * Right-click **Hierarchy > Create empty >** Rename it to **AR Session Origin**.<br />
    * Add AR Session component to this GameObject (**Add Component > AR Session Origin**).<br />
    * Right-click **AR Session Origin**, create a child GameObject and rename it to **AR Camera.**<br />
    * Add a Camera component and AR Camera Manager component to **AR Camera**.<br />
    
  * AR Plane Manager<br />
    * In **AR Session Origin** GameObject, add **AR Plane Manager** component (**Add Component > AR Plane Manager**)<br />
  * AR Raycast Manager<br />
    * In **AR Session Origin** GameObject, add **AR Raycast Manager** component (**Add Component > AR Raycast Manager**)<br />
  * AR Session Setup<br />
    * Right-click **Hierarchy > Create empty >** Rename it to **AR Session**.<br />
    * Add **AR Session** component to this GameObject (**Add Component > AR Session**).<br />
    
* ### Create UI Button for AR View <br />
  * Right-click Hierarchy and select **UI > Canvas**.<br />
  * Right click the Canvas, select **UI > Button** and rename it to **ARViewButon**.<br />
  * Change button text to **AR View**.<br />
    
* ### Create and attaching scripts<br />
  **Create DeepLinkingHandler script**<br />
    This script will simulate deep linking within Unity. When the button is clicked, it will simulate receiving a URL and starting the AR session.<br />
    * Create an empty GameObject in the Hierarchy and name it **DeepLinkingHandler**.<br />
    * Attach the DeepLinkingHandler script to this GameObject (**Add Component > Scripts > DeepLinkingHandler**).<br />
    * In the Inspector of the **DeepLinkingHandler** GameObject, find the **AR View Button** field and assign the **ARViewButton** from the Hierarchy to this field.<br />
      
  **Create ARPlaneDetection script**<br />
    This script will handle detecting flat planes.<br />
    * Attach the **ARPlaneDetection** script to the AR Session Origin GameObject (**Add Component > Scripts > ARPlaneDetection**).<br />
    
  **Create ARPointOfInterest script**<br />
    This script will use raycasting to detect a point of interest on the detected plane.<br />
    * Attach the **ARPointOfInteres**t script to the AR Session Origin GameObject (**Add Component > Scripts > ARPointOfInterest**).<br />
      
  **Create ARContentManager script**<br />
    This script will handle loading and displaying the AR content at the detected point of interest.<br />
    * Create an empty GameObject in the Hierarchy and name it **ARContentManage**r.<br />
    * Attach the ARContentManager script to this GameObject (**Add Component > Scripts > ARContentManager**).<br />
    * In the Inspector of the ARContentManager GameObject, find the **AR Content Prefab** field and assign the prefab you created for the AR content (e.g., a cube or plane with a material) to this field.<br />
      
  **Create ARSessionManager script**<br />
    This script will manage the AR session and handle the image URL.<br />
    * Create an empty GameObject in the Hierarchy and name it **ARSessionManager**.<br />
    * Attach the ARSessionManager script to this GameObject (**Add Component > Scripts > ARSessionManager**).<br />
      
* ### Script Execution Order<br />
  * Make sure scripts are executed in the correct order by going to **Edit > Project Settings > Script Execution Order**.<br />
  * Add **DeepLinkingHandler** at the top to ensure it initializes and handles the AR view button click first.<br />
    (Click **"+"** button, select **DeepLinkingHandler** from the list, assign a value like -10000)<br />

* ### Configure Build Settings:<br />
  * Go to **File > Build Settings** and ensure your platform is set to **PC, Mac & Linux Standalone for Windows**.<br />
  * Ensure the required scenes are added to the build.<br />
    
* ### Testing in Unity Editor:<br />
  * Enter Play mode in the Unity Editor and click the "AR View" button.<br />
  * Ensure the AR session starts, planes are detected, and clicking on a plane places the AR content with the specified image.<br />
  * Use the Console to debug any issues by reviewing the log messages.<br />
  

  
  
  
  
