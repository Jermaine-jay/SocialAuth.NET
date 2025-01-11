# OAuth 2.0 Implementation

This is a simple **ASP.NET Core** application demonstrating how to integrate **OAuth 2.0** authentication with popular providers such as **Google**, **Apple**, **Microsoft**, and **Facebook**. The app showcases the process of setting up authentication and retrieving user information from these providers.

## Features

- **OAuth 2.0 Authentication**:
  - Google
  - Apple
  - Microsoft
  - Facebook
- User login and retrieval of basic user profile information.
- Clean and modular code structure to facilitate learning and implementation.

---

---

## Getting Started

### Prerequisites

- **.NET SDK**: Install [.NET 6.0+](https://dotnet.microsoft.com/download).
- **API Keys and Secrets**: Register your application with each provider to obtain the required credentials:
  - [Google Cloud Console](https://console.cloud.google.com/)
  - [Apple Developer Console](https://developer.apple.com/)
  - [Microsoft Azure Portal](https://portal.azure.com/)
  - [Facebook Developers Portal](https://developers.facebook.com/)

## Installations

1. Clone the Repository

```bash
git clone https://github.com/Jermaine-jay/SocialAuth.NET.git
cd SocialAuth.NET
```

2. Restore Dependences
```bash
dotnet restore
```

## Example Controller Implementation
Below is an example of a controller for validating tokens with multiple OAuth providers:

```sh
    public async Task<IActionResult> OpenIdAuth(string token)
    {
        OpenIdConfiguration res = new OpenIdConfiguration(token);

        // Validate tokens with different providers
        string googleUser = res.googleIdConfiguration.ValidateGoogleToken("your-app-audience");
        string appleUser = res.appleIdConfiguration.ValidateAppleToken("your-app-audience");
        string microsoftUser = res.microsoftIdConfiguration.ValidateMicrosoftToken("your-app-audience", "your-app-tenantid");

        return Ok(new
        {
            GoogleUser = googleUser,
            AppleUser = appleUser,
            MicrosoftUser = microsoftUser
        });
    }
```

# Explanation:
- **Endpoint**: POST /api/OpenId/openId-auth
- **Parameters**:
  - **token (string)**: The ID token received from the OAuth provider.
- **Logic**:
  - Validates the ID token for Google, Apple, and Microsoft.
  - Verifies the token audience and other configurations.
- **Response**:
  - Returns a JSON object with validated user information for each provider.

### Running the Application
1. Build and run the application:

  ``` bash
  dotnet run
  ```

2. Test the OpenIdAuth endpoint using tools like Postman or cURL:

  - Endpoint: http://localhost:5000/api/OpenId/openId-auth
  - Method: POST
  - Body:
  ``` json
  {
    "token": "YOUR_ID_TOKEN"
  }
  ```

### Application Structure
  - Controllers: Handles authentication flows and endpoints.
  - Views: Razor views for login and user profile display.
  - Services: Manages OAuth provider configurations and authentication logic.


### Contributing
We welcome contributions! Here's how you can contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix:
  ``` bash
  git checkout -b feature-name
  ```
3. Commit your changes:
  ``` bash
  git commit -m "Describe your changes"
  ```
4. Push your branch and submit a pull request.
