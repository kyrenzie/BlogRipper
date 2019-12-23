# BlogRipper
An application to scrape LSA blogs

1. Setup:
The application generates files an folders on your system so you will have to change the path to where you would like them to be.
This can be done by changing the path variable on line 42 of Index.cshtml.cs. 

2. Usage:
The application has 4 modes which can be changed between by setting the mode variable on line 36. 
Mode sets which mode the scraper will act in. 1 = Recas Rab Site, 2 = Media Group Online, 
3 = Geneate RAB files, 4 = Generate MGO files.

Modes 1 and 2 are leftovers from previous use but can be used if you would just like to view the generated html with proper images.

Mode 3 will generate 20 html files (10 for the html pages and 10 for the print pages) and 10 PNG image files. These files will be
from the 10 latest posts that have been added to the site. If you would like to change which post it starts or ends on this can be
done by changing the for loop on line 140.

Mode 4 will generate 2 shtml files (link page and print page). This is the latest post on the site.

In this iteration you still have to copy the blog file and paste the html into it manually.

3. Process: (How it would look to do a live update)
  1) Start blogripper on mode 3 (files and folders are now generated)
  2) Connect to site through ftp application
  3) Copy blog main page to local folder and make backups to site as well as a temporary copy of site to work on
  4) Copy HTML from the posts that generated files into the blog file
  5) Upload generated files to site (remember images go in images folder) and rename live site page and temp site page
  6) Restart blogripper on mode 4
  7) Repeat steps 3 - 5
