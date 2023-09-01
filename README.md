# AutoSmuggle
A utility to quickly create your HTML smuggled files.
It is based on the blog post by Outflank https://outflank.nl/blog/2018/08/14/html-smuggling-explained/.

```
Autosmuggle.exe Autosmuggle C:\Path\To\File\abc.exe abc.exe svg/html.
Autosmuggle.exe C:\Path\To\File\yourfile.exe smuggledfile.exe svg
[*] Trying...
[+] Reading Data
[+] Converting to Base64
[*] Smuggling in HTML
[+] File Written to Current Directory...
```  

This will create a file called `smuggled.html` in your current directory.


# To Do
Add an option to include CAPTCHA in the smuggled file
