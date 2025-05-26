# Welcome to Portal!
![image](https://github.com/user-attachments/assets/52885f22-8399-469c-8c2b-ea90eeebc1f6)




## What is Portal?
Portal is an extension for the [Command Palette](https://learn.microsoft.com/en-us/windows/powertoys/command-palette/overview) of [Microsoft PowerToys](https://learn.microsoft.com/en-us/windows/powertoys/) that enables URLs to be easily opened from the Command Palette with user-defined entries.

## Setup
As this is an extension of PowerToys Command Palette, PowerToys must be installed and Command Palette must be enabled.

### Install through WinGet
> [!NOTE]
> A WinGet package is in the works...

### Fetching URLS
#### Create an accessible webpage or filethat lists all URLs you want Portal to display. Each URL should be a full web address like:
```
https://www.example.com
https://www.github.com
https://www.domain.me/what-are-subdomains/
http://127.0.0.1:80
```
> [!NOTE]
> Using a partial URLs (like just `example.com`) *might* work but are far less reliable.

> [!TIP]
> An easy option is to use a public GitHub repo. You can make a text file with the URLs, then use the `raw.githubusercontent.com` URL. For example, you can try it out with the example URLs from this repo using https://raw.githubusercontent.com/carrierpigeondev/Portal/refs/heads/master/Example/urls.
#### Set your `PORTAL_FETCH_URL` environment variable to the URL of that webpage or file so Portal can know from where to fetch the list.

## Licensing
The template for Command Palette extension's is licensed by Microsoft Corporation under the MIT license, which I kept, but have licensed my significant changes and created source code under the Apache 2.0 license.

Read the LICENSE file for the licenses.
