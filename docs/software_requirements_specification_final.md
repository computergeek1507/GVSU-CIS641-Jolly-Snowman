# Overview

This document serves as a set of software requirements which make the program both effective and intuitive to use. These requirements were created at the start of the development process to set clear and measurable features which must be created. This document may be updated when appropriate in the development cycle, such as at the start of the next sprint.

# Software Requirements

<Describe the structure of this section>

## Functional Requirements

### Software Feature: GUI

The GUI does not consume more than 1 GB of memory.
The GUI shall be able to load a video file into memory.
The GUI shall have an "Exit" button.
The GUI shall have a toolbar.

### Software Feature: Video Processing

The user shall be able to adjust processing parameters.
The video processing shall pause if two or more light objects are detected simulataneously.
The video processing shall pause if no light objects are detected
The video processor shall expect one new light to be lit for every 500 miliseconds of video.

  
## Non-Functional Requirements

### Software Feature: GUI

The program must have a GUI.
The GUI shall remain responsive while the program opperates.
The program shall load in 3 seconds or less.

### Software Feature: Video Processing

The video processing time shall not take longer than than the length of the video file.
The video processing program shall output a .XModal file of the spatial location of the lights.
  
# Change management plan
  
<Description of what this section is>
  
# Traceability links
  
<Description of this section>
  
## Use Case Diagram Traceability
  
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| UseCase1 | Move Player | FR5 |
| … | … | … |
  
## Class Diagram Traceability
  
| Artifact Name | Requirement ID |
| :-------------: |:----------: |
| classPlayer | NFR3, FR5 |
| … | … | … |
  
## Activity Diagram Traceability
  
<In this case, it makes more sense (I think, feel free to disagree) to link
to the file and to those requirements impacted>
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| <filename> | Handle Player Input | FR1-5, NFR2 |
| … | … | … |
  
# Software Artifacts
  
<Describe the purpose of this section>
  
* [I am a link](to_some_file.pdf)
