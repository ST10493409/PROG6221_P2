CyberSecurity Awareness Chatbot – Part 3 POE
Student Information
Student Number: ST10493409
Module: PROG6221 

Project Description:
This project is a CyberSecurity Awareness Chatbot developed in C# using Windows Presentation Foundation (WPF). The chatbot is designed to educate users about cybersecurity topics such as password safety, phishing, privacy, and safe browsing.

Software Requirements:
Visual Studio 2022
.NET Framework
MySQL Server 8.0
MySQL Workbench
MySql.Data NuGet Package
Database Setup

Create the database using the following SQL script:

CREATE DATABASE CyberSecurityDB;

USE CyberSecurityDB;

CREATE TABLE Tasks
(
TaskID INT AUTO_INCREMENT PRIMARY KEY,
Title VARCHAR(100),
Description VARCHAR(255),
Reminder VARCHAR(100),
Completed BOOLEAN
);

Running the Application
-Open the solution in Visual Studio.
-Ensure MySQL Server is running.
-Update the connection string in DatabaseHelper.cs if required.
-Build and run the application.
-Enter your name and begin interacting with the chatbot.

Features
-Quiz
-Task Assistant(Task handling)
-Activity Logs

Referencing is in the code at the bottom of MainWindow.xaml.cs
