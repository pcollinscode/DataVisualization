/***************************************************************************************************
* 
* Programmer:		Joshua Lanman
* Date:				1-JUNE-2017
* Assignment:		Group Project - Software Architecture Visualization Tool
*
* File:				WebScrape.java
* Description:
*
*					This script is used to scrape the architectural data from the GrayLog site (and
*					other websites in the future). Output is a formatted text file that can be
*					read into other programs downstream for additional processing.
*	
***************************************************************************************************/

// Import exception handler
import java.io.IOException;
import java.io.FileNotFoundException;

// Import Java resources for output file
import java.io.File;
import java.io.PrintWriter;

// Import Java resources for creating a dictionary
import java.util.TreeMap;

// Import Jsoup files for webpage scraping
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class WebScrape
{
	/*********************************************************************************
	Description: The main class method. Invokes all methods necessary to parse the
				 requested website.
	*********************************************************************************/		
	public static void main(String[] args) throws FileNotFoundException
	{
		// ********************************************************************************
		// STEP 0: Set up class variables
		// ********************************************************************************		
		String website = "";	// The top webpage to parse data from
		
		// Set up the output file and initialize for writing
		String outputPath = "GrayLog_Web_Parse.txt";
		File outputFile = new File(outputPath);
		PrintWriter filePrint = new PrintWriter(outputFile);
		
		// Set up the dictionaries for tracking page addresses and word counts
		TreeMap<Integer, String> pageLinks = new TreeMap<Integer, String>();
		TreeMap<String, Integer> wordList = new TreeMap<String, Integer>();
		
		// ********************************************************************************
		// STEP 1: 	Get the address of the website to be scraped
		// ********************************************************************************
		// First arg is the name of the website to scrape
		if (args.length > 0)
		{
			website = args[0];
		}
		else
		{
			// Default is the latest documentation menu for GrayLog
			website = "http://docs.graylog.org/en/2.2/";
		}
		filePrint.println("Top Webpage: " + website);
		filePrint.println("--------------------------------------------------------------------------------\n");
		
		// ********************************************************************************
		// STEP 2: 	Get the list of internal webpages to scrape content from.
		// 			This is a scrape of the main menu of the reference documents.
		// ********************************************************************************
		generatePageLinks(website, pageLinks, filePrint);
		
		// ********************************************************************************
		// STEP 3:	Using the list of links created in step 2, parse each individual page for its content.
		// ********************************************************************************
		
		for(Integer curPageLink:pageLinks.keySet())
		{
			// Get the webpage string associated with the current key
			String curWebpage = pageLinks.get(curPageLink);
			
			// Generate the word count for the current page
			generateWordCount(curWebpage, wordList);
		}
		
		// ********************************************************************************
		// STEP 4:	Write the final list out (Page #, word, count) to the output file
		// ********************************************************************************
		printWordList(wordList, filePrint);
				
		// Close the outputFile
		filePrint.close();
	}
	
	/*********************************************************************************
	Description: Scrapes the provided webpage, gathering a list of all the individual 
				 page links that possibly contain system data.
	*********************************************************************************/
	private static void generatePageLinks(String mWebsite, TreeMap<Integer, String> mPageLinks, PrintWriter mFilePrint)
	{
		try
		{
			// Get the single website content
			Document doc = Jsoup.connect(mWebsite).userAgent("mozilla/17.0").get();
			
			// If the content is a link to the start of a webpage, grab it
			Elements temp = doc.select("a[href~=^[^\"#\"]+$].reference.internal");
			
			// Output the numbered list of links to the top of the report file (.txt)
			int i = 0;
			mFilePrint.println("List of Pages Processed:");
			mFilePrint.println("--------------------------------------------------------------------------------");
			for(Element linkList:temp)
			{
				i++;
				mPageLinks.put(i, mWebsite + linkList.getElementsByTag("a").first().attr("href"));
				mFilePrint.println(i + ": " + mPageLinks.get(i));
			}
			mFilePrint.println("--------------------------------------------------------------------------------\n");
		}
		catch(IOException e)
		{
			// TODO: Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	/*********************************************************************************
	Description: Scrapes the provided webpage, gathering a list of all the words 
				 on the page and the number of times each is used.
	*********************************************************************************/
	private static void generateWordCount(String mCurWebpage, TreeMap<String, Integer> mWordCounts)
	{
		try
		{
			// TODO: Print out the name of the page being processed for troubleshooting.
			System.out.println("--------------------------------------------------------------------------------");
			System.out.println("Webpage: " + mCurWebpage);
			System.out.println("--------------------------------------------------------------------------------");
			
			// Get the single website content
			Document doc = Jsoup.connect(mCurWebpage).userAgent("mozilla/17.0").get();
			
			// If the content is a header or paragraph of text, grab it
			Elements temp = doc.select("p:not(.caption),h1,h2");
			
			// Add or update each word and its usage count in the dictionary
			int curWordCount;
			for(Element wordList:temp)
			{
				// Get a working copy of the current line
				String curLine = wordList.getAllElements().first().text();
						
				// TODO: Print out the current line to the console for troubleshooting
				System.out.println(curLine);
				
				// TODO: Trim out the crap, then print again for troubleshooting
				curLine = curLine.replaceAll("\\W", " ").replaceAll("\\s+", " ").trim();
				System.out.println(curLine.replaceAll("\\W", " ").replaceAll("\\s+", " ").trim());
				
				// Find each word in the current line, one at a time
				int wordEnd;
				while (curLine.length() > 0)
				{
					// Find the end of the current word
					wordEnd = 0;
					wordEnd = curLine.indexOf(" ");
					if (wordEnd < 1 || wordEnd > curLine.length())
					{
						wordEnd = curLine.length();
					}
					
					// Capture the current word in a new string
					String curWord = curLine.substring(0, wordEnd).toLowerCase();
					
					// Remove the current word from curLine
					if (wordEnd != curLine.length())
					{
						curLine = curLine.substring(wordEnd + 1);
					}
					else
					{
						curLine = "";
					}
					
					// TODO: Print out the current word for troubleshooting
					System.out.println(curWord);
					
					// If new, add the word to the dictionary. Otherwise, update its count in the dictionary.
					
					if (!mWordCounts.containsKey(curWord))
					{
						// This is a new word. Add it to the dictionary.
						mWordCounts.put(curWord, 1);
					}
					else
					{
						// This word already exists. Update its count in the dictionary.
						curWordCount = mWordCounts.get(curWord);
						mWordCounts.put(curWord, curWordCount + 1);
					}
					
					// TODO: Print out the current word and the associated wordCount for troubleshooting
					System.out.println(curWord + " = " + mWordCounts.get(curWord));
				}
			}
		}
		catch(IOException e)
		{
			// TODO: Auto-generated catch block
			e.printStackTrace();
		}
	}

	/*********************************************************************************
	Description: Writes the wordList to the output file in csv format.
	*********************************************************************************/
	private static void printWordList(TreeMap<String, Integer> mWordList, PrintWriter mFilePrint)
	{
		// Output the list of words to the report file (.txt)
		mFilePrint.println("List of Words (word, count)");
		mFilePrint.println("--------------------------------------------------------------------------------");
		
		for(String curWord:mWordList.keySet())
		{
			// Write the values to the output file
			mFilePrint.println(curWord + ", " + mWordList.get(curWord));
		}
		mFilePrint.println("--------------------------------------------------------------------------------");
	}
}