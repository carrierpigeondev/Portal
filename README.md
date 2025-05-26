# Welcome to Portal!
![image](https://github.com/user-attachments/assets/52885f22-8399-469c-8c2b-ea90eeebc1f6)




## What is Portal?
Portal is an extension for the [Command Palette](https://learn.microsoft.com/en-us/windows/powertoys/command-palette/overview) of [Microsoft PowerToys](https://learn.microsoft.com/en-us/windows/powertoys/) that enables URLs to be easily opened from the Command Palette with user-defined entries.

## Setup
### Install through WinGet
> [!NOTE]
> A WinGet package is in the works...

### Fetching URLS
1. Create an accessible web page which has all URLs you wish to make visible to Portal formatted as a fully-qualified domain name similarly to the following example:
```
https://www.example.com
https://www.github.com
https://www.domain.me/what-are-subdomains/
http://127.0.0.1:80
```
> [!NOTE]
> Using a partially qualified domain name *might* work but it is far less reliable.

> [!TIP]
> You may want to use your own public GitHub repository to do this, and create a file that has the URLs, then use the `raw.githubusercontent.com` URL. For example, https://raw.githubusercontent.com/carrierpigeondev/Portal/refs/heads/master/Example/urls.
2. Set your `PORTAL_FETCH_URL` environment variable to the URL of the web page to allow Portal to use it.

## Licensing
The template for Command Palette extension's is licensed by Microsoft Corporation under the MIT license, which I kept, but have licensed my significant changes and created source code under the Apache 2.0 license.

Read the LICENSE file for the licenses.
