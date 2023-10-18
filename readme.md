# Simple JWT Token Generator
Simple console app, that allows to generate JWT Token sign by your X509 self-signed certificate.  
Reads necessary variables from provided configuration json file and returns JWT token in your console.  

## Usage
`JwtGenerator.exe Path\\to\\your\\config\\json\\file`

## Configuration json schema
``` json
{
    "crt": "C:\\Users\\username\\certificate_folder\\certificate.pfx",
    "pwd": "your personal passphrase",
    "iss": "consumer key/client id/check service requirements",
    "aud": "service url/check service requirements",
    "sub": "username/check service requirements"
}
```

> You need to specify path to the certificate in **PKCS12**/**PFX** format.  
> **PEM** didn't work for me, and converting it to the required format is so easy and fast I decided to not bother:  
> `openssl pkcs12 -inkey key.pem -in cert.pem -export -out cerf.pfx`  
## Publish new application version
To publish new version:
1. Open solution in the Visual Studio
2. Right click `JwtGenerator` project
3. Click `Publish`
4. Click `Publish`
5. Open File Explorer
6. Go to `artifacts` folder
7. Use `JwtGenerator.exe` instead of previously supplied version

## How to debug the app
Passing json path to debug session is extremely easy to do:
1. Open solution in the Visual Studio
2. Right click `JwtGenerator` project
3. Click `Properties`
4. Click `Debug`
5. Click `Open debug launch profiles UI`
6. Find `Command line arguments` section
7. Paster path to your json in the input form

Once you did it, the launch settings will be stored in `Properties\launchSettings.json` file, which you can edit as you like in any text editor.