# Portal

## Setup

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
> You may want to use your own public GitHub repository to do this, and create a file that has the URLs, then use the `raw.githubusercontent.com` URL.
2. Set your `PORTAL_FETCH_URL` environment variable to the URL of the web page to allow Portal to use it.
