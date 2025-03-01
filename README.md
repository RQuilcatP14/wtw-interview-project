<h1 align="center"> WTW Weather Forecast Interview Project 👨🏼‍💻
</h1>

>The WTW technical challenge on Weather Forecast was carried out, and I will detail the process I took to carry it out and some considerations and improvements for the future.

## 📖 Table of Contents

- [First Steps](#first-steps)
- [Prerequisites](#prerequisites)
- [Initial Configuration](#initial-configuration)
- [Project Structure](#project-structure)
- [Future Improvements](#future-improvements)

<h2 id="first-steps">🚀 First Steps</h2>

This solution includes rapid project structuring, unit testing, clean code, solid principles and control validations, as well as an intuitive and user-friendly website for viewing and searching for information.

The steps I took for the solution are the following:

1. Entering the link of the challenge <https://github.com/WTW-IM/weather-project/tree/master?tab=readme-ov-file>, I downloaded a copy of the repository (you can fork the challenge to a repository)
2. Create a clean repository to do an initial push with the copy I downloaded previously.
3. The first step was to understand the structure of the project and the web, so I realized that it was a default solution that is generated when creating a .NET project
4. I removed unnecessary files and unnecessary configurations
5. Create an understandable and maintainable project directory in both the backend and frontend

<h2 id="prerequisites">📌 Prerequisites</h2>

Node.js
<https://nodejs.org/en/>

Visual Studio 2022
<https://visualstudio.microsoft.com/en/vs/>

Visual Studio Code
<https://code.visualstudio.com/>

Open Weather Account
<https://openweathermap.org/api/one-call-3>

<h2 id="initial-configuration">🗄️ Initial Configuration</h2>
To complete the challenge we need a free account on OpenWeather, once the account was created, I went to the API Keys section and created one. Keep in mind that <b>THE GENERATED API KEY CAN BE USED AFTER APPROXIMATELY 45 MINUTES.</b>

With that, you can use the API and create your service.

To unit test the service, you need to install the following NUGET packages

- xUnit
- Moq

<h2 id="project-structure">📁 Project Structure</h2>

As for the project structure, in the backend I have tried to use an MVC (Model-View-Controller) and Layered Architecture architecture.

🔹 <b>Layered Architecture architecture.</b>

The inclusion of a Services folder indicates that there is also a separation of business logic, which aligns with a layered architecture. Generally, in this type of architecture layers are defined as:

1. Presentation Layer (Views, Controllers): Handles the user interface.
2. Application/Services Layer (Services): Contains the business logic and acts as an intermediary between the controllers and the models.
3. Data Layer (Models): Represents the data and its access (may include repositories or Entity Framework).

🔹 <b>Combination of MVC and Layered Architecture</b>

- MVC is responsible for the basic structure of the web application.
- Services add an additional layer that helps separate responsibilities and follow principles such as SOLID.
- If you also use Repository Pattern within the models, you would be adding more modularity.

```text
wtw-interview-project
├── InterviewProject.Web (backend side)                               
│   └── Controllers
│       └── WeatherForecastController.cs
│   └── Models
│       └── WeatherForecastResponse.cs
│   └── Services
│       └── IWeatherForecastService.cs
│       └── WeatherForecastService.cs
│   └── Tests
│       └── WeatherForecastServiceTests.cs
│   └── Client App (front-end layer)
│       └── src
│           └── components
│               └── Backdrop
│                   └── Backdrop.js
│               └── NavBar
│                   └── Navbar.js
│                   └── Navbar.css
│               └── SearchBar
│                   └── SearchBar.js
│               └── Weather
│                   └── Weather.js
│                   └── WeatherTable.js
│               └── ...
│           └── utils
│               └── formatDate.js
│           App.js
│           index.css
│           registerServiceWorker.js
│   Program.cs
│   Startup.cs
```

🔸 <b>What benefits does this combination have?</b>
✅ Better separation of responsibilities.
✅ More modular and reusable code.
✅ Facilitates unit testing in Services without depending on Controllers.
✅ Improved scalability and maintainability.

<h2 id="future-improvements">📚 Future Improvements</h2>

- Use a robust and scalable architecture to generate more services according to the needs that may arise based on one or several entities.  
- In the front-end application, it would be recommended to work with a more current version of ReactJS, we can use frameworks such as NextJS or Vite to work on a server-side.
- We can also replace javascript with typescript, CSS bootstrap with tailwind css, add data fetching with axios and unit testing with jest, as well as storybook for the input components, in turn use Material UI or Radix for a better user interface.

<hr />
Solution Developed by: <b>Rodrigo Miguel Quilcat Pesantes</b> Initialized on February 28, 2025 at 17:30 and ended at 20:30 PM (GMT-5)