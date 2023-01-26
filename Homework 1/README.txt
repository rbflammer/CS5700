The program will prompt for 4 pieces of data. The format for the data is as follows:

Is the input XML or JSON(X/J)?
X or x for XML
J or j for JSON

Where is the input file located? Current dicrectory is [DIRECTORY]
Filepath of input file given in either relative or absolute terms.
Example: C:\Documents\Files\input.xml

Should the output be saved to a file or displayed on screen?(F/S)?
S or s for screen
F or f for saving to file

**If saving to a file was selected**
Where should the output file be saved?
Filepath including filename of desired output file. Can be relative path.
Example: C:\Documents\Output\output.csv


The output format is similar to the one given in the assignment description, 
except this program lists the print statement of all super classes of the 
given shape, followed by the value of the areas all within one column.

There is specific XML and JSON format required for this program to work.
The format is outlined in Planning/TestFileStructure.

I have also included two preset test files. These are in the folder TestFiles.
Note, the data in each file represents an identical set of shapes. This is 
to help show that 1. the program works and 2. the strategy pattern is being
applied.

Unit tests were created and ran within Visual Studio. To get their true output,
I recommend using Visual Studio. The tests cover the computation of area, as well
as the parsing of .json and .xml files.
