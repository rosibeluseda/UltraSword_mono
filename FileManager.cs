using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    // Class                :   FileManager
    //
    // Method parameters    :    -
    //
    // Method return        :    -
    //
    // Synopsis             :   This class is where the text files are accessed to read and write.
    //                                            
    //                                    
    // Modifications        :
    //                                            Date            Developer                Notes
    //                                            ----            ---------                -----
    //                                            2023-11-25      Rosibel Useda    
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    public class FileManager
    {
        private string filename;                //string variable to store the file name

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // Method               :   FileManager
        //
        // Method parameters    :   string filename
        //
        // Method return        :    -
        //
        // Synopsis             :   This method is the constructor for this class  
        //                                            
        //                                    
        // Modifications        :
        //                                            Date            Developer                Notes
        //                                            ----            ---------                -----
        //                                            2023-11-25      Rosibel Useda    
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public FileManager(string filename)
        {
            this.filename = filename;
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // Method               :   ReadFileHiscore
        //
        // Method parameters    :   none
        //
        // Method return        :   List<string[]>
        //
        // Synopsis             :   This method reads data from a text file 
        //                                            
        //                                    
        // Modifications        :
        //                                            Date            Developer                Notes
        //                                            ----            ---------                -----
        //                                            2023-11-25      Rosibel Useda    
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public List<string[]> ReadFileHiscore()
        {
            try
            {
                //reads text files and returns an array with the text file content (high score table)
                List<string[]> lines = new List<string[]>();
                using (StreamReader file = new StreamReader(filename))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] wordsInLine = line.Split();
                        lines.Add(wordsInLine);
                    }
                }
                return lines;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public List<string> ReadFile()
        {
            List<string> result = new List<string>();
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        result.Add(line.Trim());  // Trim removes trailing newline characters
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filename}' not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading file: {e}");
            }
            return result;
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // Method               :   WriteFile
        //
        // Method parameters    :   List<string> scoreList
        //
        // Method return        :   none
        //
        // Synopsis             :   This method writes data from to a text file
        //                                            
        //                                    
        // Modifications        :
        //                                            Date            Developer                Notes
        //                                            ----            ---------                -----
        //                                            2023-11-25      Rosibel Useda    
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void WriteFile(List<string> scoreList)
        {
            try
            {   //writes the high score in the text file
                using (StreamWriter file = new StreamWriter(filename))
                {
                    foreach (var item in scoreList)
                    {
                        file.WriteLine(item);
                    }
                }
                Console.WriteLine($"Sorted array saved to {filename}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving to file: {e}");
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // Method               :   AddNewScore
        //
        // Method parameters    :   string newScore
        //
        // Method return        :   none
        //
        // Synopsis             :   This method sorts the information to write in the text file
        //                                            
        //                                    
        // Modifications        :
        //                                            Date            Developer                Notes
        //                                            ----            ---------                -----
        //                                            2023-11-25      Rosibel Useda    
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

        public void AddNewScore(string newScore)
        {
            List<string> scoreList = ReadFile();                            //add text file content to the list
            // Add the new string to the array
            scoreList.Add(newScore);                                        

            // Define a custom sorting function based on the points
            int GetPoints(string item)
            {
               return int.Parse(item.Split().Last());
            }
            
            // Use the custom sorting function to sort the updated array
            List<string> sortedList = scoreList.OrderByDescending(GetPoints).Take(5).ToList();
            WriteFile(sortedList);
        }
    }

}
