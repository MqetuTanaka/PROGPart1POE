# PROGPart1POE
# Repository Link 
https://github.com/MqetuTanaka/PROGPart1POE.git

# Youtube Link
https://youtu.be/tohI0vN4BkE
# GitHub Link
https://github.com/MqetuTanaka/PROGPart1POE.git


This code implements a cybersecurity awareness chatbot with audio playback functionality. The chatbot can respond to user queries about various cybersecurity topics and play audio files when interacting with the user.
Key Components
BotResponse Class Hierarchy
BotResponse (Abstract Class): Defines the structure for bot responses with a Trigger property and an abstract GetResponse method.
GreetingResponse (Derived Class): Handles greeting messages and includes a user name.
SecurityResponse (Derived Class): Provides detailed responses to cybersecurity topics using a switch statement.
GeneralResponse (Derived Class): Handles general conversational responses.
CyberSecurityBot Class
Properties and Fields: Maintains lists of bot responses and chat history, along with the user's name.
Constructor: Initializes the bot with various response types (greeting, security topics, and general conversation).
Start Method: Main entry point that starts the chatbot, plays a welcome sound, displays ASCII art, and enters the interaction loop.
ProcessUserInput Method: Handles user input, normalizes it, and finds matching responses using triggers or keyword matching.
Display Methods: Renders the chat window and ASCII art to the console.
Audio Playback: Uses the NAudio library to play audio files for welcome messages and thinking effects.
Program Class
Main Method: Entry point of the application that creates and starts the CyberSecurityBot.
How It Works
Initialization
The CyberSecurityBot is instantiated, initializing its responses and setting up event handlers.
The Start method is called, which plays a welcome sound and displays ASCII art.
User Interaction Loop
The bot displays a prompt for user input.
User input is read and processed:
Input is normalized (lowercase, trimmed, punctuation removed).
The bot checks if the input matches any predefined triggers or keywords.
A matching response is found and displayed.
If no match is found, the bot provides a default response.
Audio Playback
When the bot starts, a welcome sound is played using the PlaySound method.
While the bot is "thinking" (processing input), a thinking sound can be played.
Termination
The loop continues until the user types "exit".
Key Features
Encapsulation and Inheritance: Uses object-oriented principles to organize responses.
Polymorphism: Different response types are handled uniformly through a common interface.
Event Handling: Allows for extensible event-driven interactions.
Audio Integration: Enhances user experience with sound effects using NAudio.
Usage
Run the Program: Execute the application to start interacting with the chatbot.
Ask Questions: Type questions related to cybersecurity topics or general conversation.
Listen to Audio: The bot plays sounds at specific interaction points (welcome, thinking).
This code provides a structured and interactive way to learn about cybersecurity topics while enhancing the user experience with audio feedback.
# PROGPart2POE
Explanation:
ActivityLogger Class:
LogAction: Adds a new log entry and ensures the log does not exceed the maximum size.
GetLog: Returns the entire log.
GetLimitedLog: Returns the last limit entries of the log.
Integration with CyberSecurityBot:
The CyberSecurityBot class now includes an instance of ActivityLogger.
The ProcessUserInput method logs user actions and checks for commands to display the activity log.
The InitializeResponses method adds responses for viewing the activity log.
Usage:
When the user types "Show activity log" or "What have you done for me?", the chatbot will display the last 5 actions from the log.
You can adjust the maxLogSize and limit parameters in the ActivityLogger class to change the log size and the number of entries displayed.
This implementation ensures that the chatbot logs user interactions and provides a concise summary of recent actions when requested.
# PROGPart3POE
I prioritized creating a chatbot that feels genuinely conversational and lifelike. 
To keep interactions dynamic and engaging, I designed a robust system for generating varied responses. 
The chatbot now maintains contextual memory of past conversations, 
seamlessly referencing them when relevant to sustain a natural flow. 
I also integrated advanced sentiment analysis, 
enabling it to adjust its tone and behavior based on the user's emotional state whether they're expressing frustration, curiosity, or just chatting casually. 
Everything is built on a clean, scalable, and well-documented foundation that ensures long-term maintainability.
