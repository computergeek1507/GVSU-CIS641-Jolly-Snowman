# Overview

This document serves as a set of software requirements which make the program both effective and intuitive to use. These requirements were created at the start of the development process to set clear and measurable features which must be created. This document may be updated when appropriate in the development cycle, such as at the start of the next sprint.

# Software Requirements

<Describe the structure of this section>

## Functional Requirements

### Software Feature: Overall

1. The program shall have two operating modes, realtime/live and video playback.
2. The program shall save the user defined settings on shutdown.
3. The program shall load the user defined settings on startup.
4. The program shall not consume more than 1 GB of memory.
5. The program shall not close unexpectedly.

### Software Feature: Program Settings

7. The program shall allow the user to set the amount of lights.
8. The program shall allow the user to turn on a specific Light.
9. The program shall send E1.31 data to turn on a specific Light.
10. The program shall allow the user to manually control settings optimized for the best light detection.
11. The program shall allow the user to configure a live video input.

### Software Feature: GUI

12. The GUI shall have a dialog to select operating modes.
13. The GUI shall have a dialog to edit program settings.
14. The GUI shall have an "Exit" button.
15. The GUI shall have an Export xModel File Option.
16. The GUI shall have an logging display.
17. The GUI shall overlay the found lights onto the video display.

### Software Feature: Video Processing

18. The user shall be able to adjust processing parameters.
19. The video processing shall skip the frame if two or more light objects are detected simultaneously.
20. The video processor shall expect one new light to be lit for every 500 milliseconds of video.
21. The video processor shall allow the user to manually control the video files time position.
22. The video processor shall allow the user to pause and resume video playback.

### Software Feature: E1.31 Output and Control

23. The program shall output E1.31 data when the user selects Realtime output mode.
24. The program shall capture a video frame from the camera after sending E1.31 data.
25. The program shall send E1.31 commands to turn on a Light.
26. The program shall send E1.31 commands to turn off a light.
27. The program shall turn a light on for one second before turning it off when in Realtime output mode.


## Non-Functional Requirements


### System Requirements

1. The program shall operate and run on Windows 7.
2. The program shall operate and run on Windows 10.
3. The program shall operate and run on Windows 11.
4. The program shall use the .Net 5 Runtime library.
5. The program shall use CPU resources when a dedicated GPU cannot be used for video processing.

### Software Feature: Overall

6. The program shall use the openCV Image processing library.
7. The program shall export xLight compatible model files.
8. The program shall allow the user to save models to outside of the program directory.
9.  The program shall allow the user to load videos from outside of the program directory.
10. The program shall interface with E1.31 compatible light controllers.

### Software Feature: GUI

11. The program shall have a GUI.
12. The program GUI shall display properly to Full HD displays.
13. The program GUI shall display properly to QHD displays.
14. The GUI shall remain responsive while the program operates.
15. The GUI shall provide feedback while the program preforms operations.
16. The program shall load within 3 seconds.

### Software Feature: Video Processing

17. The video processing time shall not take longer than than the length of the video file.
18. The program shall load MP4 video files.
19. The program shall work with USB webcam devices.
20. The program shall work with RTSP cameras.
21. The program shall overlay the locations of detected lights onto the current frame.
22. The program shall present relevant location information to the user for all detected lights of the current run.
23. The program shall discard processing results upon the start of a new video.

### Software Feature: E1.31 Data Output 

24. The program shall support the E1.31, Streaming ACN protocol.
25. The program shall support the Unicast E1.31 protocol.
26. The program should interface with an ethernet network adapter when in Realtime output mode.
27. The program shall support multiple E1.31 universes of data.
28. The program shall not interfere with unrelated devices connected to the computer.
  
# Change management plan
  
## Commercial Use

  The team at Jolly Snowman is pleased to help deploy our software for use in your lights business. We recommend working with us to develop a custom deployment plan depending on your planned use. For reference, we recommend a phased conversion plan for businesses serving multiple small to medium sites. We define medium as < 7,500 lights. Often, our clients find the use of the software to be time-saving and intuitive, but it is important to appropriately plan for enough time to film and process the lights. If your business has the time to plan for a seasonal deployment, we recommend starting with cites served during Halloween before hitting peak use times around Christmas. If your business has multiple large sites, or centers around events or performances, we recommend contacting us for a custom pilot conversion plan. Many of our smaller commercial clients that do not have any existing integration software find adopting our software can be done quickly and easily, although we still caution our clients to reserve time for video production and processing. 
  
  For all our commercial clients we recommend hosting Jolly Snowman for a learning seminar with your technical team. A friendly Jolly Snowman representative will be happy to lead your team through navigating the software with a live, hands on demonstration. Your team with learn helpful tips for producing winning video files with our lights props. We will demo a variety of camera input methods, customized to match the systems your team already uses. As a reminder, Jolly Snowman software is designed to integrate seamlessly with the current version of xLights software. If your business needs to utilize a different program please contact use about a custom development product. As always, the team at Jolly Snowman is invested in your success. Our customer service extends beyond deployment for 1 year as default, although a custom service plan can be created depending on your business needs. 
  
# Traceability links
  
The functional models and HPI created during the design of Jolly Snowman have been linked to the software requirements below.
  
## Use Case Diagram Traceability
  
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| UseCase1       | [DMX Controller](../artifacts/functional-models/UseCase-DMXController.drawio.png) | NF24,25,26 |
| UseCase2       | [Live Capture](../artifacts/functional-models/UseCase-LiveCapture.drawio.png) | NF19,20,21,22 |
| UseCase3       | [Video Processing](../artifacts/functional-models/UseCase-Video_Process-Page-1.drawio.png) | NF18 |
| UseCase4       | [Model Export](../artifacts/functional-models/UseCaseXModel_export.drawio.png) | F8,15 |
| UCDiagram1     | [GUI](../artifacts/functional-models/UseCaseDiagram-GUI.drawio.png) | F13,16,18,22; NF8,9,11,15,22, |
| UCDescription1 | [Live Capture](../artifacts/functional-models/UseCaseDescription-LiveCapture.docx) | NF19,20 |
  
## Class Diagram Traceability
  
| Artifact Name | Requirement ID |
| :-------------: |:----------: |
| [Class UML Diagram](../artifacts/functional-models/ClassUMLDiagrams.png) | F8,9,10,11,18,26,27; NF7,9,10,24,25 |

  
## Activity Diagram Traceability
  
<In this case, it makes more sense (I think, feel free to disagree) to link
to the file and to those requirements impacted>
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| ActDiagram1 | [Live Video](../artifacts/functional-models/ActivityDiagram-LiveVideo.drawio.png) | NF19, 20 |
| ActDiagram2 | [Video Process](../artifacts/functional-models/ActivityDiagram-VideoProcess.png) | NF8,18,23 |
| ActDiagram3 | [Application Diagram](../artifacts/functional-models/ActivityDiagram-Application.drawio.png)| F3,13; NF7,25,26 |
| WND | [WND](../artifacts/hci/WND.drawio.pdf) | F15,22; NF9,11,18,19,20 |
  
# Software Artifacts
  
Throughout the development process numerous artifacts were created to assist in directing the project. The following list contains the documents, videos, models, and diagrams that were used in this pursuit.

The following can also be found in the [artifacts](../artifacts/README.md) readme file.

### Prop Videos

These are the video files we used during construction of the program. They are videos that sequence LEDs light by light to allow the video processor to locate each one.

- [Snowflake](../artifacts/PropVideos/PXL_20210927_035523415.mp4)
- [Stocking](../artifacts/PropVideos/PXL_20210927_040513568.mp4)

### Test Videos

Videos used for unit testing purposes reside within this folder. The keyword "Beginning" is reference to the flashing of all lights at the beginning of the video. This flashing was originally going to be used to mark the beginning of the analysis, but that was not included in the final design.

- [Test_BeginningAndNone](../artifacts/TestVideos/Test_BeginningAndNone.mp4)
- [Test_BeginningAndOne](../artifacts/TestVideos/Test_BeginningAndOne.mp4)
- [Test_NoBeginningAndOne](../artifacts/TestVideos/Test_NoBeginningAndOne.mp4)

### Functional Models

This folder contains use case diagrams, activity diagrams, and use case descriptions. These models depict the design of the program in a visual format.

- [AD - Live Video](../artifacts/functional-models/ActivityDiagram-LiveVideo.drawio.png)
- [AD - Video Process](../artifacts/functional-models/ActivityDiagram-VideoProcess.png)
- [Application diagram](../artifacts/functional-models/ActivityDiagram-Application.drawio.png)
- [UC - DMX Controller](../artifacts/functional-models/UseCase-DMXController.drawio.png)
- [UC - Live Capture](../artifacts/functional-models/UseCase-LiveCapture.drawio.png)
- [UC - Video Processing](../artifacts/functional-models/UseCase-Video_Process-Page-1.drawio.png)
- [UC Model Export](../artifacts/functional-models/UseCaseXModel_export.drawio.png)
- [UC Description - Live Capture](../artifacts/functional-models/UseCaseDescription-LiveCapture.docx)
- [UC Diagram - GUI](../artifacts/functional-models/UseCaseDiagram-GUI.drawio.png)
- [Class Diagram](../artifacts/functional-models/ClassUMLDiagrams.png)

### HCI

The human centered interface design models can be found within this folder.

- [Windows Navigation Diagram](../artifacts/hci/WND.drawio.pdf)

#### Presentation Assets

Pictures and videos created by the group specifically created for the purpose of presentation reside within this folder. 

- [Application Screenshot](../artifacts/PresentationAssets/ApplicationScreenshot.png)
- [Midterm Video Demo](../artifacts/PresentationAssets/Video_Demo.mp4)

#### Screenshots

Screenshots depicting the operation of the application and the models function in X-Lights

- [Load a video file](../artifacts/Screenshots/load_video_file.png)
- [Select camera input](../artifacts/Screenshots/select_local_camera.png)
- [Load video file](../artifacts/Screenshots/load_video.png)
- [Select a remote camera](../artifacts/Screenshots/remote_camera.png)
- [Show detected Light](../artifacts/Screenshots/detect_light.png)
- [Display Detected Lights](../artifacts/Screenshots/display_detections.png)
- [Export the model](../artifacts/Screenshots/export_model.png)
- [Display within XLights](../artifacts/Screenshots/display_xlights_0.png)
- [Display within XLights](../artifacts/Screenshots/display_xlights_1.png)
- [The model within XLights](../artifacts/Screenshots/xlight_csvModel.png)