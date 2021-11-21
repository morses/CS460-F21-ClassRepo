# -- This file is best viewed with a Gherkin syntax highlighter, e.g. Cucumber (Gherkin) Full Support extension in VS Code

Feature: View athlete race data
  As a user I want to view all track meet data for any athlete so I can know the data has been recorded in the system, see what team the athlete is on, and easily view past results.

Background:
  Given the following teams and coaches exist:
    | Team           | Coach           |
    | Silverton HS   | Erik Cross      |
    | Dallas HS      | Bill Masei      |
    | Central HS     | Eli Cirino      |
    | West Albany HS | Kerri Lemerande |
    | North Salem HS | Don Berger      |

Scenario: Teams page shows teams in alphabetical order
  Given I am on the "Teams" page
  Then I should see a list of teams in alphabetical order


Scenario Outline: Teams page shows all teams
  Given I am on the "Teams" page
  Then I should see a clickable element for <Team>

  Examples:
    | Team           |
    | Silverton HS   |
    | Dallas HS      |
    | Central HS     |
    | West Albany HS |
    | North Salem HS |


Scenario: List of athletes for a team is sorted alphabetically
  Given I am on the "Teams" page
  When I click on the team "Central HS"
  Then I should see a list of athletes in alphabetical order


Scenario: Teams page shows team name and coaches name
  Given I am on the "Teams" page
  When I click on the team <Team>
  Then I should see the team name <Team> displayed prominantly
  And I should see the coaches name <Coach> displayed prominantly


Scenario Outline: Teams page shows all athletes on that team
  Given I am on the "Teams" page
  When I click on the team "North Salem HS"
  Then I should see an athlete named <Athlete>

  Examples:
    | Athlete          |
    | Kurt Nicholson   |
    | Mac Lucas        |
    | Elba Mullins     |
    | Long Hill        |
    | Viola Howell     |
    | Rory Bruce       |
    | Taylor Pugh      |
    | Brooke Rasmussen |


Scenario: Selecting an athlete displays all athlete data
  Given I am on the "Teams" page
  When I click on the Team "North Salem HS"
  When I click on the Athlete "Elba Mullins"            # multiple Whens are discouraged, but we need to sequence this
  Then I should be viewing the page for "Elba Mullins"
  And I should see the athlete's name "Elba Mullins" displayed prominantly

Scenario: Athlete page shows all race data for that athlete
  Given I am on the Athlete page for "Elba Mullins"
  Then I should see a table of race data

Scenario: Athlete page shows all race data for that athlete and is sorted
  Given I am on the Athlete page for "Elba Mullins"
  Then I should see a table of race data that is sorted by event
  And I should see a table of race data that is secondarily sorted by date