Feature: TotalCommanderFunctions
	This scenario checks the correctness of the copy and move files
	whose names appear in the configuration file. 
	Then checked the correctness of the search operation of several menu items

Scenario: Check TotalCommander's functions
	When I run app TotalCommander
	Then Validation window opened with buttons 1, 2 and 3
	When I click on valid button
	Then Opened main window

	When I open 'C:\temp1' in 'left' view
	And I open 'C:\temp2' in 'right' view
	Then Folders opened

	When I move file 'testFile.temp' from 'left' to right view
	Then Opened copying window
	When I confirm copying file 'testFile.temp' to 'C:\temp2'
	Then File 'testFile.temp' copied to 'C:\temp2'

	When I cut 'testFile.temp' from 'right' view and paste it to left view
	Then Opened the move file dialog
	When Click Replace in dialog and replace 'testFile.temp' in 'left' view
	Then File 'testFile.temp' moved from 'C:\temp2' and replaced in 'C:\temp1'

	When I open menu Show -> Separate Tree -> 1 (One For Both Panels)
	Then Opened additional view
	When I click button «Switch through tree panel options» on button bar 2 times
	Then Additional view closed

	When I choose left view 
	And I click button «Search» on button bar 1 times
	Then Opened search dialog
	When I input 'testFile.temp' as name of file
	And Put the RegEx checkbox 
	And Click Start Search
	Then Finded 1 file and 0 folders
	When I click the cross to close the window
	Then Search window closed

	When I deselect all files
	And I open menu Files -> Edit Comment...
	Then Opened error dialog with message with text 'No files selected!'
	When I click Ok in error dialog
	Then Error window closed

	When I open menu Files -> Quit
	Then Main window closed
