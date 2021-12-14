# About Jolly Snowman

High-end Christmas light shows involve the complex management and control of addressable LEDs. Synchronizing the LEDs to display simple and complex patterns requires modeling each object (tree, reindeer, arches, etc.) in the display. Specifically, these models contain the coordinate information for every LED on the object. Current methods for creating these models involve the time-consuming task of manually creating and adding each LED to the model and then verifying the model's accuracy.

The goal of this project was to develop an application that can automate the task of creating these models. Through a video or live stream, each LED is turned on and off in sequence. The information is stored and then used to export a .xmodel file for use with XLights.

### System Requirements

- Windows OS

### Download Jolly Snowman

- Zipped file size is 50 MB
- Download Version [1 here](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/releases/download/v1/release_v1.zip)

## Running Jolly Snowman

We recommend the Jolly Snowman software for residential use with users who are already familiar with xLights. Users who are novices with xLights may want to focus on learning that software program first before utilizing Jolly Snowman. 

### Getting Started

1. After downloading the Version 1 zip file you will need to extract, or unzip, the file. 

2. In the unzipped file launch the program by doubling clicking "Emgu_Test". Windows defender will pop up to warn you about this file because it is an unsigned file. Click "More" and then "Run Anyways" to run the program. 

3. Click "File" >> "Load Video" to get started. 

![Image of File to Load Video Path](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/load_video.png)

Select "Video File" to upload a file.

![Image of Video File Option](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/load_video_file.png)

Select "Local Camera" to use an integrated or connected webcam.

![Image of Local Camera Option](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/select_local_camera.png)

Select "Remote Camera" to connect to a camera in your network.

![Image of Remote Camera Option](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/remote_camera.png)

4. We recommend processing your video file with the default settings. Changing these settings is helpful for troubleshooting if the default settings do not work for your file. Note each setting has helpful hints in the description box in the bottom corner of the window. See video processing below for more information. 
Click "Start Processing" to begin automated video processing. 

5. You can note a video scrubbing toggle at the top of the window, as well as a "Process Frame" button, if you need to process a particular frame or if you desire to process manually frame by frame. If you experience difficulties with the video processing see the troubleshooting guide below. 

![Image of Processed Model](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/display_detections.png)


6. When you are satisfied with your light identification you are ready to export by clicking "File" >> "Export as xModel".

Here you can see the message displayed when the model is successfully exported. 
![Image of Exported Model Message](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/export_model.png)

Here you can see how the model looks when exported.
![Image of Exported Model](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/xlight_csvModel.png)

Here you can see how the model looks in xLights.
![Image of Model in xLights](https://github.com/computergeek1507/GVSU-CIS641-Jolly-Snowman/blob/master/artifacts/Screenshots/display_xlights_1.png)

Happy Processing!

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
