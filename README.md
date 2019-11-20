# SearchEngineKeyWordCounter

Simple application that gathers the search results from google of the top 100 results and searches for a url in this data and the amount of times (if any) it occurs.



*Prerequisites*
1) Visual Studio (tested on 2019 but should work on 2017).
2) IIS if you want to host it and not run it via visual studio.

*HOW TO RUN IN VISUAL STUDIO*
1) Download/Pull the Data from this repo.
2) Open it up in visual studio.
3) Build The Solution.
4) Click the run button.
5) It should open up your chosen explorer with the application running.#

*HOW TO RUN IN IIS*
1) Download/Pull the Data from this repo.
2) Open it up in visual studio.
3) Build The solution.
4) Right click the solution and click publish.
 Either
 5): Choose New profile->IIS->File System (under Publish method) -> default website folder (should be C:\inetpub\wwwroot)-> save->publish
(make sure the user has rights to write to the file, if not then they can be added by right clicking the folder->properties->security -> add permissions -> add the user or give it the required permissions.)
OR
5) Choose New profile->Folder->Choose suitable folder (one you have permission to write to)->publish-> either give the IIS application permision to read from the folder (like above) or copy it to the default website folder(should be C:\inetpub\wwwroot)
6)Rightclick default web site in IIS -> add application -> choose the folder of the publish app.
7) Browse to and the application should be working.


*NOTES*
The amount of pages and the regex used to search can be found in the web.config file for the app.These can be changed to whatever value is needed.
The logs by default go to C:\Temp\Logs\{Dayofyear+Year} and are either Output logs (the results of a run) or exceptionLogs (if something went wrong). You can change this folder location in the web.config if need be.
