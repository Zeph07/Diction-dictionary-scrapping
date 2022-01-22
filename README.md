# Diction-dictionary-scrapping
a .NET(Version 4.5) application which when given a web page downloads the text on it and outputs a 
sorted list of the unique words on the page with counts of the occurences.It also works with a dictionary to identify the none English words.
I used windows forms on visual studio.

The program works by inputting your website url in the top most textbox and pressing the download button which downloads the text and posts it on the text box labeled text, pressing the count button returns all the words and their frequencies in descending order in the ListView control labeled List of words.You can search for a particular word using the search button.
The Load Dictionary option allows you to load the dictionary into the textbox while the non English words button compares the contents
of the textbox labeled Text and the Dictionary text box and returns the result in the textbox labeled words not found in the dictionary

requirements
Microsoft Visual Studio
Oxford English Dictionary.txt

Challenges
The primary challenge is removing the HTML code from the text
