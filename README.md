# Portal

## Setup

### Fetching URLS
1. Create an accessible web page which has all URLs you wish to make visible to Portal formatted similarly to the following example:
```
https://example.com
github.com
www.domain.me/what-are-subdomains/
127.0.0.1:80
```
> [!NOTE]
> You may want to use your own public GitHub repository to do this, and create a file that has the URLs, then use the `raw.githubusercontent.com` URL.
2. Set your `PORTAL_FETCH_URL` environment variable to the URL of the web page to allow Portal to use it.
