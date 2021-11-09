# SuperHero App

This is a Web application where you can find information about your favorite superhero.

This Web App use [SuperHeroe API](https://superheroapi.com), a free accessible API provides a JSON API to get information from their db of Super Heroes and Villains from all universes, all under a single API.

## Requirements

This project was developed using [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0) with [Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)

## Installation and configuration

- Clone this repository

  $ git clone <https://github.com/rubone/superhero-app.git>

- Generate Api token for get access to SuperHeroes API. Go to <https://superheroapi.com> and login with Facebook, they grant you an access token that you can use to make free use of their API.

- Open the project and find the appsettings.json file, you need to add your Api token that you generated in the previous step.

```json
{
  "SuperHeroApi": {
    "BaseUrl": "https://superheroapi.com/api",
    "Token": "YOUR-TOKEN",
    "Endpoints": {
      "Search": "search"
    }
  }
}
```

- Run the project and enjoy!

Happy Coding! :v:
