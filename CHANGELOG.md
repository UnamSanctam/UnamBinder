### v1.2.1 (18/09/2021)
* Changed Icon path and Assembly Data to now literalize escape characters
* Added check for Assembly Version to ensure that it contains only numbers
### v1.2.0 (14/09/2021)
* Replaced windres with a custom compiled windres that supports spaces in file paths
* Removed Base64 encoding/decoding in favor of using bytes directly, meaning no build file size overhead and much faster decoding
* Added new Fake Error option that will display a custom error when the build is started
* Added new Start Delay option to delay the dropping and execution of files, can bypass Windows Defender sandboxing
* Added extensive error checking and more thorough messages whenever anything goes wrong
* Added new log files for compiler errors
* Fixed support for executing all types of files 
* Fixed possible bug when encoding very large files
### v1.1.1 (12/09/2021)
* Worked around windres limitation of not supporting spaces in file paths
### v1.1.0 (12/09/2021)
* Added new custom minimal MinGW64 windres resource compiler
* Added new Icon and Assembly Data options using the new resource compiler
* Increased key complexity to avoid general key scans
* Fixed general small bugs
* Optimized code
### v1.0.0 (09/09/2021)
* Initial release