# Face-Detection-and-Recognition-for-Classroom-Attendance
Developed a Software that detects students face and then marks attendance after training face recognizer

Installation Instructions :-

There are 3 parts of this projects that needs to be installed: -
o	Microsoft Visual Studio 2015 Community
o	Microsoft SQL Server 2012
o	EmguCV 3.0
	Microsoft Visual Studio 2015 Community
Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft. It is used to develop computer programs, as well as web sites, web apps, web services and mobile apps. Visual Studio uses Microsoft software development platforms such as Windows API, Windows Forms, Windows Presentation Foundation, Windows Store and Microsoft Silverlight. It can produce both native code and managed code.
	Microsoft SQL Server 2012
Microsoft SQL Server is a relational database management system developed by Microsoft. As a database server, it is a software product with the primary function of storing and retrieving data as requested by other software applications—which may run either on the same computer or on another computer across a network (including the Internet).
	EmguCV 3.0
Emgu CV is a cross platform .Net wrapper to the OpenCV image processing library. Allowing OpenCV functions to be called from .NET compatible languages such as C#, VB, VC++ etc. The wrapper can be compiled by Visual Studio, Xamarin Studio and Unity, it can run on Windows, Linux, Mac OS X, iOS, Android and Windows Phone. Source: EmguCV Home. In plain English, EmguCV allows you to use OpenCV (a C++ image library) on the .net platform with languages like C#.
Once done with installation, do the following things: -
•	Run the SQL script in SQL Server
•	Change the database configuration in windows and web application
•	Import the .dll files from EmguCV to windows application


Operating Instruction:-

As an Administrator
	Log into the web application using Admin Username and Admin Password
	Click on ‘Add Professor’ link
	Input Professor Username and Professor Name and click on ‘Submit’ Button
	Message showed as ‘Professor Added’
	Click on ‘Add Course’ link
	Select Professor from Dropdown List
	Input Course name and Course number and click on ‘Submit’ Button
	Message showed as ‘Course Added’
	Click on ‘Upload File’ link
	Upload the file containing students enrollment to a particular course
	Click on ‘Submit’ Button
	Message showed as ‘File Uploaded Successfully’
	Log out from the web application

As a Professor
	Log into the windows application using Username and Password
	Select the course and Click on ‘Next’ Button
	You will have 4 options – Enroll, Train Recognizer, Take Attendance, Disenroll
	Click on ‘Enroll’ link
	Allow Students to input the faces multiple times along with their username
	Click on ‘Train Recognizer’ link
	Train the recognizer by clicking ‘Train’ Button
	Click on ‘Take Attendance’ link
	Allow Students to take their own attendance by facing it to front camera
	Click on ‘Disenroll’ link if you want to remove a student from course
	Select the student name and click on ‘Remove Student’ Button
	Click on Cross icon to close the application
	Log into the web application using Username and Password
	Click on a particular course to view the attendance
	Input the student name if you want to view only that student’s attendance report
	Click on ‘Generate Attendance Report’ to download the Attendance Report
	Click on ‘Change Password’
	Input the new password and click on ‘Submit’ Button
	Message showed as ‘Password Updated Successfully’
	Click on ‘Log Out’ to log out from web application
As a Student
	Input multiple face images using your username in order to train recognizer
	Keep your face in front of Camera in order to mark present in your attendance

