# Overview

<!---(Describe the purpose of this document in 1 paragraph of less … hint: it is your SRS)-->
This document serves as a set of software requirements which make the program both effective and intuitive to use. These requirements were created at the start of the development process to set clear and measurable features which must be created. This document may be updated when appropriate in the development cycle, such as at the start of the next sprint. 

## Functional Requirements

1. Software Feature: GUI
    1. The GUI does not consume more than 1 GB of memory.
    2. The GUI shall be able to load a video file into memory.
    3. The GUI shall have an "Exit" button.
    4. The GUI shall have a toolbar.
    
2. Software Feature: Video Processing
    1. The user shall be able to adjust processing parameters.
    2. The video processing shall pause if two or more light objects are detected simulataneously.
    3. The video processing shall pause if no light objects are detected 

## Non-Functional Requirements

1. Software Feature: GUI
    1. The program must have a GUI.
    2. The GUI shall remain responsive while the program opperates. 
    3. The program shall load in 3 seconds or less. 

 2. Software Feature: Video Processing
    1. The video processing time shall not take longer than than the length of the video file.
    2. The video processing program shall output a .XModal file of the spatial location of the lights.
