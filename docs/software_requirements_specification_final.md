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
  
## Commercial Use

  The team at Jolly Snowman is pleased to help deploy our software for use in your lights business. We recommend working with us to develop a custom deployment plan depending on your planned use. For reference, we recommend a phased conversion plan for businesses serving multiple small to medium sites. We define medium as < 7,500 lights. Often, our clients find the use of the software to be time-saving and intuitive, but it is important to appropriately plan for enough time to film and process the lights. If your business has the time to plan for a seasonal deployment, we recommend starting with cites served during Halloween before hitting peak use times around Christmas. If your business has multiple large sites, or centers around events or performances, we recommend contacting us for a custom pilot conversion plan. Many of our smaller commercial clients that do not have any existing integration software find adopting our software can be done quickly and easily, although we still caution our clients to reserve time for video production and processing. 
  
  For all our commercial clients we recommend hosting Jolly Snowman for a learning seminar with your technical team. A friendly Jolly Snowman representative will be happy to lead your team through navigating the software with a live, hands on demonstration. Your team with learn helpful tips for producing winning video files with our lights props. We will demo a variety of camera input methods, customized to match the systems your team already uses. As a reminder, Jolly Snowman software is designed to integrate seamlessly with the current version of xLights software. If your business needs to utilize a different program please contact use about a custom development product. As always, the team at Jolly Snowman is invested in your success. Our customer serverice extends beyond deployment for 1 year as default, although a custom service plan can be created depending on your business needs. 
  
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
