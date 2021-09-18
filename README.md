
<img src="https://github.com/UnamSanctam/UnamBinder/blob/master/UnamBinder.png?raw=true">

# UnamBinder 1.2.1 - A free silent native file binder

A free silent (hidden) open-source native file binder.

## Main Features

* Native (C) - Builds the final executable as a native (C) 32-bit file, has basically no run requirements
* Silent - Drops and executes (if enabled) files without any visible output unless the bound program has one
* Multiple files - Supports binding any amount of files
* Compatible - Supports all tested Windows version (Windows 7 to Windows 10) and all file types
* Windows Defender exclusions - Can add exclusions into Windows Defender to ignore any detections from the bound files
* Icon/Assembly - Supports adding an Icon and/or Assembly Data to the built file

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/UnamBinder/releases

## Wiki

You can find the wiki [here](https://github.com/UnamSanctam/UnamBinder/wiki) or at the top of the page.

## Changelog

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
* Cleaned up code
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

[You can view the full Changelog here](CHANGELOG.md)

## Author

* **Unam Sanctam**

## Disclaimer

I, the creator, am not responsible for any actions, and or damages, caused by this software.

You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only.

This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use.

By using this software, you automatically agree to the above.

## License

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details

## Donate

XMR: 8BbApiMBHsPVKkLEP4rVbST6CnSb3LW2gXygngCi5MGiBuwAFh6bFEzT3UTufiCehFK7fNvAjs5Tv6BKYa6w8hwaSjnsg2N

BTC: bc1q26uwkzv6rgsxqnlapkj908l68vl0j753r46wvq

ETH: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

ETC: 0xd513e80ECc106A1BA7Fa15F1C590Ef3c4cd16CF3

RVN: RFsUdiQJ31Zr1pKZmJ3fXqH6Gomtjd2cQe

LINK: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

DOGE: DNgFYHnZBVLw9FMdRYTQ7vD4X9w3AsWFRv

LTC: Lbr8RLB7wSaDSQtg8VEgfdqKoxqPq5Lkn3
