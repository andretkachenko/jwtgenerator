# Simple JWT Token Generator
A simple console app which lets you generate a JWT Token signed by your **X509** certificate using the **RSA SHA256** hashing algorithm.  
Reads necessary variables from the provided configuration JSON file and returns JWT token in your console.  

## Usage
1. Download the latest release version of the app (see the `Release` section on the right, `JwtGenerator.exe`)
2. Place it in an easy-to-find folder
3. Create `config.json` (you can use any name or keep multiple configurations)
4. Copy schema from [below](#configuration-json-schema)
5. Fill in your values
6. Open `Command Prompt` in your folder from step 2
7. Execute generation with the required configuration: `JwtGenerator.exe config.json`


## Configuration JSON schema
``` json
{
    "crt": "C:\\Users\\username\\certificate_folder\\certificate.pfx",
    "pwd": "your personal passphrase",
    "iss": "consumer key/client id/check service requirements",
    "aud": "service url/check service requirements",
    "sub": "username/check service requirements"
}
```

> The app works with certificates in **PKCS12**/**PFX** format.  
> If you created certificate in **PEM** format, convert it using this command:  
> `openssl pkcs12 -inkey key.pem -in cert.pem -export -out cerf.pfx`  

## Publish new application version
To publish a new version:
1. Open solution in the Visual Studio
2. Right click `JwtGenerator` project
3. Click `Publish`
4. Click `Publish`
5. Open File Explorer
6. Go to `artifacts` folder
7. Use `JwtGenerator.exe` instead of the previously supplied version

## How to debug the app
Passing JSON path to debug session is extremely easy to do:
1. Open solution in the Visual Studio
2. Right click `JwtGenerator` project
3. Click `Properties`
4. Click `Debug`
5. Click `Open debug launch profiles UI`
6. Find the `Command line arguments` section
7. Paster path to your JSON in the input form

Once you have done it, the launch settings will be stored in the `Properties\launchSettings.json` file, which you can edit as you like in any text editor.