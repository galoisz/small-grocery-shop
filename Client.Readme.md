# Angular 19 Cash Flow Application

## Overview
This project is a simple Angular 19 application designed to fetch and display cash flow data based on a selected date range. The application features a user-friendly interface that allows users to select a date range and filter the cash flow entries. A line chart powered by Chart.js is used to visualize the data.

## Features
- **Angular 19 Framework**: Built with the latest version of Angular for improved performance and maintainability.
- **Chart.js Integration**: Utilized for rendering a line chart to represent cash flow trends.
- **Component-Based Architecture**: The application is structured into separate, reusable components:
  - `MainComponent`: The central component containing the header, content, and footer.
  - `HeaderComponent`: Provides the date range input fields, filter button, and error message display.
  - `ContentComponent`: Displays the fetched cash flow data.
  - `FooterComponent`: A simple footer section.
- **Data Fetching**: The `DataService` is responsible for calling a Web API to retrieve cash flow data.
- **Simple State Management**: Uses component state to manage loading states, errors, and data.
- **No Routing**: Routing is not implemented as it was not required for this application.

## API Integration
- The application makes HTTP requests to a hardcoded API endpoint: `http://localhost:5000/api/CashFlow`.
- The `DataService` fetches data based on the selected date range and updates the UI accordingly.

## Installation & Setup
To run the application, follow these steps:

   ```
1. Navigate to the project folder:
   ```sh
   cd grocery-shop-front
   ```
2. Install dependencies:
   ```sh
   npm install
   ```
3. Start the application:
   ```sh
   npm start
   ```
4. Open your browser and navigate to `http://localhost:4200/`.

## Usage
- Select a date range using the input fields in the header.
- Click the "Filter" button to fetch and display cash flow data.
- If the selected date range is invalid, an error message will be displayed.
- If an error occurs while fetching data, an error message will appear.

## Future Improvements
- Implement routing if needed for additional features.
- Make the API URL configurable instead of hardcoded.
- Improve error handling and user feedback mechanisms.
- Enhance UI/UX with additional styling and responsiveness.


