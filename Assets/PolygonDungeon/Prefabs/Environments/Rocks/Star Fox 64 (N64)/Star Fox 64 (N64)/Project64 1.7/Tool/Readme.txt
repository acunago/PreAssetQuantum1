/\/\/\/\/\/\/\/\/\/\/\/\
Tool64 v1.11

by Def,  2001
deflection@most-wanted.com
\/\/\/\/\/\/\/\/\/\/\/\/
---------------------------------------
**Use this program at your own risk. The author is not responsible
for any damage this program may cause.
--------------------------------------- 
Tool64 is a tool for N64 roms only.

- Displays Rom Information
	- Sorts
- Rom Byte Reordering
	- Supports all formats
	- Cueing
	- Automatic Unzip/Rezip
	- Automatic Backups
	- Automatic/Customizable Extension Renaming

- Zipping and Unzipping.
	- Cueing
	- Can read multiple Roms in a Zip.

---------------------------------------
Background:

N64 roms can be found in several byte formats. Big Endian(z64) 
and byteswapped(v64) are the most common. The names are relative
to Big Endian which is the "proper" byte order.

--DWORD formats--
Big Endian - 		0123
Byteswapped -		1032
Little Endian -		3210
*Wordswapped -		2301

*Only recognizes Wordswapped and changes to other formats.
Cannot convert to Wordswapped format.

---------------------------------------
Instuctions:

1) Open your Rom folder in Tool64. Tool64 will display all roms no matter
the extension (except if compressed like zips).
2) Highlight (using ctrl, shift, and mouse) the Roms to swap and 
click the format you want them in on the Toolbar.

---------------------------------------
General Info:

"Sort" - Sort by clicking column headers.

"Rom Properties" - Displays Rom header Info.

"Show backups" - Toggle off/on to display in the list files with the 
backup extension chosen in settings.

"Scan Subdirectories" - Recursively scans all subdirectories below the 
opened one for roms and displays in the list.

"Auto Create Backups" - Creates a backup file with the extension chosen
in settings before changing the rom. It will not overwrite previous 
backups with the same file name and extension. 

"Auto Rename Extensions" - Renames a rom with the extension chosen in 
settings when the rom is swapped.

"Zip Compression Level" - Sets the level of compression when zipping. This doesn't seem to make much difference.  

"Settings" - Select the extensions you would like to use for backups and
the different byte formats.   
 

