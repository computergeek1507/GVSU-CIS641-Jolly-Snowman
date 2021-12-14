# About Jolly Snowman

High-end Christmas light shows involve the complex management and control of addressable LEDs. Synchronizing the LEDs to display simple and complex patterns requires modeling each object (tree, reindeer, arches, etc.) in the display. Specifically, these models contain the coordinate information for every LED on the object. Current methods for creating these models involve the time-consuming task of manually creating and adding each LED to the model and then verifying the model's accuracy.

The goal of this project was to develop an application that can automate the task of creating these models. Through a video or live stream, each LED is turned on and off in sequence. The information is stored and then used to export a .xmodel file for use with XLights.

## Installation Guide

### System Requirements

- Windows OS

### Downloading Jolly Snowman

## Running Jolly Snowman

We recommend the Jolly Snowman software for residential use with users who are already familiar with xLights. Users who are novices with xLights may want to focus on learning that software program first before utilizing Jolly Snowman. 

## Video Processing

Jolly Snowman can be utilized with a video file or a live stream. Listed below are the ideal video conditions. While it is possible to process a video that is less than ideal, you may find the video processing more challenging, and it may require more fine tuning of the video settings. 

As a reminder a quality video file or live stream will:
- Have all of the lights visible in the frame. 
- Background and ambient lighting is as dark as possible, so that when a light turns on it is the only bring object in the frame. 
- Be as still and steady as possible, with lights in focus as they illuminate. A video recorded from a stand or other stationary object is best.
- Each light should illuminate one at a time, and not more than once per light. 
- We recommend illuminating the lights white for the purposes of this video. 

### Troubleshooting

#### Video processes without locating any or all lights

1. Check the ideal video conditions above, and if the video seems to be poor quality, record a new video. This may include waiting until later in the day so the background and ambient light is much darker, using a tripod to record a video without motion, or using a better camera to record the video (most phones have high-quality night camera capabilities, but a live video stream may be lower quality). 
2. If the video quality is darker overall, including the lights, then you may need to adjust the video settings if it does not adequately process the first time. Make sure that the initial processing attempt has the default video processing settings. If it still does not process try lowering the Brightness and Color settings incrementally at the same time. Continued, incremental decrease will often fix the issue in a darker video file, when it is impossible to obtain a better quality video. 
3. If none of the above work, we recommend adjusting the Maximum Blob Size, again incrementally decreasing if the processing identifies non-light objects as lights, or increasing if the processing misses lights altogether. 
