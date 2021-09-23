Team name: Jolly Snowman

Team members: Scott Hanson, Jessica Malinowski, George Ebeling

# Introduction

<!---(In 2-4 paragraphs, describe your project concept)-->
High-end Christmas light shows involve the complex management and control of addressable LEDs. Synchronizing the LEDs to display simple and complex patterns requires modeling each object (tree, reindeer, arches, etc.) in the display. Specifically, these models contain the coordinate information for every LED on the object. Current methods for creating these models involve the time-consuming task of manually creating and adding each LED to the model and then verifying the model's accuracy.

The goal of this project is to develop an application that can automate the task of creating these models. Using a stable video of each LED is turned on and off in sequence, a bitmap image, and eventually, maybe a .xmodel file will be created.

The processing of video files will be done using the C# OpenCV library, Emgu. This application will be developed using Windows 10/11 computers, and the application will be designed to run on Windows 10/11 computers.

# Anticipated Technologies

<!---(What technologies are needed to build this project)-->
* The programming language will be C#.
* NUnit for testing will be used for unit testing the application.
* OpenCV for C# (known as Emgu) is the vision library that will be used.
* A phone camera will be used for capturing video.
* DMX controllers will be used to control the lights in the demo
* If the extended goal of converting the output of this project into a .xmodel file is met, then the X-Lights program will be used for viewing the model's output.

# Method/Approach

<!---(What is your estimated "plan of attack" for developing this project)--->
Creating an image:

1. The videos will be pre-recorded. In the video, each LED will turn on and off with 0.1-1 second between each LED.
2. When processing the video, individual frames will be analyzed.
3. The brightest point of each frame will be masked onto a blank bitmap image with the same resolution as the video.
4. The resulting bitmap image will be a single image containing the 2D location of every LED in the video.

Creating a .xmodel:

1. To convert the image into a .xmodel file, blobs of every masked LED will be created.
2. Some information about each created blob is known because of the blob creation process, and the center point coordinates will be assumed to be where the LED exists.

# Estimated Timeline

<!---(Figure out what your major milestones for this project will be, including how long you anticipate it *may* take to reach that point)--->

* 2 weeks: Identify one light and mask it onto the output image.
* 1 week: Output a bitmap file image that has every light marked in the image.
* 2-3 weeks: Identify blobs for each LED.
* 2 weeks: Output .xmodel file for the X-Lights program.
* 2 weeks: Control the lights along with all previous output expectations.

# Anticipated Problems

* C# is a new language for Jessica, although she does know java. To address this issue she will look at a C# for java programmers tutorial.
* The group's overall experience with OpenCV is medium-low. Example projects will be utilized for practice and to be used as a template.
* George and Jessica are unfamiliar with the light controller technology being used. This section of the project will be managed mostly by Scott.

